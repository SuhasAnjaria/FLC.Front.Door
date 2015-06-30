
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
/// <summary>
    /// Interaction logic for GraphTreeView.xaml
    /// </summary>
    public partial class GraphTreeView : UserControl
    {

        public string MyProduct = "ABCDE";

        public GraphTreeView()
        {
            InitializeComponent();

            this.DataContext = new HierarchyViewModel();
           
         }

        private void _AttachSecurity(object sender, RoutedEventArgs e)
        {
            this.SelectedProduct = ((Button)sender).Content.ToString();
        }

        public string SelectedProduct
        {
            get { return (string)GetValue(MyProdProperty); }
            set { SetValue(MyProdProperty, value); }
        }

  
        public static readonly DependencyProperty MyProdProperty =
            DependencyProperty.Register("MyProd", typeof(string), typeof(GraphTreeView), new PropertyMetadata(""));

    }

    }
