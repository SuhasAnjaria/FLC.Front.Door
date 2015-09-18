using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Abt.Controls.SciChart;
using Abt.Controls.SciChart.Model.DataSeries;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Visuals.Annotations;
using Abt.Controls.SciChart.Visuals.Axes;
using Abt.Controls.SciChart.Visuals.PointMarkers;
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
        private DateTime _fromdate;
        private DateTime _todate;
        private string _seriesname;
        private string _chartindicator = "Curve";


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

        public string SeriesName
        {
            get { return this._seriesname; }
            set { this.SetProperty (ref _seriesname, value); }
        }

        public string ChartIndicator
        {
            get { return this._chartindicator; }
            set { this.SetProperty (ref _chartindicator, value); }
        }

        public DateTime FromDate
        {
            get { return this._fromdate; }
            set { this.SetProperty (ref _fromdate, value); }
        }

        public DateTime ToDate
        {
            get { return this._todate; }
            set { this.SetProperty (ref _todate, value); }
        }

        #endregion

        #region Command Implementations

        public RelayCommand<string> ChartIndicatorChangedCommand
        {
            get
            {
                return new RelayCommand<string> ((value) =>
                { this.ChartIndicator = value; });
            }
        }

        public RelayCommand GetChartCommand
        {
            get
            {
                if (ChartIndicator == "TimeSeries")
                {
                    return new RelayCommand (GetTimeSeries);
                }
                else if (ChartIndicator == "Curve")
                {
                    return new RelayCommand (GetCurveSeries);
                }
                else
                {
                    return null;
                }
            }
        }

        private void GetCurveSeries()
        {
            var curveSeries = _datamanager.GetCurveSeries (SeriesName, FromDate, ToDate);
            var chartlist = MakeCurveSeriesViewModel (curveSeries);
            Cu1ViewModel.ChartSeries.Add (chartlist[0]);
            Cu1ViewModel.ChartSeries.Add (chartlist[1]);
        }

        private void GetTimeSeries()
        {
            var timeSeries = _datamanager.GetTimeSeries (SeriesName, FromDate, ToDate);
            Ts1ViewModel.ChartSeries.Add (MakeTimeSeriesViewModel (timeSeries));
        }

        #endregion



        #region Chart Width Properties

        public string Row1Height { get; set; }
        public string Row2Height { get; set; }
        public string Row3Height { get; set; }
        public string Column1Width { get; set; }
        public string Column2Width { get; set; }

        #endregion



        public MainChartViewModel (IChartDataService dataService)

        {
            this.SeriesName = "ABC";
            this.ToDate = DateTime.Today;
            this.FromDate = DateTime.Today.AddYears (-1);
            ChartWidthsSetter.SetWidths (this, 2);
            Ts1ViewModel = new TimeSeriesViewModel();
            Ts2ViewModel = new TimeSeriesViewModel();
            Cu1ViewModel = new CurveViewModel();
            Cu2ViewModel = new CurveViewModel();
            _datamanager = dataService;
            _viewportManager = new FlcViewPortManager();
            GetTimeSeries();
            GetCurveSeries();
        }

        



        #region Helper Functions

        public ChartSeriesViewModel MakeTimeSeriesViewModel (IDataSeries dataSeries)
        {

            FastLineRenderableSeries a = new FastLineRenderableSeries
            {
                SeriesColor = DefaultChartTemplate.GetNextColor(),
                YAxisId = this.Ts1ViewModel.YAxisCollection[0].Id,
            };
            return new ChartSeriesViewModel (dataSeries, a);
        }

        public List<ChartSeriesViewModel> MakeCurveSeriesViewModel (IDataSeries dataSeries)
        {


            var output = new List<ChartSeriesViewModel>();
            FastLineRenderableSeries A = new FastLineRenderableSeries
            {
                SeriesColor = DefaultChartTemplate.GetNextColor(),
                IsHitTestVisible = false,
                YAxisId = Cu1ViewModel.YAxisCollection[0].Id
            };
            ChartSeriesViewModel temp = new ChartSeriesViewModel (dataSeries, A);
            output.Add (temp);
            XyScatterRenderableSeries B = new XyScatterRenderableSeries
            {
                SeriesColor = DefaultChartTemplate.GetNextColor(),
                PointMarker = DefaultChartTemplate.GetNextPointMarker(),
                YAxisId = this.Cu1ViewModel.YAxisCollection[0].Id
            };
            temp = new ChartSeriesViewModel (dataSeries, B);
            output.Add (temp);
            return output;
        }

        #endregion

    }

    public class TimeSeriesViewModel : BaseChartViewModel
    {
        public TimeSeriesViewModel()
        {
                ChartSeries = new ObservableCollection<IChartSeriesViewModel>();
                YAxisCollection = new ObservableCollection<AxisViewModel>();
            AnnotationViewModel = new AnnotationViewModel(this);
            YAxisCollection.Add(new AxisViewModel()
            {
                AxisAlignment = AxisAlignment.Left,
                Title = "TestYAxis",
                VisibleRange = new DoubleRange(0, 10),
                Id = "PrimaryAxis"
            });
            
        }

       
    }

    public class CurveViewModel : BaseChartViewModel
    {
        //TODO: Talk to Ahmad about default maturities
        private readonly string[] initializer = new string [50];
        
        public ILabelProvider CurveLabels
        {
            get { return this._curvelabels; }
            set { this.SetProperty (ref _curvelabels, value); }
        }

        public CurveViewModel()
        {
            ChartSeries = new ObservableCollection<IChartSeriesViewModel>();
            YAxisCollection = new ObservableCollection<AxisViewModel>();
            AnnotationViewModel = new AnnotationViewModel(this);
            YAxisCollection.Add(new AxisViewModel()
            {
                AxisAlignment = AxisAlignment.Left,
                Title = "TestYAxis",
                VisibleRange = new DoubleRange(0, 10),
                Id = "PrimaryAxis"
            });
            for (int i = 0; i <50;i++)
            {
                initializer[i] = String.Format ("Y{0}", i);
            }
            CurveLabels = new CurveLabelProvider(initializer);
        }
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

    public abstract class BaseChartViewModel : BaseViewModel, IChartViewModel,IInjectSciChartController
    {
        // ReSharper disable once InconsistentNaming
        public ILabelProvider _curvelabels;
        public ObservableCollection<IChartSeriesViewModel> ChartSeries { get; set; }

        public bool IsParentSurfaceVisible { get; set; }

        public AnnotationViewModel AnnotationViewModel { get; set; }

        public ObservableCollection<LegendViewModel> ChartLegendViewModels { get; set; }

        public ObservableCollection<AxisViewModel> YAxisCollection { get; set; }

        public ISciChartController ParentSurface { get; set; }
    }

    public class AnnotationViewModel : BaseViewModel
    {
     private readonly BaseChartViewModel _basechart;  
        public AnnotationViewModel(BaseChartViewModel basechart)
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

        public RelayCommand DeleteAnnotationCommand
        {
            get
            {
                return new RelayCommand(DeleteAnnotation);
            }
        }

        private void DeleteAnnotation()
        {
            using (var ased = _basechart.ParentSurface.SuspendUpdates())
            {
                for (var count = ChartAnnotations.Count - 1; count >= 0; count--)
                {
                    if (ChartAnnotations.ElementAt(count).IsSelected)
                    {
                        ChartAnnotations.RemoveAt(count);
                    }
                }    
            }
            
        }

        private void AddAnnotation (string type)
        {
           using (var ased= _basechart.ParentSurface.SuspendUpdates())
           {
            Type a = DefaultChartTemplate.AnnotationTypes[type];

            if (a != null)
            {
                var annotaion = Activator.CreateInstance (a) as AnnotationBase;
                
                 annotaion.IsEditable = true;
                annotaion.CanEditText = true;
                
                annotaion.YAxisId = _basechart.YAxisCollection[0].Id;
                annotaion.Name = type; 
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

        public Task<IDataSeries> GetAbc()
        {
            return null;
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
            var curve = new XyDataSeries<double,double>();
            
            curve.Append(data.OpenData.GetDoubleRange()
             
            ,data.OpenData);
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

    public class DefaultChartTemplate
    {
        private static int _i =-1;
        private static int _j = -1;
        public static Dictionary<string, Type> AnnotationTypes = new Dictionary<string, Type>()
        {
            {"TextAnnotation", typeof (TextAnnotation)},
            {"ArrowAnnotation", typeof (LineArrowAnnotation)},
            {"BoxAnnotation", typeof (BoxAnnotation)},
            {"HorizontalLineAnnotation", typeof (HorizontalLineAnnotation)},
           // {"VerticalMarkerAnnotation", typeof (VerticalLineAnnotation)},
            {"HorizontalThreshold", typeof (HorizontalLineAnnotation)},
            {"VerticalThreshold" ,typeof(VerticalLineAnnotation)}
        };

        public static  List<Color> StandardColors = new List<Color>()
        {
            Color.FromArgb (231, 16, 201, 220),
            Color.FromArgb(231, 12, 138, 31),
            Color.FromArgb(183, 158, 0, 197),
            Color.FromArgb(255, 240, 166, 15),
            Color.FromArgb(231, 69, 13, 179),
           Color.FromArgb(231, 220, 16, 16),
           Color.FromArgb(231, 80, 253, 9),
           Color.FromArgb(231, 25, 5, 245),
           Color.FromArgb(231, 40, 131, 255),
           Color.FromArgb(209, 87, 88, 91),
           Color.FromArgb(255, 50, 198, 95)


        }; 
       
        public static List<BasePointMarker> StandardPointMarkers = new List<BasePointMarker>
        {
            new CrossPointMarker(),
            new EllipsePointMarker(),
            new SquarePointMarker(),
            new TrianglePointMarker(),
            
        }; 

        public static Color GetNextColor()
        {
            if (_i <= StandardColors.Count - 1)
            {
                _i++;
                return StandardColors[_i];
                
            }
            else
            {
                _i = -1;
                return StandardColors[_i++];
            }
        }

        public static BasePointMarker GetNextPointMarker()
        {
            if (_j <= StandardPointMarkers.Count - 1)
            {
                _j++;
                return StandardPointMarkers[_i];

            }
            else
            {
                _j = -1;
                return StandardPointMarkers[_j++];
            }
        }

    }

   

    
}
