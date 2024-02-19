using System;
using System.Collections.Generic;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks
{
    /// <summary>
    /// Manual set dates
    /// </summary>
    class WorkClassFixedDate : WorkTask
    {

        /// <summary>
        /// Start date and time
        /// </summary>
        private DateTime m_StartDate;

        /// <summary>
        /// Do the time shift for each file
        /// </summary>
        private bool m_Shift = false;

        /// <summary>
        /// Time shift value
        /// </summary>
        private DateTime m_ShiftValue;

        /// <summary>
        /// Time shift in seconds
        /// </summary>
        private int m_ShiftSeconds = 0;

        /// <summary>
        /// Set new date in Exif
        /// </summary>
        private bool m_WriteExif = false;

        /// <summary>
        /// Class description
        /// </summary>
        public override string Description 
        {
            get { return Properties.Lang.WorkClassFixedDate_description; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkClassFixedDate()
        {
            Control = new Controls.ControlFixedDate(); 
        }

        /// <summary>
        /// Read settings
        /// </summary>
        /// <returns></returns>
        public override bool ReadSettings()
        {
            Controls.ControlFixedDate control = (Controls.ControlFixedDate)Control;
            m_StartDate = control.editStartDate.Value.Date + control.editStartTime.Value.TimeOfDay;
            m_Shift = control.editShift.Checked;
            m_ShiftValue = control.editShift.Value;
            m_WriteExif = control.editWriteExif.Checked;

            if (m_Shift)
            {
                m_ShiftSeconds = m_ShiftValue.Hour * 3600 + m_ShiftValue.Minute * 60 + m_ShiftValue.Second;
            }

            Properties.Settings.Default.WorkClassFixedDate_Date = control.editStartDate.Value.Date + control.editStartTime.Value.TimeOfDay;
            Properties.Settings.Default.WorkClassFixedDate_Shift = control.editShift.Value;
            Properties.Settings.Default.WorkClassFixedDate_ShiftChecked = control.editShift.Checked;
            Properties.Settings.Default.WorkClassFixedDate_Exif = control.editWriteExif.Checked;

            return true;
        }

        /// <summary>
        /// Do the job
        /// </summary>
        public override void Make()
        {
            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                
                row.CreateDate = m_StartDate;
                metadata.Set("File:FileModifyDate", m_StartDate);
                metadata.Set("File:FileCreateDate", m_StartDate);

                if (m_WriteExif)
                {
                    row.CreateDate = m_StartDate;
                    metadata.Set("EXIF:DateTimeOriginal", m_StartDate);
                    metadata.Set("EXIF:CreateDate", m_StartDate);
                }
                metadata.BuildFilesRow();

                m_StartDate = m_StartDate.AddSeconds(m_ShiftSeconds);
            }
        }
    }
}
