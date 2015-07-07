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

namespace flc.FrontDoor.Views
{
    /// <summary>
    /// Interaction logic for RatesView.xaml
    /// </summary>
    public partial class RatesView : UserControl
    {
        public RatesView()
        {
            InitializeComponent();
        }

        private void SelectSecurity(object sender, RoutedEventArgs e)
        {
            Security_Selection SelectSecurity = new Security_Selection();
            SelectSecurity.Owner = Window.GetWindow(this);
            SelectSecurity.Show();
        }

        private void Try(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var col = new DataGridTextColumn { Binding = new Binding(e.PropertyName), Header= e.PropertyName };
        }
    }
}
