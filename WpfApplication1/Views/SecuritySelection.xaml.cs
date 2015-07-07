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
using flc.FrontDoor.Views;
using flc.FrontDoor.ViewModels;
using Framework.UI.Controls;


namespace flc.FrontDoor.Views
{
    /// <summary>
    /// Interaction logic for Security_Selection.xaml
    /// </summary>
    public partial class Security_Selection : OverlayWindow
    {
       

        public Security_Selection()
        {
            InitializeComponent();
            
           
        }

        private void CLose(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void AutoBoxClick(object sender, SelectionChangedEventArgs e)
        {
             var A = ((AutoCompleteBox)sender).SelectedItem;
            if(A!=null)
            {
               
                var B = A as ProductSearchViewModel;
                SelectionTree.SelectedProduct = B.Name;
                SelectionTree.SelectedInstrument = B.Product;
            }

        }

       
    }
}
