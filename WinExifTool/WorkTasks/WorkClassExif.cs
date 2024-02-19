using System.Collections.Generic;
using WinExifTool.Utils;

namespace WinExifTool.WorkTasks
{
    /// <summary>
    /// Set file modification date by Exif date
    /// </summary>
    class WorkClassExif : WorkTask
    {
        /// <summary>
        /// Class description
        /// </summary>
        public override string Description
        {
            get { return  Properties.Lang.WorkClassExif_description; }
        }

        /// <summary>
        /// Construcotr
        /// </summary>
        public WorkClassExif()
        {
            Control = null;
        }

        /// <summary>
        /// Do the job
        /// </summary>
        public override void Make()
        {
            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                metadata.Set("File:FileModifyDate", row.CreateDate);
                metadata.Set("File:FileCreateDate", row.CreateDate);
                metadata.BuildFilesRow();
            }
        }
    }
}
