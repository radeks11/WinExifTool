using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExifTool.WorkTasks
{
    [DataObject(true)]
    public abstract class WorkTask : Utils.EnumerableClassHelper.IEnumerableClass
    {
        #region enumeracje i struktury

        /// <summary>
        /// Tryb pracy: testowy czy zmieniający pliki
        /// </summary>
        public enum WorkMode : int
        {
            TestMode = 0,
            WriteFile = 1,
            BatchMode = 2
        }

        #endregion

        #region Zmienne prywatne

        protected List<DS.FilesRow> m_Files;

        private System.Windows.Forms.UserControl m_Control;

        protected Utils.ExifTool m_ExifTool = new Utils.ExifTool();

        #endregion

        #region Właściwości

        /// <summary>
        /// Opis klasy (do wyświetlenia na liście)
        /// </summary>
        public abstract string Description
        {
            get;
        }

        /// <summary>
        /// Lista plików do pracy
        /// </summary>
        public List<DS.FilesRow> Files
        {
            get { return m_Files; }
            set { m_Files = value; }
        }

        /// <summary>
        /// Control 
        /// </summary>
        public System.Windows.Forms.UserControl Control
        {
            get { return m_Control; }
            set { m_Control = value; }
        }

        #endregion

        #region procedury 

        public virtual bool ReadSettings()
        {
            return true;
        }

        public abstract void Make();

        #endregion

        #region Procedury statyczne

        /// <summary>
        /// 
        /// </summary>
        public static List<Utils.ListItem> Tasks
        {

            get
            {
                List<Utils.ListItem> list = new List<Utils.ListItem>();
                foreach (KeyValuePair<string, string> item in Utils.EnumerableClassHelper.ListSubclasses<WorkTask>())
                {
                    list.Add(new Utils.ListItem(item.Key, item.Value));
                }
                return list;
            }
        }

        public static WorkTask GetInstance(Utils.ListItem item)
        {
            return Utils.EnumerableClassHelper.GetInstance<WorkTask>(item.Key);
        }

        #endregion
    }
}
