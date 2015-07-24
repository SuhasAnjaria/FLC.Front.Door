
namespace flc.FrontDoor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using flc.FrontDoor.Assets;
    using flc.FrontDoor.ViewModels;
    using flc.FrontDoor.Models;
    using Autofac;
/// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        public static ViewModelLocator VMLocator = new ViewModelLocator();
        public App()
        {
           
            InitializeComponent();
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            Principal customPrincipal = new Principal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);
            ModelBuilder.ModelContainer.Resolve<Instrumentlist>();
            
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Environment.Exit(-1);
        }
       
    }
}
