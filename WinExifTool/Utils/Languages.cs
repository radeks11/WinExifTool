using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Lista dostępnych języków
    /// </summary>
    [DataObject(true)]
    public static class Languages
    {

        /// <summary>
        /// Pobiera listę języków
        /// </summary>
        /// <typeparam name="T">ListItem</typeparam>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ListItem> Select()
        {
            List<Utils.ListItem> languages = new List<ListItem>();
            languages.Add(new Utils.ListItem("en", "English (default)"));
            languages.Add(new Utils.ListItem("pl-PL", "Polski"));
            return languages;
        }
    }

}
