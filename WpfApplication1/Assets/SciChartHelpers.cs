using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Abt.Controls.SciChart;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Visuals.Axes;
using flc.FrontDoor.ViewModels;

namespace flc.FrontDoor.Assets
{
       
    public interface IInjectSciChartController
    {
        ISciChartController ParentSurface { get; set; }
    }
    /// <summary>
    /// Inject Scichart surface into view model. Attached property
    /// </summary>
    public class Injector
    {
        public static readonly DependencyProperty PassSurfaceToViewModelProperty = DependencyProperty.RegisterAttached(
            "PassSurfaceToViewModel", typeof(bool), typeof(Injector), new PropertyMetadata(default(bool), OnPassSurfaceToViewModelPropertyChanged));

        private static void OnPassSurfaceToViewModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scs = d as SciChartSurface;
            if (scs == null || ((bool)e.NewValue) == false) return;

            scs.DataContextChanged += (s, arg) => UpdateProperty(scs, scs.DataContext as IInjectSciChartController);

            UpdateProperty(scs, scs.DataContext as IInjectSciChartController);
        }

        private static void UpdateProperty(SciChartSurface scs, IInjectSciChartController vm)
        {
            if (vm == null) return;
            vm.ParentSurface = scs;
        }

        public static void SetPassSurfaceToViewModel(DependencyObject element, ISuspendable value)
        {
            element.SetValue(PassSurfaceToViewModelProperty, value);
        }

        public static bool GetPassSurfaceToViewModel(DependencyObject element)
        {
            return (bool)element.GetValue(PassSurfaceToViewModelProperty);
        }
    }

    public class YAxesCollectionBehaviour
    {
        /// <summary>
        /// Defines the AxisSource dependency property, which binds to an ObservableCollection of AxisViewModel and updates the SciChartSurface YAxes collection as the viewmodel collection changes
        /// </summary>
        public static readonly DependencyProperty AxisSourceProperty = DependencyProperty.RegisterAttached(
            "AxisSource", typeof(ObservableCollection<AxisViewModel>), typeof(YAxesCollectionBehaviour), new PropertyMetadata(default(ObservableCollection<AxisViewModel>), OnAxisSourceChanged));

        public static void SetAxisSource(DependencyObject element, ObservableCollection<AxisViewModel> value)
        {
            element.SetValue(AxisSourceProperty, value);
        }

        public static ObservableCollection<AxisViewModel> GetAxisSource(DependencyObject element)
        {
            return (ObservableCollection<AxisViewModel>)element.GetValue(AxisSourceProperty);
        }

        /// <summary>
        /// Defines the AxisStyle dependency property, which is a global style to apply to all generated Axis
        /// </summary>
        public static readonly DependencyProperty AxisStyleProperty = DependencyProperty.RegisterAttached(
            "AxisStyle", typeof(Style), typeof(YAxesCollectionBehaviour), new PropertyMetadata(default(Style), OnAxisStyleChanged));

        public static void SetAxisStyle(DependencyObject element, Style value)
        {
            element.SetValue(AxisStyleProperty, value);
        }

        public static Style GetAxisStyle(DependencyObject element)
        {
            return (Style)element.GetValue(AxisStyleProperty);
        }

        private static void OnAxisStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scs = d as SciChartSurface;
            if (scs == null) return;

            var axisStyle = e.NewValue as Style;

            // On AxisStyle changed, apply the new style to all existing Axis in the collection
            foreach (var axis in scs.YAxes.Cast<AxisBase>())
            {
                axis.Style = axisStyle;
            }
        }

        // When the ObservableCollection of AxisViewModels is changed (new instance), subscribe to collection changed events
        private static void OnAxisSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scs = d as SciChartSurface;
            if (scs == null) return;

            var newCollection = e.NewValue as ObservableCollection<AxisViewModel>;
            var axisStyle = YAxesCollectionBehaviour.GetAxisStyle(scs);

            if (newCollection != null)
            {
                // Subscribe to ObservableCollection<AxisViewModel> collection changes to synchronize axes 
                newCollection.CollectionChanged += (s, arg) => OnAxisViewModelCollectionChanged(newCollection, scs.YAxes, arg, axisStyle);

                // Force rebuilding of axes on the destination
                OnAxisViewModelCollectionChanged(newCollection, scs.YAxes, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset), axisStyle);
            }

            // TODO: Exercise for the reader. Handle collection swapped out when e.OldValue != null and unsubscribe collection changed events
        }

        // When the ObservableCollection of AxisViewModels changes, create and bind new Axis instances
        private static void OnAxisViewModelCollectionChanged(ObservableCollection<AxisViewModel> source, AxisCollection destination, NotifyCollectionChangedEventArgs e, Style axisStyle)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // Complete reset of ObservableCollection. Rebuild the axis collection
                destination.Clear();
                foreach (var axisViewModel in source)
                {
                    destination.Add(CreateAndBindAxis(axisViewModel, axisStyle));
                }
            }

            if (e.OldItems != null)
            {
                // Items removed, remove the corresponding axes
                var avmList = e.OldItems.Cast<AxisViewModel>().ToList();
                for (int i = destination.Count - 1; i >= 0; i--)
                {
                    if (avmList.Contains(((AxisBase)destination[i]).DataContext))
                    {
                        ((AxisBase)destination[i]).DataContext = null;
                        destination.RemoveAt(i);
                    }
                }
            }
            if (e.NewItems != null)
            {
                // Items added, add new Axis
                foreach (var axisViewModel in e.NewItems.Cast<AxisViewModel>())
                {
                    destination.Add(CreateAndBindAxis(axisViewModel, axisStyle));
                }
            }
        }

        private static IAxis CreateAndBindAxis(AxisViewModel axisViewModel, Style axisStyle)
        {
            // Creates an Axis, applies the global style, and sets the DataContext
            var axis = new NumericAxis();
            axis.Style = axisStyle;
            axis.DataContext = axisViewModel;
            return axis;
        }
    }
}
