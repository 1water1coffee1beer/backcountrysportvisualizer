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
using DataObjects;
using System.Data.Entity;

namespace BackcountrySportVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RouteContext routeContext;
        private Dictionary<Type, bool> enabledDataTypesMap;

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

            this.routeContext = new RouteContext();

            this.InitData();
        }

        private void InitData()
        {
            var dataTypes = this.routeContext.Set<AbstractRoute>();
            
            this.enabledDataTypesMap = new Dictionary<Type,bool>(dataTypes.Count());

            foreach (var dataType in dataTypes)
            {
                CheckBox dataTypeCheck = new CheckBox { Tag = dataType.GetType(), IsChecked = true };
                dataTypeCheck.Checked += dataTypeCheck_Checked;
                dataTypeCheck.Unchecked += dataTypeCheck_Unchecked;

                this.mainWindow.grid.Children.Add(dataTypeCheck);

                this.enabledDataTypesMap.Add(dataType.GetType(), true);
            }
        }

        void dataTypeCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox dataCheck = (CheckBox)sender;
            Type dataType = (Type)dataCheck.Tag;
            this.enabledDataTypesMap[dataType] = false;
        }

        void dataTypeCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox dataCheck = (CheckBox)sender;
            Type dataType = (Type)dataCheck.Tag;
            this.enabledDataTypesMap[dataType] = true;
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
