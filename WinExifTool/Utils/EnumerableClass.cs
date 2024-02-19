using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace WinExifTool.Utils
{
    /// <summary>
    /// Klasa EnumerableClass
    /// </summary>
    public static class EnumerableClassHelper
    {

        /// <summary>
        /// Interfejs pomagający listować klasy dziedziczące
        /// </summary>
        public interface IEnumerableClass
        {
            /// <summary>
            /// Opis do wyświetlenia na liście
            /// </summary>
            string Description { get; }
        }

        /// <summary>
        /// Pobiera listę klas dziedziczących
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> ListSubclasses<T>() where T : IEnumerableClass
        {
            return ListSubclasses<T>(false);
        }

        /// <summary>
        /// Pobiera listę klas dziedziczących. Klasy abstrakcyjne są pomijane.
        /// </summary>
        /// <typeparam name="T">Typ klasy głównej</typeparam>
        /// <param name="SortByName">Czy sortować wg Description</param>
        /// <returns>Lista obiektów KeyValuePair&lt;string, string&gt;, gdzie Key to Nazwa klasy a Value to opis.</returns>
        public static List<KeyValuePair<string, string>> ListSubclasses<T>(bool SortByName) where T : IEnumerableClass
        {

            //pobranie biblioteki
            Type mainType = typeof(T);

            if (mainType.IsGenericType)
            {
                mainType = mainType.GetGenericTypeDefinition();
            }

            //if (mainType.IsGenericType == false)
            //{
            //    if (type.IsGenericType == false)
            //        return type.IsSubclassOf(mainType);
            //}
            //else
            //{
            //    mainType = mainType.GetGenericTypeDefinition();
            //}

            Assembly asm = Assembly.GetAssembly(mainType);

            // Pobranie typów danych z biblioteki
            Type[] subTypes = asm.GetTypes();

            // Wyszukiwanie rekurencyjne klas
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            int i = 0;
            /*
             * Pętla przez wszystkie klasy w bibliotece, żeby znaleźć wszystkie te, które dziedziczą z klasa bazowej
             */ 
            foreach (Type type in subTypes)
            {
                string n = type.Name == null ? string.Empty : type.Name;
                i++;
                if (IsSubClass<T>(type) && !type.IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(type);
                    KeyValuePair<string, string> item = new KeyValuePair<string, string>(type.Name, instance.Description);
                    list.Add(item);
                }

                if (type.BaseType != null && type.BaseType.IsGenericType)
                {
                    // if (type.BaseType.GetGenericTypeDefinition() == mainType && !type.IsGenericType)
                    if (IsSubClassGeneric(type, mainType) && !type.IsGenericType)
                    {
                        IEnumerableClass instance = (IEnumerableClass)Activator.CreateInstance(type);
                        KeyValuePair<string, string> item = new KeyValuePair<string, string>(type.Name, instance.Description);
                        list.Add(item);
                    }
                }
            }

            if (SortByName)
                list.Sort(new ListValueComparer());

            return list;
        }

        /// <summary>
        /// Pobiera instancję klasy dziedziczącej na podstawie nazwy 
        /// </summary>
        /// <typeparam name="T">Typ klasy głównej (abstrakcyjnej)</typeparam>
        /// <param name="SubClassName">Nazwa klasy dziedziczącej do zwrócenia</param>
        /// <returns>instanacja klasy</returns>
        public static T GetInstance<T>(string SubClassName) where T : IEnumerableClass
        {
            // pobranie biblioteki
            Type mainType = typeof(T);
            Assembly asm = Assembly.GetAssembly(mainType);
            Type[] subTypes = asm.GetTypes();

            if (mainType.IsGenericType)
            {
                mainType = mainType.GetGenericTypeDefinition();
            }

            foreach (Type type in subTypes)
            {
                if (type.BaseType != null)
                {
                    if (type.Name == SubClassName && IsSubClass<T>(type) && !type.IsAbstract)
                    {
                        T instance = (T)Activator.CreateInstance(type);
                        return instance;
                    }

                    if (type.BaseType.IsGenericType)
                    {
                        if (type.BaseType.GetGenericTypeDefinition() == mainType && !type.IsGenericType)
                        {
                            T instance = (T)Activator.CreateInstance(type);
                            return instance;
                        }
                    }
                }
            }

            return default(T);
        }


        /// <summary>
        /// Pobiera instancję klasy dziedziczącej na podstawie nazwy 
        /// </summary>
        /// <typeparam name="T">Typ klasy głównej (abstrakcyjnej)</typeparam>
        /// <param name="SubClassName">Nazwa klasy dziedziczącej do zwrócenia</param>
        /// <returns>instanacja klasy</returns>
        public static object GetInstanceGeneric<T>(string SubClassName) 
        {
            // pobranie biblioteki
            Type mainType = typeof(T);
            Assembly asm = Assembly.GetAssembly(mainType);
            Type[] subTypes = asm.GetTypes();

            if (mainType.IsGenericType)
            {
                mainType = mainType.GetGenericTypeDefinition();
            }
            else
            {
                throw new Exception("Use this method only form classes derived from generic class");
            }

            foreach (Type type in subTypes)
            {
                if (type.BaseType != null)
                {

                    if (type.BaseType.IsGenericType)
                    {
                        if (IsSubClassGeneric(type, mainType) && !type.IsGenericType && type.Name == SubClassName)
                        {
                            object instance = Activator.CreateInstance(type);
                            return instance;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Sprawdza, czy podana klasa jest subklasą T
        /// </summary>
        /// <typeparam name="T">Typ klasy głównej</typeparam>
        /// <param name="type">Typ klasy badanej</param>
        /// <returns>True, jeżeli type jest subklasą T lub false, jeżeli nie jest</returns>
        private static bool IsSubClass<T>(Type type) where T : IEnumerableClass
        {
            //Pobranie głównego typu
            Type mainType = typeof(T);

            /*
             * Przeszukanie typu bazowego aż do samego początku
             */
            while (type.BaseType != null)
            {
                /*
                 * Żeby zakwalifikować klasę jako podklasę to nie może być ona abstrakcyjna
                 */ 
                if (type.BaseType == mainType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }


        private static bool IsSubClassGeneric(Type type, Type mainType)
        {
            /*
             * Przeszukanie typu bazowego aż do samego początku
             */
            while (type.BaseType != null)
            {
                /*
                 * Żeby zakwalifikować klasę jako podklasę to nie może być ona abstrakcyjna
                 * 
                 * type.BaseType.IsGenericTypeDefinition && 
                 */
                if (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == mainType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }

        /// <summary>
        /// Klasa porównująca elementy typu KeyValuePair&lt;string, string&gt; wg właściwości Key
        /// </summary>
        private class ListValueComparer : Comparer<KeyValuePair<string, string>>
        {
            /// <summary>
            /// Comparer
            /// </summary>
            /// <param name="x">pierwszy element porównania</param>
            /// <param name="y">drugi element porównania</param>
            /// <returns>wynik porównania</returns>
            public override int Compare(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
            {
                return System.Collections.Comparer.Default.Compare(x.Value, y.Value);
            }
        }

    }
}
