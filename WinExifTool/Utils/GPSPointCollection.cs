using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WinExifTool.Utils
{
    [Serializable()]
    public class GPSPointCollection
    {
        private string m_Name;

        private List<GPSPoint> m_Points;

        /// <summary>
        /// Name 
        /// </summary>
        [XmlElement("name")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// Points 
        /// </summary>
        [XmlArray("trkseg")]
        [XmlArrayItem("trkpt", typeof(GPSPoint))]
        public List<GPSPoint> Points
        {
            get { return m_Points; }
            set { m_Points = value; }
        }
    }
}
