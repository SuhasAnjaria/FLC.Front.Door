using System;
using System.CodeDom;
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
using Abt.Controls.SciChart.Visuals;
using flc.FrontDoor.ViewModels;
using Framework.UI.Controls;
using GalaSoft.MvvmLight.Command;

namespace flc.FrontDoor.Views
{
    /// <summary>
    /// Interaction logic for ChartingTool.xaml
    /// </summary>
    public partial class ChartingTool
    {
        private SciChartSurface _a;

        public SciChartSurface SelectedChartController
        {
            get { return _a; }
            set { _a = value; }
        }

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

    }
}
