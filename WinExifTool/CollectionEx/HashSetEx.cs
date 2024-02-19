using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinExifTool.CollectionEx
{
    public class HashSetEx<T>: HashSet<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public void AddRange(ICollection<T> keys)
        {
            foreach (T key in keys)
            {
                {
                    Add(key);
                }               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveRange(ICollection<T> keys)
        {
            foreach (T key in keys)
            {
                Remove(key);
            }
        }

    }
}
