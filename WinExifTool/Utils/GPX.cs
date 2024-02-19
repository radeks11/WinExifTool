using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WinExifTool.Utils
{

    /// <summary>
    /// Class description
    /// </summary>
    [Serializable()]
    [XmlRoot("gpx")]
    public class GPX
    {

        #region Private and Protected

        /// <summary>
        /// Name
        /// </summary>
        private string m_Name;

        /// <summary>
        /// Start date
        /// </summary>
        private DateTime m_StartDate = DateTime.MinValue;

        /// <summary>
        /// End date
        /// </summary>
        private DateTime m_EndDate = DateTime.MinValue;

        /// <summary>
        /// Lista punktów
        /// </summary>
        private GPSPointCollection m_Points;

        #endregion

        #region Properties

        /// <summary>
        /// Name 
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate
        {
            get { return m_StartDate; }
        }

        /// <summary>
        /// EndDate 
        /// </summary>
        public DateTime EndDate
        {
            get { return m_EndDate; }
        }

        /// <summary>
        /// Klasa dla listy punktów
        /// </summary>
        [XmlElement("trk")]
        public GPSPointCollection PointCollection { 
            get { 
                return m_Points;  
            }
            set
            {
                m_Points = value;
                if (m_Points.Points.Count > 0)
                {
                    m_StartDate = m_Points.Points[0].Time;
                    m_EndDate = m_Points.Points[m_Points.Points.Count - 1].Time;
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public GPX()
        {

        }

        #endregion

        #region Methods

        #endregion

        #region Overrides

        /// <summary>
        /// Display Property as default string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

        #region Static

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static GPX Deserialize(string path)
        {
            GPX gpx = null;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            XmlReader xmlReader = XmlReader.Create(path, settings);
            if (xmlReader.IsStartElement("gpx"))
            {
                string defaultNamespace = xmlReader["xmlns"];
                XmlSerializer serializer = new XmlSerializer(typeof(GPX), defaultNamespace);
                gpx = (GPX)serializer.Deserialize(xmlReader);
            }

            return gpx;
        }

        #endregion

        #region FindByTime

        /// <summary>
        /// Znajduje element na liście punktów wg daty i czasu
        /// Jeżeli element dokładnie z takim samym czasem nie zostanie znaleziony to zwracany jest najbliższy pod warunkiem, że jego odległość czasowa
        /// jest mniejsza niż 2 sekundy
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public GPSPoint FindByTime(DateTime time)
        {
            GPSPointTimeComparer comparer = new GPSPointTimeComparer();
            GPSPoint pointToFind = new GPSPoint(time);
            int searchIndex = m_Points.Points.BinarySearch(pointToFind, comparer);            
            GPSPoint p = null;

            // Sprawdzenie indeksu wyszukiwania
            if (searchIndex >= 0)
            {
                // Jeżeli został znaleziony element z dokładnie takim samym czasem to go zwracamy
                p = m_Points.Points[searchIndex];
            }
            else
            {
                // Jeżeli nie został znaleziony element z dokładnie takim samym czasem to bierzemy zwrócony index
                // Po zamianie bitowej powinien pokazywać najbliższy element
                int closestIndex = ~(searchIndex + 1);

                // Sprawdzenie, czy indeks najbliższego elementu rzeczywiście mieści się w zakresie wyszukiwania
                // oraz czy odległość czasowa jest mniejsza niż 2 sekundy
                if (closestIndex >= 0 && closestIndex < m_Points.Points.Count && m_Points.Points[closestIndex].Time.Subtract(time).TotalSeconds < 2)
                {
                    p = m_Points.Points[closestIndex];
                }
            }

            return p;
        }

        #endregion
    }
}
