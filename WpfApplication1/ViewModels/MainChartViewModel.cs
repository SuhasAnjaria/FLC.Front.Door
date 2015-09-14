using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Abt.Controls.SciChart;
using GalaSoft.MvvmLight;
using Abt.Controls.SciChart.ChartModifiers;
using Abt.Controls.SciChart.Model.DataSeries;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Visuals.Annotations;
using Abt.Controls.SciChart.Visuals.Axes;
using Abt.Controls.SciChart.Visuals.RenderableSeries;
using flc.FrontDoor.Assets;
using flc.FrontDoor.NonDBData;
using GalaSoft.MvvmLight.Command;


namespace flc.FrontDoor.ViewModels
{
    public class MainChartViewModel:BaseViewModel
    {
        #region Fields

        private BaseChartViewModel _ts1ViewModel;
        private BaseChartViewModel _ts2ViewModel;
        private BaseChartViewModel _cu1ViewModel;
        private BaseChartViewModel _cu2ViewModel;
        private IChartDataService _datamanager;
        private IViewportManager _viewportManager;

        #endregion

        #region Properties
        
        public BaseChartViewModel Ts1ViewModel
        {
            get { return this._ts1ViewModel; }
            set { this.SetProperty (ref this._ts1ViewModel, value); }
        }

        public BaseChartViewModel Ts2ViewModel
        {
            get { return this._ts2ViewModel; }
            set { this.SetProperty (ref this._ts2ViewModel, value); }
        }

        public BaseChartViewModel Cu1ViewModel
        {
            get { return this._cu1ViewModel; }
            set { this.SetProperty (ref this._cu1ViewModel, value); }
        }

        public BaseChartViewModel Cu2ViewModel
        {
            get { return this._cu2ViewModel; }
            set { this.SetProperty (ref this._cu2ViewModel, value); }
        }

        public IViewportManager ViewportManager
        {
            get { return _viewportManager; }
            set { this.SetProperty (ref _viewportManager, value); }
        }
        #endregion

        public string Row1Height { get; set; }
        public string Row2Height { get; set; }
        public string Row3Height { get; set; }
        public string Column1Width { get; set; }
        public string Column2Width { get; set; }

        public MainChartViewModel()
        {
            
        }

        public MainChartViewModel (IChartDataService dataService)
            
        {
           ChartWidthsSetter.SetWidths(this,1);
            Ts1ViewModel= new TimeSeriesViewModel();
            _datamanager = dataService;
            _viewportManager = new FlcViewPortManager();




            Ts1ViewModel.YAxisCollection.Add(new AxisViewModel()
            {
                AxisAlignment = AxisAlignment.Left,
                Title = "TestYAxis",
                VisibleRange = new DoubleRange(0, 10),
                Id = "TestAxisID"

            });
            Ts1ViewModel.YAxisCollection.Add(new AxisViewModel()
            {
                AxisAlignment = AxisAlignment.Right,
                Title = "TestYAxis",
                VisibleRange = new DoubleRange(0, 10),
                Id = "TestAxisIDSecondary"

            });
           
            
            Ts1ViewModel.ChartSeries.Add(new ChartSeriesViewModel(_datamanager.GetTimeSeriesdouble("fake", DateTime.Now, DateTime.Now), new FastLineRenderableSeries()
            {
                SeriesColor = Color.FromRgb(17, 172, 203) ,
                YAxisId = this.Ts1ViewModel.YAxisCollection[0].Id 
            }));
            Ts1ViewModel.ChartSeries.Add(new ChartSeriesViewModel(_datamanager.GetTimeSeries("fake",DateTime.Now, DateTime.Now),new FastLineRenderableSeries()
            {
                SeriesColor = Color.FromArgb(231, 12, 138, 31),
                YAxisId = this.Ts1ViewModel.YAxisCollection[1].Id 
                

               
            }));
   
           
            
        }
    }

    public class TimeSeriesViewModel : BaseChartViewModel,IInjectSciChartController
    {
        public TimeSeriesViewModel()
        {
                ChartSeries = new ObservableCollection<IChartSeriesViewModel>();
                YAxisCollection = new ObservableCollection<AxisViewModel>();
            AnnotationViewModel = new AnnotationViewModel(this);
            
        }

        #region Implementation of IInjectSciChartController

        public ISciChartController ParentSurface { get; set; }

        #endregion
    }

    public class CurveViewModel : BaseChartViewModel
    {

    }

    public interface IChartViewModel
    {
         ObservableCollection<IChartSeriesViewModel> ChartSeries { get; set; }
         bool IsParentSurfaceVisible { get; set; }
         AnnotationViewModel AnnotationViewModel { get; set; }
         ObservableCollection<LegendViewModel> ChartLegendViewModels { get; set; }
        ObservableCollection<AxisViewModel> YAxisCollection { get; set; }
        
    }

    interface IChartProperties
    {
        bool ShowChartTitle { get; set; }
        string ChartTitle { get; set; }
        bool DrawGridlines { get; set; }
        bool DrawLables { get; set; }
        bool ShowLegend { get; set; }

 

    }

    public abstract class BaseChartViewModel : BaseViewModel, IChartViewModel
    {
        
        public ObservableCollection<IChartSeriesViewModel> ChartSeries { get; set; }

        public bool IsParentSurfaceVisible { get; set; }

        public AnnotationViewModel AnnotationViewModel { get; set; }

        public ObservableCollection<LegendViewModel> ChartLegendViewModels { get; set; }

        public ObservableCollection<AxisViewModel> YAxisCollection { get; set; }
        
       


       
    }

    public class AnnotationViewModel : BaseViewModel
    {
     private readonly TimeSeriesViewModel _basechart;  
        public AnnotationViewModel(TimeSeriesViewModel basechart)
        {
            _basechart = basechart;
         ChartAnnotations = new AnnotationCollection();       
        }
        private AnnotationCollection _chartAnnotationCollection;
        public AnnotationCollection ChartAnnotations { get  {return _chartAnnotationCollection; }
            set { this.SetProperty (ref _chartAnnotationCollection, value); } }

        public RelayCommand<string> AddAnnotationCommand
        {
            get
            {
                
               
                    return new RelayCommand<string>(AddAnnotation);
                
            }
        }

        private void AddAnnotation (string type)
        {
           using (var ased= _basechart.ParentSurface.SuspendUpdates())
           {
            Type a = AnnotationDict.AnnotationTypes[type];

            if (a != null)
            {
                var annotaion = Activator.CreateInstance (a) as AnnotationBase;
                
                 annotaion.IsEditable = true;
                annotaion.CanEditText = true;
                
                annotaion.YAxisId = _basechart.YAxisCollection[0].Id;
                
                ChartAnnotations.Add (annotaion);

                
               
            }
        }

    }
    }
    
    public class LegendViewModel : BaseViewModel
    {
        //TODO
    }

    public class AxisViewModel : BaseViewModel
    {
        private IRange _visiblerange;
        private string _title;
        private AutoRange _autorange;
        private string _axisId;
        private AxisAlignment _axisalignment;

        public IRange VisibleRange
        {
            get { return this._visiblerange; }
            set { this.SetProperty (ref _visiblerange, value); }
        }

        public string Id
        {
            get { return this._axisId; }
            set { this.SetProperty (ref _axisId, value); }
        }

        public string Title
        {
            get { return this._title; }
            set { this.SetProperty (ref _title, value); }
        }

        public AxisAlignment AxisAlignment
        {
            get { return _axisalignment; }
            set { this.SetProperty (ref _axisalignment, value); }
        }
    }



    public class FlcViewPortManager : DefaultViewportManager
    {
        protected override IRange OnCalculateNewYRange (IAxis yAxis, RenderPassInfo renderPassInfo)
        {
            var rawAutorange = base.OnCalculateNewYRange (yAxis, renderPassInfo);
            return rawAutorange.GrowBy (0.1, 0.1);
        }
        
    }

    public interface IChartDataService
    {
        IDataSeries GetTimeSeries (string seriesname, DateTime from, DateTime to);
        IDataSeries GetTimeSeriesdouble(string seriesname, DateTime from, DateTime to);
        IDataSeries GetCurveSeries (string seriesname, DateTime from, DateTime to);
    }
    
    public class ChartDataService:IChartDataService
    {
        public IDataSeries GetTimeSeries(string seriesname, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IDataSeries GetCurveSeries(string seriesname, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }


        public IDataSeries GetTimeSeriesdouble(string seriesname, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }

    public class DesignTimeChartService : IChartDataService
    {

        public IDataSeries GetTimeSeries(string seriesname, DateTime from, DateTime to)
        {
            var b = new RandomWalkGenerator(500);
            var data = b.GetRandomWalkSeries (1000);
            var series = new XyDataSeries<double, double>();
            series.Append(data.XData.Select(p=>p).ToList(),data.YData);
            return series;
        }

        public IDataSeries GetTimeSeriesdouble (string seriesname, DateTime from, DateTime to)
        {
            var v = new RandomWalkGenerator(2);
            var data = v.GetRandomWalkSeries (2000);
            var series = new XyDataSeries<double,double>();
            series.Append(data.XData.Select(p=>p).ToList(),data.YData);
            return series;
        }

        public IDataSeries GetCurveSeries(string seriesname, DateTime from, DateTime to)
        {
            var b = new RandomWalkGenerator(2);
            var data = b.GetRandomCurveSeries();
            var curve = new XyDataSeries<DateTime,double>();
            curve.Append(data.TimeData,data.OpenData);
            return curve;
        }
    }

    public class ChartWidthsSetter
    {
        public static void SetWidths (MainChartViewModel vm, int settingnumber)
        {
            switch (settingnumber)
            {
                //Top Left Only
                case 1:
                {
                    vm.Row1Height = "*";
                    vm.Row2Height = "0";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "*";
                    vm.Column2Width = "0";
                    break;
                }
                    //Row 1 & 2 only
                case 2:
                {
                    vm.Row1Height = "*";
                    vm.Row2Height = "*";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "*";
                    vm.Column2Width = "0";
                    break;
                }
                    //Row 1,2 & Column
                case 3:
                {
                    vm.Row1Height = "*";
                    vm.Row2Height = "*";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "*";
                    vm.Column2Width = "*";
                    break;
                }
                    //Bottom Left Only
                case 4:
                {
                    vm.Row1Height = "0";
                    vm.Row2Height = "*";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "*";
                    vm.Column2Width = "0";
                    break;
                }
                    // Top Right Only
                case 5:
                {
                    vm.Row1Height = "*";
                    vm.Row2Height = "0";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "0";
                    vm.Column2Width = "*";
                    break;
                }
                // Bottom Right Only
                case 6:
                {
                    vm.Row1Height = "0";
                    vm.Row2Height = "*";
                    vm.Row3Height = "0.5*";
                    vm.Column1Width = "0";
                    vm.Column2Width = "*";
                    break;
                }
            }   
        }
    }

    public class AnnotationDict
    {
        public static Dictionary<string, Type> AnnotationTypes = new Dictionary<string, Type>()
        {
            {"TextAnnotation", typeof (TextAnnotation)},
            {"ArrowAnnotation", typeof (LineArrowAnnotation)},
            {"BoxAnnotation", typeof (BoxAnnotation)},
            {"HorizontalLineAnnotation", typeof (HorizontalLineAnnotation)},
            {"VerticalMarkerAnnotation", typeof (VerticalLineAnnotation)},
            {"HorizontalThreshold", typeof (HorizontalLineAnnotation)}
        };

        
        

    }
}
