using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks
{
    /// <summary>
    /// Klasa do zmiany daty modyfikacji pliku na podstawie jego nazwy
    /// </summary>
    class WorkClassPattern : WorkTask
    {
        /// <summary>
        /// Odczytana maska 
        /// </summary>
        private string m_Pattern;

        /// <summary>
        /// Format info do parsowania daty
        /// </summary>
        private DateTimeFormatInfo m_DateFormatInfo;

        /// <summary>
        /// Regex wygenerowany na podstawie maski do znalezienia maski w nazwie pliku
        /// </summary>
        Regex m_FindTimestampRegex;

        /// <summary>
        /// Opis klasy
        /// </summary>
        public override string Description 
        {
            get { return Properties.Lang.WorkClassPattern_description; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public WorkClassPattern()
        {
            Control = new Controls.ControlPattern();
        }

        /// <summary>
        /// Odczytanie ustawień (lista poprzednio użytych masek)
        /// </summary>
        public override bool ReadSettings()
        {
            Controls.ControlPattern control = (Controls.ControlPattern)Control;

            // Pobierz maskę
            m_Pattern = control.editPattern.Text;
            // Zapisz zmiany
            control.SaveSettings(m_Pattern);

            // Rozpoznanie daty składa się z dwóch etapów
            // 1. Znalezienie i wyodrębnienie daty i godziny                    -> findTimestampRegex
            // 2. Przekazanie daty i godziny do rozpoznania daty                -> dateFormatInfo
            m_DateFormatInfo = new DateTimeFormatInfo();
            m_DateFormatInfo.ShortDatePattern = m_Pattern;
            m_FindTimestampRegex = getFindTimestampRegex();

            return true;
        }

        /// <summary>
        /// Generuje regex na podstawie maski daty do znalezienia maski w nazwie pliku
        /// </summary>
        /// <returns></returns>
        private Regex getFindTimestampRegex()
        {
            RegexOptions options = RegexOptions.IgnoreCase;
            Regex regex = new Regex("[a-z]", options);
            string findTimestampPattern = regex.Replace(m_Pattern, "\\d");
            Regex findTimestampRegex = new Regex(findTimestampPattern);
            return findTimestampRegex;
        }

        /// <summary>
        /// Do the job
        /// </summary>
        public override void Make()
        {
            foreach (DS.FilesRow row in Files)
            {
                Make(row);
            }
        }

        /// <summary>
        /// Process row
        /// </summary>
        /// <param name="row"></param>
        private void Make(DS.FilesRow row)
        {
            try
            {
                row.RowError = string.Empty;
                if (!m_FindTimestampRegex.IsMatch(row.FileName))
                {
                    row.RowError = Properties.Lang.WorkClassPattern_rowerror;
                    return;
                }

                Match match = m_FindTimestampRegex.Match(row.FileName);
                string inputTimestampString = match.Value;

                Metadata metadata = new Metadata(row);
                DateTime d = DateTime.ParseExact(inputTimestampString, m_DateFormatInfo.ShortDatePattern, m_DateFormatInfo);
                row.CreateDate = d;
                metadata.Set("File:FileModifyDate", d);
                metadata.Set("File:FileCreateDate", d);
                metadata.BuildFilesRow();
            }
            catch (Exception ex)
            {
                row.RowError = ex.Message;
            }
        }
    }
}
