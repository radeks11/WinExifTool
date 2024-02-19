using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Klasa zapisująca do tekstowego pliku logu
    /// </summary>
    public static class Log
    {
        #region Zmienne lokalne

        /// <summary>
        /// Domyślna nazwa pliku logu
        /// </summary>
        private static string m_LogFileName = string.Empty;

        /// <summary>
        /// Folder dla pliku LOG
        /// </summary>
        private static string m_LogFolder = String.Empty;

        /// <summary>
        /// Pełna ścieżka do logu
        /// </summary>
        private static string m_LogPath = String.Empty;

        /// <summary>
        /// Zmienna na komunikaty
        /// </summary>
        private static StringBuilder m_Messages = new StringBuilder();

        /// <summary>
        /// Długość buffora dla komunikatów trzymanych w pamięci. Zero oznacza, że buffor ma nie być czyszczony
        /// </summary>
        private static int m_BufferLenThreshold = 2000;

        /// <summary>
        /// 
        /// </summary>
        private static int m_FileLenghtThreshold = 0;

        /// <summary>
        /// Lock dla sekcji krytycznej wątków dla manipulacji wiadomościami
        /// </summary>
        private static object m_MessagesLock = new object();

        /// <summary>
        /// Lock dla sekcji krytycznej wątków dla operacji na pliku
        /// </summary>
        private static object m_FileLock = new object();

        #endregion

        #region Właściwości

        /// <summary>
        /// Nazwa pliku logu (używana tylko jeżeli LogFile == ""). Jeżeli nie została zdefiniowana to plik będzie się nazywał error.log.
        /// </summary>
        public static string LogFileName
        {
            get { return m_LogFileName == string.Empty ? "error.log" : m_LogFileName; }
            set
            {
                // Ustawienie nazwy pliku log
                m_LogFileName = value;

                // Skasowanie nazwy pełnej ścieżki logu aby utworzyć ją od nowa
                m_LogPath = String.Empty;
            }

        }

        /// <summary>
        /// Nazwa folderu, gdzie będzie zapisywany plik logu (używana tylko jeżeli LogFile == ""). Jeżeli nie została zdefiniowana to będzie to domyślny katalog aplikacji.
        /// </summary>
        public static string LogFolder
        {
            get
            {
                if (m_LogFolder == string.Empty)
                {
                    m_LogFolder = System.Windows.Forms.Application.StartupPath;
                }
                return m_LogFolder;
            }
            set
            {
                // Ustawienie folderu
                m_LogFolder = value;

                // Skasowanie nazwy pełnej ścieżki logu aby utworzyć ją od nowa
                m_LogPath = String.Empty;
            }
        }

        /// <summary>
        /// Pełna ścieżka do logu. Jeżeli nie została zdefiniowana to zostanie użyta kombinacja LogFolder + FileName.
        /// </summary>
        public static string LogFullPath
        {
            get
            {
                if (m_LogPath == string.Empty)
                {
                    m_LogPath = LogFolder + "\\" + LogFileName;
                }

                return m_LogPath;
            }
            set
            {
                m_LogPath = value;
                m_LogFolder = System.IO.Path.GetDirectoryName(value);
                m_LogFileName = System.IO.Path.GetFileName(value);
            }
        }

        /// <summary>
        /// Długość buffora dla komunikatów trzymanych w pamięci. Zero oznacza, że buffor ma nie być czyszczony
        /// </summary>
        public static int BufferLen
        {
            set { m_BufferLenThreshold = value; }
            get { return m_BufferLenThreshold; }
        }
        #endregion

        #region Dodanie do logu

        /// <summary>
        /// Dodaje formatowalny tekst do logu. 
        /// </summary>
        /// <param name="message">Formatowalny tekst</param>
        /// <param name="args">argumenty formatowania</param>
        public static void addLog(string message, params object[] args)
        {
            addLog(string.Format(message, args));
        }

        /// <summary>
        /// Dodaje tekst do logu
        /// </summary>
        /// <param name="message">Tekst do dodania</param>
        public static void addLog(string message)
        {
            try
            {
                // Dodanie komunikatu
                lock (m_MessagesLock)
                {
                    m_Messages.AppendLine(message);
                }

                // Sprawdzenie ścieżki do pliku log
                checkPaths();

                // Zapis do pliku
                lock (m_FileLock)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(LogFullPath, true);
                        sw.WriteLine(string.Format("{0:dd-MM-yyyy HH:mm:ss} {1}", DateTime.Now, message));
                        sw.Close();
                        sw.Dispose();
                        sw = null;
                    }
                    catch (Exception ex)
                    {
                        // Dodanie komunikatu
                        lock (m_MessagesLock)
                        {
                            m_Messages.AppendLine("!!!!! LOG !!!!!");
                            m_Messages.AppendLine(ex.Message);
                        }
                        System.Diagnostics.Debug.Print(ex.Message);
                    }
                }

                // Rotacja komunikatów trzymanych w pamięci
                RotateBuffer();

                // Rotacja pliku log
                RotateFile();
            }
            catch { }
        }

        #endregion

        #region Log paths

        /// <summary>
        /// Sprawdzenie ścieżek do pliku log
        /// </summary>
        private static void checkPaths()
        {
            // Utworzenie katalogu roboczego, jezeli nie istnieje
            if (!System.IO.Directory.Exists(LogFolder))
            {
                System.IO.Directory.CreateDirectory(LogFolder);
            }
        }

        #endregion

        #region Rotate buffer

        /// <summary>
        /// Czyszczenie buforu komunikatów jeżeli jego długość przekracza zadaną długość buffora.
        /// Obcinana jest początkowa część zaokrąglona 
        /// </summary>
        public static void RotateBuffer()
        {
            // Jeżeli długość maksymalnego buffora jest 0 to znaczy, że mamy nie rotować go.
            if (m_BufferLenThreshold == 0)
                return;

            lock (m_MessagesLock)
            {
                // Indeks startowy. Jeżeli jest mniejszy niż 0 to znaczy, że nie trzeba rotować
                int startIndex = m_Messages.Length - m_BufferLenThreshold;
                if (startIndex > 0)
                {
                    // Szukanie najbliższego znaku końca linii
                    for (int i = startIndex; i < m_Messages.Length; i++)
                    {
                        if (m_Messages[i] == '\n')
                        {
                            // Usunięcie części od początku do znaku końca linii
                            m_Messages.Remove(0, i);
                            return;
                        }
                    }
                }
            }
        }

        #endregion

        #region Clear buffer

        /// <summary>
        /// Czyszczenie buforu komunikatów
        /// </summary>
        public static void ClearBuffer()
        {
            // Nie ma opcji czyszczenia, więc tworzymy nowy obiekt
            m_Messages = new StringBuilder();
        }

        #endregion

        #region Rotate file

        /// <summary>
        /// Wykonuje rotację pliku log
        /// </summary>
        private static void RotateFile()
        {
            // Jeżeli długość pliku jest ustawiona na 0 to znaczy, że mamy go nie rotować
            if (m_FileLenghtThreshold == 0)
                return;

            //TODO: dodać rotację plików
            lock (m_FileLock)
            {

            }
        }

        #endregion

        /// <summary>
        /// Pobiera aktualną zawartość bufora
        /// </summary>
        /// <returns></returns>
        public static string GetMessages()
        {
            string s = string.Empty;
            lock (m_MessagesLock)
            {
                s = m_Messages.ToString();
            }

            return s;
        }

        #region Get and clear

        /// <summary>
        /// Pobiera zawartość buffora wiadomości i czyści go po pobraniu
        /// </summary>
        /// <returns></returns>
        public static string GetMessagesAndClear()
        {
            string s = string.Empty;
            lock (m_MessagesLock)
            {
                s = m_Messages.ToString();
                m_Messages = new StringBuilder();
            }

            return s;
        }

        #endregion
    }

}
