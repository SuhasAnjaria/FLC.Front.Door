
namespace flc.FrontDoor.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Autofac;
    using FrontDoor.Data;
   public class ViewModelLocator
    {
        private readonly IContainer Container;
        public  ViewModelLocator()
        {
            var containerbuilder = new ContainerBuilder();
            containerbuilder.Register(c => new SecuritySelectionViewModel()).SingleInstance();
            //TODO: Register Login View Model and DB Authentication

            containerbuilder.Register(c => new HierarchyViewModel()).SingleInstance();
            containerbuilder.Register(c => new SecuritySelectionViewModel());
            containerbuilder.Register(c => new RatesViewModel()).SingleInstance();
            this.Container = containerbuilder.Build();
        }

        //public LoginViewModel LoginViewModel
        //{
        //    get
        //    {
        //        ; //return this.Container.Resolve<LoginViewModel>();
        //    }
        //}

        public SecuritySelectionViewModel SecuritySelectionViewModel
        {
            get
            {
                return this.Container.Resolve<SecuritySelectionViewModel>();
            }
        }
        public HierarchyViewModel HierarchyViewModel
        {
            get
            {
                return this.Container.Resolve<HierarchyViewModel>();
            }
        }

        public RatesViewModel RatesViewModel 
        { 
            get 
            { 
                return this.Container.Resolve<RatesViewModel>(); 
        
            } 
        }

            
       
    }
}
