using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using WinExifTool.Utils;

namespace WinExifTool
{

    public partial class frmMap : Form
    {
        #region Struktury i enumeracje 

        enum ZoomType : int
        {
            NoChange = 0,
            Point = 1,
            Markers = 2
        }

        public struct ClickPoint
        {
            public static readonly int MAXDISTANCE = 3;
            public static readonly int MAXTICKS = 300;
            public Point P;
            public long T;
            public ClickPoint(int x, int y)
            {
                P = new Point();
                P.X = x;
                P.Y = y;
                T = DateTime.Now.Ticks;
            }

            public bool IsDoubleClick(Point location)
            {
                bool status = Math.Abs(P.X - location.X) < MAXDISTANCE && Math.Abs(P.Y - location.Y) < MAXDISTANCE && DateTime.Now.Ticks - T < MAXTICKS;
                P = location;
                T = DateTime.Now.Ticks;
                return status;
            }
        }

        #endregion

        #region Zmienne prywatne

        GMapOverlay m_Markers;
        GMapOverlay m_Path;
        private List<DS.FilesRow> m_Files = new List<DS.FilesRow>();
        private DS.FilesRow m_CurrentRow;
        private frmMain m_MainForm;
        private ClickPoint m_ClickPoint;
        private GPX m_GPX;

        #endregion

        #region Właściwości

        /// <summary>
        /// Files 
        /// </summary>
        public List<DS.FilesRow> Files
        {
            get { return m_Files; }
            set
            {
                if (m_Files.GetHashCode() == value.GetHashCode())
                {
                    return;
                }
                m_Files = value;
                RebuildMarkers(ZoomType.Markers);
                tsMessage.Text = string.Format("Ilość plików: {0}", Files.Count);
                miAllTagged.Text = string.Format("Zaznaczone pliki ({0})", Files.Count);
                miGpxAllTagged.Text = string.Format("Zaznaczone pliki ({0})", Files.Count);
            }
        }

        /// <summary>
        /// Current 
        /// </summary>
        public DS.FilesRow CurrentRow
        {
            get { return m_CurrentRow; }
            set { 
                m_CurrentRow = value;
                tsCurrent.Text = string.Format("Bieżący plik: {0}", m_CurrentRow.FileName);
                RebuildMarkers(ZoomType.Point);
            }
        }

        /// <summary>
        /// MainForm 
        /// </summary>
        public frmMain MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        #endregion

        #region Konstruktor, Load, Close

        public frmMap()
        {
            InitializeComponent();
            m_ClickPoint = new ClickPoint(0, 0);
            GMap.NET.MapProviders.GoogleMapProvider.Instance.ApiKey = Properties.Settings.Default.GOOGLE_APIKEY;
            
            switch(Properties.Settings.Default.MapProvider)
            {
                case "GoogleMapProvider":
                    map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    break;
                case "CzechTuristMapProvider":
                    map.MapProvider = GMap.NET.MapProviders.CzechTuristMapProvider.Instance;
                    break;
                default:
                    tsMessage.Text = "Nierozpoznany Map Provider";
                    break;
            }

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.DragButton = MouseButtons.Left;
            map.Zoom = Properties.Settings.Default.frmMap_LastZoom;
            map.Position = GPSPoint.Parse(Properties.Settings.Default.frmMap_LastPos).Point;
            map.ShowCenter = false;
            m_Markers = new GMapOverlay("markers");
            m_Path = new GMapOverlay("path");
            map.Overlays.Add(m_Markers);
        }

        private void frmMap_Load(object sender, EventArgs e)
        {
            LoadTimezones();
        }

        private void frmMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_MainForm.MapForm = null;
        }

        private void LoadTimezones()
        {
            ReadOnlyCollection<TimeZoneInfo> zoneList = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZoneInfo in zoneList)
            {
                tsTimezone.Items.Add(timeZoneInfo);
                if (timeZoneInfo.Id == TimeZoneInfo.Local.Id)
                {
                    tsTimezone.SelectedItem = timeZoneInfo;
                }
            }

        }

        #endregion

        #region Map

        private void map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng point = map.FromLocalToLatLng(e.X, e.Y);
                map.Position = point;
                map.Zoom += 1;
            }
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (m_ClickPoint.IsDoubleClick(e.Location))
                {
                    map_MouseDoubleClick(sender, e);
                    return;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                m_ClickPoint.P = e.Location;
                mapContextMenu.Show(map, e.Location);
            }
        }

        private void RebuildMarkers(ZoomType zoomType)
        {
            m_Markers.Clear();
            GPSPoint point = new GPSPoint();

            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType markerType = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.gray_small;

                if (metadata.Changes.ContainsKey("Composite:GPSPosition"))
                {
                    point = GPSPoint.Parse(metadata.Changes["Composite:GPSPosition"]);
                    markerType = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small;
                }
                else if (metadata.Properties.ContainsKey("Composite:GPSPosition") )
                {
                    point = GPSPoint.Parse(metadata.Properties["Composite:GPSPosition"]);
                    markerType = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.gray_small;
                }

                if (point.State != GPSPoint.PointState.Empty)
                {
                    if (CurrentRow != null && CurrentRow.FileName == row.FileName)
                    {
                        markerType = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_small;
                    }

                    GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(point.Point, markerType);
                    marker.ToolTipText = row.FileName;
                    marker.Tag = row.FilePath;
                    marker.ToolTip.Fill = Brushes.Black;
                    marker.ToolTip.Foreground = Brushes.White;
                    marker.ToolTip.Stroke = Pens.Black;
                    marker.ToolTip.TextPadding = new Size(20, 20);

                    m_Markers.Markers.Add(marker);
                }
            }

            if (!tsFixPos.Checked && point.State != GPSPoint.PointState.Empty)
            {
                if (zoomType == ZoomType.Point || Files.Count == 1)
                {
                    map.Position = point.Point;
                    map.Zoom = 14;
                }
                else if (zoomType == ZoomType.Markers)
                {
                    map.ZoomAndCenterMarkers("markers");
                }
                SavePos();
            }
        }

        private void map_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            string path = item.Tag.ToString();
            m_MainForm.SelectRowByPath(path);
        }

        protected void SavePos()
        {
            GPSPoint p = new GPSPoint(map.Position);
            Properties.Settings.Default.frmMap_LastPos = p.ToString();
            Properties.Settings.Default.frmMap_LastZoom = (int)map.Zoom;
        }

        #endregion

        #region Toolbar

        private void tsFind_Click(object sender, EventArgs e)
        {
            tsMessage.Text = "";
            if (tsKeyword.Text != string.Empty)
            {
                // Rozpoznaj, czy nie zostały podane współrzędne
                GPSPoint p = GPSPoint.Parse(tsKeyword.Text);
                if (p.State != GPSPoint.PointState.Empty)
                {
                    map.Position = p.Point;
                    return;
                }

                GeoCoderStatusCode status = map.SetPositionByKeywords(tsKeyword.Text);
                if (status != GeoCoderStatusCode.OK)
                {
                    tsMessage.Text = status.ToString();
                }
            }
        }

        private void tsFixPos_Click(object sender, EventArgs e)
        {
            tsFixPos.Checked = !tsFixPos.Checked;
        }

        private void btnLoadGpx_Click(object sender, EventArgs e)
        {
            DialogResult r = dlgOpenGpx.ShowDialog();
            if (r == DialogResult.Cancel)
            {
                return;
            }

            m_GPX = GPX.Deserialize(dlgOpenGpx.FileName);
            if (m_GPX.StartDate > DateTime.MinValue)
            {
                miGpxAllTagged.Enabled = true;
                miGpxCurrent.Enabled = true;
                miGpxNoGPS.Enabled = true;

                // Narysuj ścieżkę
                m_Path.Clear();
                GMapRoute route = new GMapRoute("path");
                route.Stroke.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                route.Stroke.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                route.Stroke = new Pen(Brushes.Red, 2);                 //width and color of line
                foreach (GPSPoint p in m_GPX.PointCollection.Points)
                {
                    route.Points.Add(p.Point);
                }
                m_Path.Routes.Add(route);
                map.Overlays.Add(m_Path);
                map.ZoomAndCenterRoute(route);
            }
        }

        private void tsKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsFind_Click(sender, e);
            }
        }

        #endregion

        #region Zoom

        private void tsZoomOut_Click(object sender, EventArgs e)
        {
            map.Zoom -= 2;
        }

        private void tsZoomIn_Click(object sender, EventArgs e)
        {
            map.Zoom += 1;
        }

        #endregion

        #region Menu kontekstowe (ustawianie znacznika)

        private void miCurrent_Click(object sender, EventArgs e)
        {
            if (CurrentRow != null)
            {
                Metadata metadata = new Metadata(CurrentRow);
                SetLocation(metadata, m_ClickPoint.P);
                RebuildMarkers(ZoomType.Point);
            }
        }

        private void miNoGPS_Click(object sender, EventArgs e)
        {
            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                string gpsposition = metadata.Get("Composite:GPSPosition");

                if ( gpsposition == string.Empty )
                {
                    SetLocation(metadata, m_ClickPoint.P);
                }
            }
            RebuildMarkers(ZoomType.NoChange);
        }

        private void miAllTagged_Click(object sender, EventArgs e)
        {
            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                SetLocation(metadata, m_ClickPoint.P);
            }
            RebuildMarkers(ZoomType.NoChange);
        }

        private void SetLocation(Metadata metadata, Point location)
        {
            // Odczytanie pozycji
            PointLatLng point = map.FromLocalToLatLng(location.X, location.Y);
            GPSPoint gps = new GPSPoint(point);

            // Zapisanie lokalizacji
            metadata.Set("Composite:GPSPosition", gps.ToString());

            // Ustawienie lub usunięcie wysokości
            metadata.Set("Composite:GPSAltitude", gps.State == GPSPoint.PointState.LatLngAlt ? gps.AltString : string.Empty);

            //
            metadata.BuildFilesRow();
        }

        #endregion

        #region Menu kontekstowe (geokodowanie)

        private void miGpxAllTagged_Click(object sender, EventArgs e)
        {
            if (m_GPX == null)
            {
                return;
            }

            foreach (DS.FilesRow row in m_Files)
            {
                Geocode(row);
            }
            RebuildMarkers(ZoomType.NoChange);
        }

        private void miGpxCurrent_Click(object sender, EventArgs e)
        {
            if (m_GPX == null)
            {
                return;
            }

            if (CurrentRow != null)
            {
                Geocode(CurrentRow);
                RebuildMarkers(ZoomType.Point);
            }
        }

        private void miGpxNoGPS_Click(object sender, EventArgs e)
        {
            if (m_GPX == null)
            {
                return;
            }

            foreach (DS.FilesRow row in Files)
            {
                Metadata metadata = new Metadata(row);
                if (!metadata.Contains("Composite:GPSPosition"))
                {
                    Geocode(row);
                }
            }
            RebuildMarkers(ZoomType.NoChange);
        }

        private void Geocode(DS.FilesRow row)
        {
            DateTime time = row.CreateDate.ToUniversalTime();
            GPSPoint p = m_GPX.FindByTime(time);
            if (p.State != GPSPoint.PointState.Empty)
            {
                Metadata metadata = new Metadata(row);

                // Zapisanie lokalizacji
                metadata.Set("Composite:GPSPosition", p.ToString());
                if (p.State == GPSPoint.PointState.LatLngAlt)
                {
                    metadata.Set("Composite:GPSAltitude", p.AltString);
                }

                metadata.BuildFilesRow();
            }
        }

        #endregion

    }
}
