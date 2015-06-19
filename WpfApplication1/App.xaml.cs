using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using flc.FrontDoor.Assets;
using flc.FrontDoor.ViewModels;
using flc.FrontDoor.Models;
using flc.FrontDoor.Views;

namespace flc.FrontDoor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnStartup(StartupEventArgs e) {
       
      //Create a custom principal with an anonymous identity at startup
      Principal customPrincipal = new Principal();
      AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
       
      base.OnStartup(e);
 
       
   
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Environment.Exit(-1);
        }
    }
}
