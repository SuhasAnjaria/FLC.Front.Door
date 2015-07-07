using System.Runtime.InteropServices;

namespace flc.FrontDoor.Views
{
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
    using flc.FrontDoor.Data;
    using System.Collections;
    using flc.FrontDoor.ViewModels;
    using System.ComponentModel;
    using Framework.UI.Controls;
    /// <summary>
    /// Interaction logic for GraphTreeView.xaml
    /// </summary>
    public partial class GraphTreeView : UserControl
    {

        public GraphTreeView()
        {
            InitializeComponent();

            this.DataContext = new HierarchyViewModel();

        }

        private void _AttachSecurity(object sender, RoutedEventArgs e)
        {
            
               this.SelectedProduct = ((Button)sender).Content.ToString();
                this.SelectedInstrument = HierarchyViewModel.products.FirstOrDefault(o => o.Name == this.SelectedProduct);
                
            }


        public string SelectedProduct
        {
            get { return (string)GetValue(SelectedProductProperty); }
            set {

                if (value != null)
                
                {
                 SetValue(SelectedProductProperty, value);
                }
                 
            
            }
        }

        // Using a DependencyProperty as the backing store for SelectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedProductProperty =
            DependencyProperty.Register("SelectedProduct", typeof(string), typeof(GraphTreeView), new PropertyMetadata(""));

        public Instrument SelectedInstrument
        {
            get { return (Instrument)GetValue(SelectedInstrumentProperty); }
            set { SetValue(SelectedInstrumentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedInstrument.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedInstrumentProperty =
            DependencyProperty.Register("SelectedInstrument", typeof(Instrument), typeof(GraphTreeView), null);

        
        
    }
}