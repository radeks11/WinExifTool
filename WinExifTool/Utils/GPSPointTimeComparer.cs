using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Klasa porównująca elementy typu <see cref="GPSPoint"/> wg key
    /// </summary>
    public class GPSPointTimeComparer : Comparer<GPSPoint>
    {
        /// <summary>
        /// Comparer
        /// </summary>
        /// <param name="x">pierwszy element porównania</param>
        /// <param name="y">drugi element porównania</param>
        /// <returns>wynik porównania</returns>
        public override int Compare(GPSPoint x, GPSPoint y)
        {
            return System.Collections.Comparer.Default.Compare(x.Time, y.Time);
        }
    }
}
