using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Klasa obsługi ExifTool
    /// </summary>
    public class ExifTool
    {

        #region Zmienne prywatne

        private List<string> m_Args = new List<string>();
        private List<KeyValuePair<string, DateTime>> m_FileDates = new List<KeyValuePair<string, DateTime>>();
        private string m_LastError = string.Empty;
        private string m_LastPrefix = string.Empty;
        private HashSet<string> m_KnownProperties = new HashSet<string>(PropertyItem.Properties);
        private Charset m_Charset = new Charset(65001);

        #endregion

        #region Właściwości

        /// <summary>
        /// Args 
        /// </summary>
        public List<string> Args
        {
            get { return m_Args; }
            // set { m_Args = value; }
        }

        /// <summary>
        /// Args 
        /// </summary>
        public List<KeyValuePair<string, DateTime>> FileDates
        {
            get { return m_FileDates; }
        }

        /// <summary>
        /// LastError 
        /// </summary>
        public string LastError
        {
            get { return m_LastError; }
        }

        #endregion 

        #region Lista plików

        /// <summary>
        /// Generuje listę plików w podziale na grupy. 
        /// Czyli lista:
        ///     [
        ///         'p1.jpg', 
        ///         'p2.jpg', 
        ///         'p3.jpg', 
        ///         'p4.jpg', 
        ///         'p5.jpg', 
        ///         'p6.jpg'
        ///     ]
        /// Zostanie zamieniona na:
        ///     [
        ///         [ 
        ///             'p1.jpg',
        ///             'p2.jpg', 
        ///             'p3.jpg'
        ///         ],
        ///         [
        ///             'p4.jpg',
        ///             'p5.jpg',
        ///             'p6.jpg'
        ///         ]
        ///     ]
        /// </summary>
        /// <param name="paths">Lista wszystkich plików</param>
        /// <returns></returns>
        public List<List<string>> GroupFileList(IEnumerable<string> paths)
        {
            return GroupFileList(paths, 0);
        }

        /// <summary>
        /// Generuje listę plików w podziale na grupy. 
        /// Czyli lista:
        ///     [
        ///         'p1.jpg', 
        ///         'p2.jpg', 
        ///         'p3.jpg', 
        ///         'p4.jpg', 
        ///         'p5.jpg', 
        ///         'p6.jpg'
        ///     ]
        /// Zostanie zamieniona na:
        ///     [
        ///         [ 
        ///             'p1.jpg',
        ///             'p2.jpg', 
        ///             'p3.jpg'
        ///         ],
        ///         [
        ///             'p4.jpg',
        ///             'p5.jpg',
        ///             'p6.jpg'
        ///         ]
        ///     ]
        /// </summary>
        /// <param name="paths">Lista wszystkich plików</param>
        /// <param name="GroupSize">Wielkość grupy. Jeżeli <=0 to zostanie pobrana wielkość BATCHSIZE z ustawień </param>
        /// <returns></returns>
        public List<List<string>> GroupFileList(IEnumerable<string> paths, int GroupSize)
        {
            // Jeżeli ilość grup mniejsza niż 0 to pobierz wielkość z ustawień
            if (GroupSize <= 0)
            {
                GroupSize = Properties.Settings.Default.BATCHSIZE;
            }

            List<List<string>> groups = new List<List<string>>();
            List<string> group = new List<string>();
            IEnumerator<string> enumerator = paths.GetEnumerator();
            while (enumerator.MoveNext())
            {
                group.Add(enumerator.Current);
                if (group.Count >= GroupSize)
                {
                    groups.Add(group);
                    group = new List<string>();
                }
            }
            groups.Add(group);
            return groups;
        }

        /// <summary>
        /// Generuje listę plików w podziale na grupy. 
        /// Z listy plików zostanie wyciągnięta ścieżka do pliku i zwrócona w postaci:
        ///     [
        ///         [ 
        ///             'p1.jpg',
        ///             'p2.jpg', 
        ///             'p3.jpg'
        ///         ],
        ///         [
        ///             'p4.jpg',
        ///             'p5.jpg',
        ///             'p6.jpg'
        ///         ]
        ///     ]
        /// </summary>
        /// <param name="files">Lista wszystkich plików</param>
        /// <returns></returns>
        public List<List<string>> GroupFileList(List<DS.FilesRow> files)
        {
            List<string> paths = new List<string>();
            foreach (DS.FilesRow row in files)
            {
                paths.Add(row.FilePath);
            }

            return GroupFileList(paths);
        }

        ///// <summary>
        ///// Generuje listę plików zapisaną w jednej linii.
        ///// Czyli lista:
        /////     [
        /////         'p1.jpg', 
        /////         'p2.jpg', 
        /////         'p3.jpg' 
        /////     ]
        ///// Zostanie zamieniona na:
        /////     'p1.jpg p2.jpg p3.jpg', 
        ///// </summary>
        ///// <param name="paths"></param>
        ///// <returns></returns>
        //public string FileList(IEnumerable<string> paths)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    IEnumerator<string> enumerator = paths.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        sb.Append(" ");
        //        sb.Append("\"" + enumerator.Current + "\"");
        //    }
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Generuje listę plików na podstawie listy plików
        ///// </summary>
        ///// <param name="files"></param>
        ///// <returns></returns>
        //public List<string> GenerateFileList(List<DS.FilesRow> files)
        //{
        //    List<string> paths = new List<string>();
        //    foreach (DS.FilesRow row in files)
        //    {
        //        paths.Add(row.FilePath);
        //    }
        //    return GroupFileList(paths);
        //}

        #endregion

        #region CSV

        /// <summary>
        /// Pobiera listę CSV właściwości dla plików poprzez ExifTool.
        /// Lista dzielona jest na mniejsze części
        /// </summary>
        /// <param name="paths"></param>
        public List<Metadata> ReadCSV(List<string> paths)
        {
            m_Args.AddRange(paths);
            AddArgs("-fast1");                          // read only headers without preview
            AddArgs("-G");                              // Add group names to tag keys
            AddArgs("-csv");                            // Return CSV table
            AddArgs("-c");                              // Format GPS 
            AddArgs("%.6f"); 
            AddArgs("-d");                              // Format date
            AddArgs("%d-%m-%Y %H:%M:%S");
            AddArgs("-api");                            // Change new line to space
            AddArgs("filter=s/\\n/ /g");       
            string[] output = Exec(false);
            // string[] output = Exec("-fast1 -G -csv -c \"%.6f\" -d \"%d-%m-%Y %H:%M:%S\" -api filter=\"s/\\n/ /g\"");
            return ParseCSV(output);
        }

        /// <summary>
        /// Zapisuje nagłówek i linię odczytanych właściwości przy danym rekordzie
        /// </summary>
        /// <param name="output"></param>
        private List<Metadata> ParseCSV(string[] output)
        {
            List<Metadata> list = new List<Metadata>();
            if (output.Length < 2)
            {
                return list;
            }
            
            string header = output[0];
            for (int i = 1; i < output.Length; i++)
            {
                string line = output[i];
                int idx = line.IndexOf(',');
                if (idx >= 0)
                {
                    string path = line.Substring(0, idx).Replace("/", "\\");
                    Metadata metadata = Metadata.ParseCSV(path, header, line);
                    list.Add(metadata);
                }
            }

            return list;
        }

        #endregion

        #region Exec

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandLineArgs"></param>
        /// <param name="path"></param>
        /// <param name="fileArgs"></param>
        /// <param name="waitForExit"></param>
        /// <returns></returns>
        public string[] Exec(bool waitForExit)
        {
            // Będziemy zapisywać wykonywanie do logu w kilku plikach: exec, args, output, error.
            // Prefix ma wyróżniać całą paczkę
            m_LastPrefix = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string output = string.Empty;
            string error = string.Empty;
            m_LastError = string.Empty;
            string argsPath = string.Empty;

            // Zapisz argumenty do pliku
            if (m_Args.Count > 0)
            {
                argsPath = WriteExecArgs("2_args");
            }

            // Przygotuj proces i startInfo
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Properties.Settings.Default.exiftool;
            startInfo.Arguments = m_Charset.FileCharset + (argsPath == string.Empty ? string.Empty :  " -@ \"" + argsPath + "\"");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(m_Charset.Codepage);
            startInfo.StandardErrorEncoding = Encoding.GetEncoding(m_Charset.Codepage);

            // Zapisz do logu informację o uruchomieniu: główne polecenie wykonania
            StringBuilder execCommand = new StringBuilder();
            execCommand.AppendLine("@echo off");
            execCommand.AppendLine("REM chcp " + m_Charset.Codepage);
            execCommand.AppendLine("\"" + startInfo.FileName + "\" " + startInfo.Arguments);

            WriteExecLog("1_exec", execCommand.ToString() );

            process.StartInfo = startInfo;
            process.Start();
            if (waitForExit)
            {
                process.WaitForExit();
            }
            output = process.StandardOutput.ReadToEnd().Trim();
            error = process.StandardError.ReadToEnd();
            WriteExecLog("3_output", output);

            if (error.Length > 0)
            {
                WriteExecLog("4_error", error.Trim());
                m_LastError = error.Trim();
            }
            
            return output.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Wykonaj zmiany daty modyfikacji plików
        /// </summary>
        public void ChangeFilesDate()
        {
            try
            {
                foreach (KeyValuePair<string, DateTime> filedate in m_FileDates)
                {
                    File.SetCreationTime(filedate.Key, filedate.Value);
                    File.SetLastWriteTime(filedate.Key, filedate.Value);
                }

                // Kasuj listę dat do modyfikacji
                m_FileDates = new List<KeyValuePair<string, DateTime>>();
            }
            catch (Exception ex)
            {
                WriteExecLog("4_error", ex.Message);
                m_LastError = ex.Message;
            }
        }

        #endregion

        #region Args

        /// <summary>
        /// Add to args file changes from metadata
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public void AddArgs(Metadata metadata)
        {
            SortedDictionary<string, string>.Enumerator enumerator = metadata.Changes.GetEnumerator();

            // Dodanie właściwości do przekazania do ExifTool
            while (enumerator.MoveNext())
            {
                if (m_KnownProperties.Contains(enumerator.Current.Key))
                {
                    AddArgs("-{0}={1}", enumerator.Current.Key, enumerator.Current.Value);
                }
                else if (enumerator.Current.Key == "IPTC:Keywords")
                {
                    AddArgsKeywords(enumerator.Current.Value);
                }
                else if (enumerator.Current.Key == "Composite:GPSPosition")
                {
                    AddArgsGPS(metadata.Changes);
                }
                else if (enumerator.Current.Key == "EXIF:CreateDate")
                {
                    DateTime d = Metadata.ParseDate(enumerator.Current.Value);
                    AddArgs("-overwrite_original");
                    AddArgs("-AllDates={0:yyyy-MM-dd HH:mm:ss}", d);
                }
            }
            AddArgs("-P");
            AddArgs("-codedcharacterset=UTF8");
            AddArgs("-overwrite_original");
            AddArgs(metadata.FilePath);
            AddArgs("-execute");

            // Wprowadzenie zmian do wiersza
            metadata.CommitChanges();
        }

        public void AddArgs(IEnumerable<string> list)
        {
            m_Args.AddRange(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        public void AddArgs(string s, params object[] args)
        {
            if (args == null)
            {
                m_Args.Add(s.TrimStart());
            }
            else
            {
                m_Args.Add(string.Format(s, args).TrimStart());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void AddArgsKeywords(string value)
        {
            string[] keywords = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string keyword in keywords)
            {
                AddArgs("-keywords={0}", keyword);
            }
        }

        private void AddArgsGPS(SortedDictionary<string, string> changes)
        {
            GPSPoint p = new GPSPoint(changes);
            AddArgs("-EXIF:GPSLatitude={0}", p.LatNoRef);
            AddArgs("-EXIF:GPSLatitudeRef={0}", p.LatRef);
            AddArgs("-EXIF:GPSLongitude={0}", p.LngNoRef);
            AddArgs("-EXIF:GPSLongitudeRef={0}", p.LngRef);

            if (p.State == GPSPoint.PointState.LatLngAlt)
            {
                AddArgs("-EXIF:GPSAltitude={0}", p.AltNoRef);
                AddArgs("-EXIF:GPSAltitudeRef={0}", p.AltRef);
            }
        }

        /// <summary>
        /// Dodanie
        /// </summary>
        /// <param name="changes"></param>
        /// <param name="filepath"></param>
        public void AddFileDate(string filepath, DateTime d)
        {
            // 
            if (d > DateTime.MinValue)
            {
                m_FileDates.Add(new KeyValuePair<string, DateTime>(filepath, d));
            }
        }

        #endregion

        #region ExecLog

        private string WriteExecLog(string context, string s)
        {
            string folderPath = GetExecuteLogFolder();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filepath = GetExecuteLogPath(m_LastPrefix, context);
            StreamWriter sw = new StreamWriter(filepath, true, Encoding.GetEncoding(m_Charset.Codepage));
            sw.Write(s);
            sw.Close();
            sw.Dispose();

            return filepath;
        }

        private string WriteExecArgs(string context)
        {
            string folderPath = GetExecuteLogFolder();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filepath = GetExecuteLogPath(m_LastPrefix, context);
            string last = string.Empty;

            StreamWriter sw = new StreamWriter(filepath);
            foreach (string line in m_Args)
            {
                last = line;
                sw.WriteLine(line);
            }

            // Ostatnia linia musi się kończyć wykonaniem.
            // Jeżeli wykonanie nie zostało dodane to trzeba je dodać przy zapisywaniu
            if (last != "-execute")
            {
                sw.WriteLine("-execute");
            }

            sw.Close();
            sw.Dispose();
            m_Args = new List<string>();
            return filepath;
        }

        public static string GetExecuteLogFolder()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "ExecLog";
        }

        public static string GetExecuteLogPath(string prefix, string context)
        {
            string extension = ".log";
            if (context.StartsWith("1"))
            {
                extension = ".bat";
            }
            else if (context.StartsWith("2"))
            {
                extension = ".txt";
            }

            return GetExecuteLogFolder() + "\\" + prefix + "_" + context + extension;

        }

        #endregion

    }
}
