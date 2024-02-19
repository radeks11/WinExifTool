using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using GMap.NET;
using System.Xml.Serialization;

namespace WinExifTool.Utils
{
    [Serializable()]
    public class GPSPoint 
    {

        #region Enum and Struct

        /// <summary>
        /// Status inicjalizacji punktu. Może nie 
        /// </summary>
        public enum PointState : int
        {
            /// <summary>
            /// Nie zostały poprawnie ustawione współrzędne Lat i Lng
            /// </summary>
            Empty = 0,

            /// <summary>
            ///  zostały poprawnie ustawione tylko współrzędne Lat i Lng (bez wysokości)
            /// </summary>
            LatLng = 1,

            /// <summary>
            /// zostały poprawnie ustawione współrzędne Lat i Lng oraz wysokość
            /// </summary>
            LatLngAlt = 2
        }

        #endregion

        #region Zmienne prywatne

        /// <summary>
        /// Punkt lat lng
        /// </summary>
        private PointLatLng m_Point;

        /// <summary>
        /// Wysokość
        /// </summary>
        private double m_Alt;

        /// <summary>
        /// Czy punkt 
        /// </summary>
        private PointState m_State;

        /// <summary>
        /// Czas punktu (używane tylko dla GPX)
        /// </summary>
        private DateTime m_Time;

        /// <summary>
        /// Parser dla pojedynczej współrzędnej Lat lub Lng
        ///         40.892433 N, 
        ///         73.982871 W
        /// </summary>
        private static Regex m_RegexLat = new Regex("(\\d{1,3}\\.\\d{1,8})\\s*([NSWE])");

        /// <summary>
        /// Parser dla formatu 40.892433 N, 73.982871 W
        /// </summary>
        private static Regex m_RegexLatLng1 = new Regex("(\\d{1,3}\\.\\d{1,8})\\s*([NS])\\s*,\\s*(\\d{1,3}\\.\\d{1,8})\\s*([WE])");

        /// <summary>
        /// Parser dla formatu 40.89243352315631, -73.98287154503505
        /// </summary>
        private static Regex m_RegexLatLng2 = new Regex("(-{0,1}\\d{1,3}\\.\\d+)\\s*,\\s*(-{0,1}\\d{1,3}\\.\\d+)");

        /// <summary>
        /// Parser dla formatu 40°53'32.6"N 73°58'58.4"W
        /// </summary>
        private static Regex m_RegexLatLng3 = new Regex("(\\d{1,3})°\\s*(\\d{1,2})'\\s*(\\d{1,2}\\.{0,1}\\d{0,3})\"\\s*([NS])\\s*(\\d{1,3})°\\s*(\\d{1,2})'\\s*(\\d{1,2}\\.{0,1}\\d{0,3})\"\\s*([WE])");
        
        /// <summary>
        /// Parser dla formatu 1234 m Above the sea
        /// </summary>
        private static Regex m_RegexAlt1 = new Regex("(\\d{1,3}\\.\\d{1,8})\\s(.)");

        #endregion

        #region Właściwości

        /// <summary>
        /// Punkt
        /// </summary>
        public PointLatLng Point
        {
            get { return m_Point; }
            set { m_Point = value; }
        }

        /// <summary>
        /// Lat 
        /// </summary>
        [XmlAttribute("lat")]
        public double Lat
        {
            get { return m_Point.Lat; }
            set 
            {
                m_Point.Lat = value;
                m_State = PointState.LatLng;
            }
        }

        /// <summary>
        /// Lng 
        /// </summary>
        [XmlAttribute("lon")]
        public double Lng
        {
            get { return m_Point.Lng; }
            set 
            { 
                m_Point.Lng = value;
                m_State = PointState.LatLng;
            }
        }

        /// <summary>
        /// Alt 
        /// </summary>
        [XmlElement("ele")]
        public double Alt
        {
            get { return m_Alt; }
            set 
            { 
                m_Alt = value;
                m_State = PointState.LatLngAlt;
            }
        }

        /// <summary>
        /// Czas ustalenia punktu. Używany tylko dla GPX
        /// </summary>
        [XmlElement("time")]
        public DateTime Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }

        /// <summary>
        /// Status punktu
        /// </summary>
        public PointState State
        {
            get { return m_State; }
        }

        /// <summary>
        /// Tekstowa forma lat: 12.123456 N
        /// </summary>
        public string LatString
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0:0.000000} {1}", Math.Abs(Lat), Lat >= 0 ? "N" : "S"); }
        }

        /// <summary>
        /// Tekstowa forma lat bez referencji: 12.123456
        /// </summary>
        public string LatNoRef
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0:0.000000}", Math.Abs(Lat)); }
        }

        /// <summary>
        /// Czy lat North czy South
        /// </summary>
        public string LatRef
        {
            get { return Lat >= 0 ? "North" : "South"; }
        }

        /// <summary>
        /// Tekstowa forma lng: 12.123456 E
        /// </summary>
        public string LngString
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0:0.000000} {1}", Math.Abs(Lng), Lng >= 0 ? "E" : "W"); }
        }

        /// <summary>
        /// Tekstowa forma lng: 12.123456
        /// </summary>
        public string LngNoRef
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0:0.000000}", Math.Abs(Lng)); }
        }

        /// <summary>
        /// Czy lng East czy West
        /// </summary>
        public string LngRef
        {
            get { return Lng >= 0 ? "East" : "West"; }
        }

        /// <summary>
        /// Tekstowa forma alt: 1234 m Above Sea Level
        /// </summary>
        public string AltString
        {
            get { return string.Format("{0:0} m {1}", Math.Abs(Alt), AltRef); }
        }

        /// <summary>
        /// Tekstowa forma lat bez referencji: 12.123456
        /// </summary>
        public string AltNoRef
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0:0.000000}", Math.Abs(Alt)); }
        }

        /// <summary>
        /// Czy lng East czy West
        /// </summary>
        public string AltRef
        {
            get { return Alt >= 0 ? "Above Sea Level" : "Above Sea Level"; }
        }

        #endregion

        #region Metody statyczne

        /// <summary>
        /// Parsuje tekst z formatu 12.123456 N do double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static double parseSingleCoordinate(string s)
        {
            double d = 0.0;
            Match m = m_RegexLatLng1.Match(s);
            if (m.Success)
            {
                d = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                if (m.Groups[2].Value == "S" || m.Groups[2].Value == "W")
                {
                    d = d * -1;
                }
            }

            return d;
        }

        /// <summary>
        /// Parsuje string kolejno wg formatów:
        ///  1  =>  40.892433 N, 73.982871 W
        ///  2  =>  40.89243352315631, -73.98287154503505
        ///  3  =>  40°53'32.6"N 73°58'58.4"W
        /// </summary>
        /// <param name="s"></param>
        public static GPSPoint Parse(string s)
        {
            try
            {
                GPSPoint p = ParseRegex1(s);
                if (p.State != PointState.Empty)
                {
                    return p;
                }

                p = ParseRegex2(s);
                if (p.State != PointState.Empty)
                {
                    return p;
                }

                return ParseRegex3(s);
            }
            catch
            {
                return new GPSPoint();
            }
        }

        /// <summary>
        /// Parsuje string w formacie 40.892433 N, 73.982871 W
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static GPSPoint ParseRegex1(string s)
        {
            GPSPoint p = new GPSPoint();
            Match m = m_RegexLatLng1.Match(s);
            if (m.Success)
            {
                try
                {
                    double lat = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                    lat = m.Groups[2].Value == "N" ? lat : lat * -1;
                    double lng = double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture);
                    lng = m.Groups[4].Value == "E" ? lng : lng * -1;
                    p.Point = new PointLatLng(lat, lng);
                    p.m_State = PointState.LatLng;
                }
                catch { }
            }
            return p;
        }

        /// <summary>
        /// Parsuje string w formacie: 40.89243352315631, -73.98287154503505
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static GPSPoint ParseRegex2(string s)
        {
            GPSPoint p = new GPSPoint();
            Match m = m_RegexLatLng2.Match(s);
            if (m.Success)
            {
                try
                {
                    double lat = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                    double lng = double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
                    p.Point = new PointLatLng(lat, lng);
                    p.m_State = PointState.LatLng;
                }
                catch { }
            }

            return p;
        }

        /// <summary>
        /// Parsuje string w formacie: 40°53'32.6"N 73°58'58.4"W
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static GPSPoint ParseRegex3(string s)
        {
            GPSPoint p = new GPSPoint();
            Match m = m_RegexLatLng3.Match(s);
            if (m.Success)
            {
                try
                {
                    double lat =
                        double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture)               // Stopnie
                        + double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture) / 60        // Minuty
                        + double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture) / 3600;     // Sekundy
                    lat = m.Groups[4].Value == "N" ? lat : lat * -1;

                    double lng = 
                        double.Parse(m.Groups[5].Value, CultureInfo.InvariantCulture)
                        + double.Parse(m.Groups[6].Value, CultureInfo.InvariantCulture) / 60        // Minuty
                        + double.Parse(m.Groups[7].Value, CultureInfo.InvariantCulture) / 3600;     // Sekundy
                    lng = m.Groups[8].Value == "E" ? lng : lng * -1;

                    p.Point = new PointLatLng(lat, lng);
                    p.m_State = PointState.LatLng;
                }
                catch { }
            }

            return p;
        }

        /// <summary>
        /// Parser dla formatu: 1234 m Above the sea
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static double parseAltitude(string s)
        {
            double d = 0.0;
            Match m = m_RegexAlt1.Match(s);
            if (m.Success)
            {
                d = double.Parse(m.Groups[1].Value);
                if (m.Groups[2].Value == "B")
                {
                    d = d * -1;
                }
            }

            return d;
        }

        #endregion

        #region Konstruktor

        /// <summary>
        /// Domyślny konstruktor. Koordynatu zostaną ustawione na 0.000000, 0.0000000
        /// </summary>
        public GPSPoint()
        {
            m_Point = new PointLatLng(0, 0);
            m_Alt = 0;
            m_Time = DateTime.MinValue;
            m_State = PointState.Empty;
        }

        /// <summary>
        /// Konstryktor ustawiający tylko datę i czas punktu. 
        /// </summary>
        public GPSPoint(DateTime time)
        {
            m_Point = new PointLatLng(0, 0);
            m_Alt = 0;
            m_Time = time;
            m_State = PointState.Empty;
        }

        /// <summary>
        /// Konstruktor na podstawie punktu GMap
        /// </summary>
        /// <param name="point"></param>
        public GPSPoint(PointLatLng point)
        {
            m_Point = point;
            m_State = PointState.LatLng;
            m_Alt = 0;
            m_Time = DateTime.MinValue;
            m_State = PointState.LatLng;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        public GPSPoint(string lat, string lng)
        {
            try
            {
                Lat = parseSingleCoordinate(lat);
                Lng = parseSingleCoordinate(lng);
                m_Alt = 0.0;
                m_Time = DateTime.MinValue;
                m_State = PointState.LatLng;
            }
            catch 
            {
                Lat = 0;
                Lng = 0;
                m_Alt = 0.0;
                m_Time = DateTime.MinValue;
                m_State = PointState.Empty;
            }
        }

        public GPSPoint (SortedDictionary<string, string> properties) 
        {
            try
            {
                m_Alt = 0.0;
                // Rozpoznanie lat lng
                if (properties.ContainsKey("Composite:GPSLatitude") && properties.ContainsKey("Composite:GPSLongitude"))
                {
                    Lat = parseSingleCoordinate(properties["Composite:GPSLatitude"]);
                    Lng = parseSingleCoordinate(properties["Composite:GPSLongitude"]);
                }
                else if (properties.ContainsKey("Composite:GPSPosition"))
                {
                    GPSPoint p = Parse(properties["Composite:GPSPosition"]);
                    Point = p.Point;
                }

                m_State = PointState.LatLng;

                // Rozpoznanie alt
                if (properties.ContainsKey("Composite:GPSAltitude") && properties["Composite:GPSAltitude"] != string.Empty)
                {
                    Alt = parseAltitude(properties["Composite:GPSAltitude"]);
                    m_State = PointState.LatLngAlt;
                }
            }
            catch
            {
                Lat = 0;
                Lng = 0;
                m_Alt = 0.0;
                m_State = PointState.Empty;
            }
        }

        #endregion

        #region pomocnicze

        /// <summary>
        /// Zwraca tekstowy zapis koordynatów w formacie: 12.123456 N, 12.123456 E
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return LatString + ", " + LngString;
        }

        #endregion

    }
}
