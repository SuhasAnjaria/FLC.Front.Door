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
using Framework.UI.Converters;
using Elysium.Converters;
using Framework.UI.Commands;
using Elysium.Parameters;
using Framework.IO;
using Elysium.Controls;
using flc.FrontDoor.ViewModels;
using flc.FrontDoor.Models;

namespace flc.FrontDoor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(new AuthenticationModel(), PasswordBox);
             
        }

       
    }
}
