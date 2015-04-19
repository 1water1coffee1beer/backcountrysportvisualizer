using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace BackcountrySportVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.mainWindow.WindowState = WindowState.Maximized;

            this.map.MapProvider = GMapProviders.BingHybridMap;
            this.map.Manager.Mode = AccessMode.ServerAndCache;

            this.map.Position = new PointLatLng(39, -105.547222);

            this.map.MouseWheel += map_MouseWheel;
            this.topoRadio.Checked += topoRadio_Checked;
            this.bingRadio.Checked += bingRadio_Checked;
        }

        void bingRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.map.MapProvider = GMapProviders.BingHybridMap;
            this.topoRadio.IsChecked = false;
        }

        void topoRadio_Checked(object sender, RoutedEventArgs e)
        {
            this.map.MapProvider = GMapProviders.ArcGIS_Topo_US_2D_Map;
            this.bingRadio.IsChecked = false;
        }

        void map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int delta = e.Delta > 0 ? 1 : -1;

            int currentZoom = (int)this.map.Zoom;
            
            int maxzoom = this.map.MaxZoom;
            int minzoom = this.map.MinZoom;

            if (currentZoom + delta >= minzoom && currentZoom <= maxzoom)
            {
                this.map.Zoom = currentZoom + delta;
            }
        }
    }
}
