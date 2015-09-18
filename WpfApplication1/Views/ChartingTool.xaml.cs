using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
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
using Abt.Controls.SciChart.Visuals;
using flc.FrontDoor.ViewModels;
using Framework.UI.Controls;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace flc.FrontDoor.Views
{
    /// <summary>
    /// Interaction logic for ChartingTool.xaml
    /// </summary>
    public partial class ChartingTool
    {
        public SciChartSurface SelectedChartController { get; set; }

        public ChartingTool()
        {
            InitializeComponent();
            DataContext = new MainChartViewModel (new DesignTimeChartService());
            
        }


        private void UIElement_OnPreviewMouseDown (object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ISciChartController)
            {
                SelectedChartController = (SciChartSurface) e.Source;
                AnnotationCommandPanel.DataContext = SelectedChartController.DataContext;
            }
        }

        private void ButtonBase_OnClick (object sender, RoutedEventArgs e)
        {
            SubmitButton.Tag = "TimeSeries";
        }

        private void ButtonBase2_OnClick (object sender, RoutedEventArgs e)
        {
            SubmitButton.Tag = "Curve";
        }

        private void CopySurfaceToClipboard(object sender, RoutedEventArgs e)
        {
            var bmp = SelectedChartController.ExportToBitmapSource();
            Clipboard.SetImage(bmp);
            
        }

        private void SaveChartToFile(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "png",
                AddExtension = true,
                Filter = "Png Files|*.png",
                InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Desktop)
            };
            if (dialog.ShowDialog() == true)
            {
                SelectedChartController.ExportToFile(dialog.FileName,ExportType.Png);
                Process.Start (dialog.FileName);
            }
        }
    }
}
