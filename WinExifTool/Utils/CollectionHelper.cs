using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinExifTool.Utils
{
    public partial class Metadata
    {
        static class CollectionHelper
        {
            #region Merge

            /// <summary>
            /// Dodaj zmiany z changes. Zmiany mają priorytet
            /// </summary>
            /// <param name="properties">Główny obiekt właściwości. Po mergowaniu zostanie zmieniony</param>
            /// <param name="changes">Zmiany</param>
            /// <returns></returns>
            public static void Merge(SortedDictionary<string, string> properties, SortedDictionary<string, string> changes)
            {

                SortedDictionary<string, string>.Enumerator enumerator = changes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (properties.ContainsKey(enumerator.Current.Key))
                    {
                        properties[enumerator.Current.Key] = enumerator.Current.Value;
                    }
                    else
                    {
                        properties.Add(enumerator.Current.Key, enumerator.Current.Value);
                    }
                }

            }

            /// <summary>
            /// Dodaj zmiany z changes. Zmiany mają priorytet
            /// </summary>
            /// <param name="properties">Główny obiekt właściwości. Po mergowaniu zostanie zmieniony</param>
            /// <param name="changes">Zmiany</param>
            public static void Merge(SortedDictionary<string, string> properties, object changes)
            {
                if (changes == DBNull.Value)
                {
                    return;
                }
                Merge(properties, (SortedDictionary<string, string>)changes);
            }

            #endregion

            #region Convert to dictionary

            /// <summary>
            /// Konweruje obiekt do słownika
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static SortedDictionary<string, string> ConvertToDictionary(object o)
            {
                if (o == DBNull.Value)
                {
                    return new SortedDictionary<string, string>();
                }
                else
                {
                    return (SortedDictionary<string, string>)o;
                }
            }

            #endregion

            #region Set - ustawianie wartości w słowniku

            /// <summary>
            /// Ustawia wartość w słowniku
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <param name="value">Wartość</param>
            public static void Set(IDictionary<string, string> dictionary, string key, string value)
            {
                if (key == string.Empty)
                {
                    return;
                }
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    dictionary.Add(key, value);
                }
            }

            /// <summary>
            /// Ustawia wartość w słowniku
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <param name="value">Wartość</param>
            public static void Set(IDictionary<string, string> dictionary, string key, DateTime value)
            {
                Set(dictionary, key, Metadata.DateTimeToString(value));
            }

            /// <summary>
            /// Serializuje listę wartości i wstawia ją jako wartość w słowniku
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <param name="values">Lista wartości do ustawienia w słowniku po serializacji</param>
            /// <param name="delimiter"></param>
            public static void SetList(IDictionary<string, string> dictionary, string key, IEnumerable<string> values, char delimiter)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string value in values)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(delimiter);
                    }
                    sb.Append(value);
                }
                Set(dictionary, key, sb.ToString());
            }

            ///// <summary>
            ///// Ustawia wartość w słowniku
            ///// </summary>
            ///// <param name="dictionary">Słownik</param>
            ///// <param name="keys">Klucz</param>
            //public static void SetRange<T>(ICollection<T> dictionary, IEnumerable<T> keys)
            //{
            //    foreach(T key in keys)
            //    {
            //        if (!dictionary.Contains(key))
            //        {
            //            dictionary.Add(key);
            //        }
            //    }
            //}

            #endregion

            #region Get - pobieranie wartości ze słownika

            /// <summary>
            /// Pobiera wartość testkową ze słownika
            /// </summary>
            /// <param name="dictionary"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Get(IDictionary<string, string> dictionary, string key)
            {
                if (dictionary.ContainsKey(key))
                {
                    return dictionary[key];
                }
                else
                {
                    return string.Empty;
                }
            }

            /// <summary>
            /// Pobiera pierwszą wartość tekstową z podanej listy kluczy
            /// </summary>
            /// <param name="dictionary"></param>
            /// <param name="keys"></param>
            /// <returns></returns>
            public static string Get(IDictionary<string, string> dictionary, IEnumerable<string> keys)
            {
                foreach (string key in keys)
                {
                    string value = Get(dictionary, key);
                    if (value != string.Empty)
                    {
                        return value;
                    }
                }

                return string.Empty;
            }

            /// <summary>
            /// Pobiera wartość ze słownika
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <returns></returns>
            public static int Get(IDictionary<string, string> dictionary, string key, int notFoundValue)
            {
                if (dictionary.ContainsKey(key))
                {
                    string s = dictionary[key];
                    if (s == string.Empty)
                    {
                        return notFoundValue;
                    }

                    return System.Convert.ToInt32(s);
                }
                return notFoundValue;
            }

            /// <summary>
            /// Pobiera wartość ze słownika
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <returns></returns>
            public static DateTime Get(IDictionary<string, string> dictionary, string key, DateTime notFoundValue)
            {
                string value = Get(dictionary, key);
                if (value == string.Empty)
                {
                    return notFoundValue;
                }
                else
                {
                    return Metadata.ParseDate(value, notFoundValue);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <param name="delimiter"></param>
            /// <returns></returns>
            public static List<string> GetList(IDictionary<string, string> dictionary, string key, char delimiter)
            {
                string value = Get(dictionary, key);
                if (value == string.Empty)
                {
                    return new List<string>();
                }
                else
                {
                    List<string> list = value.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] = list[i].Trim();
                    }
                    return list;
                }
            }

            #endregion

            #region Contains - sprawdzanie, czy klucz występuje w słowniku

            /// <summary>
            /// Sprawdza, czy klucz występuje w słowniku i ma ustawioną jakąś wartość
            /// </summary>
            /// <param name="dictionary">Słownik</param>
            /// <param name="key">Klucz</param>
            /// <returns></returns>
            public static bool Contains(IDictionary<string, string> dictionary, string key)
            {
                string value;
                if (dictionary.TryGetValue(key, out value))
                {
                    return value != string.Empty;
                }
                else
                {
                    return false;
                }
            }

            #endregion

        }
    }
    
}
