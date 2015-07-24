
namespace flc.FrontDoor.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.ComponentModel;
    using System.Windows.Controls.Primitives;
    using Framework.UI;
/// <summary>
    /// Interaction logic for RatesView.xaml
    /// </summary>
    public partial class RatesView : UserControl
    {
        public string[] Args {get;set;}
        public RatesView()
        {
            InitializeComponent();
            
            
            var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(DataGrid));
            if (dpd != null)
            {
                dpd.AddValueChanged(Matgrid, DataGrid_CollectionChanged);
            }
            Matgrid.HeadersVisibility = DataGridHeadersVisibility.All;
          
        }

        private void DataGrid_CollectionChanged(object sender, EventArgs e)
        {
            var a = sender as DataGrid;
            var rows = a.ItemsSource.OfType<IDictionary<string, object>>();
            var columns = rows.SelectMany(d => d.Keys).Distinct(StringComparer.OrdinalIgnoreCase).AsParallel();
            int i = 0;
            foreach (string text in columns)
            {

                var column = new DataGridTextColumn
                {
                    Header = text,
                    MinWidth = 60,
                    Width = DataGridLength.SizeToCells,
                    Binding = new Binding(text)
                    
                };
                if (i == 0 | i == 1)
                {
                    column.Visibility = System.Windows.Visibility.Hidden;
                    i++;
                }
                if (i != 0 && i != 1)
                {
                    this.Dispatcher.BeginInvoke(new Action(() => a.Columns.Add(column)));
                }

            }
            
        }
    
        private void SelectSecurity(object sender, RoutedEventArgs e)
        {
            Security_Selection SelectSecurity = new Security_Selection()
                {
                    Owner = Window.GetWindow(this)
                };
            SelectSecurity.Show();
        }

        private void SortButtonbug(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
            
        }
    
        private void Matgrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var D = sender as DataGrid;
            
            foreach(var item in e.AddedCells)
            {
                 DataGridRow row = 
           (DataGridRow)D.ItemContainerGenerator.ContainerFromItem(item.Item);
                var col = item.Column as DataGridColumn;
                string ColHeader = (string)col.Header;
                var fc = col.GetCellContent(item.Item);
                var Boo = VisualTreeHelpers.FindChild<DataGridRowHeader>(row);
                string Rowheader = (string)Boo.Content;
                Args = new string[] { ColHeader, Rowheader };
            }
            var A = App.VMLocator.RatesViewModel;
            A.GridSelectionChangedCommand.Execute(Args);
                    
        }

    }
}
