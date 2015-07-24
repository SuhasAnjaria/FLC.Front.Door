using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using flc.FrontDoor.Models.Interfaces;
using flc.FrontDoor.Data;
namespace flc.FrontDoor.Models
{
    class ModelBuilder
    {
        // Fields...
        private static ContainerBuilder _modelLocator= new ContainerBuilder();
        private static IContainer  _modelContainer;

        public static IContainer  ModelContainer
        {
            get { return _modelContainer; }
            set { _modelContainer = value; }
        }

        public static ContainerBuilder ModelLocator
        {
            get { return _modelLocator; }
            set { _modelLocator = value; }
        }

         static ModelBuilder()
        {
            
            ModelLocator.RegisterType<ProcessLocator>().As<IProcessLocator>();
            ModelLocator.RegisterType<Instrumentlist>()
                .AsSelf()
                .As<IDataGetter>()
                .As<IInstrumentDataGetter>()
                .SingleInstance();
            ModelLocator.RegisterType<RatesMatrixModel>();    
            
            ModelContainer = ModelLocator.Build();
        }
    }

    class ProcessLocator:IProcessLocator
    {
        ILifetimeScope _Scope = null;
        #region Constructor
        public ProcessLocator()
        {
            ((IProcessLocator)this).CreateScope();
        }
        #endregion

        #region Interface Implementation
        public void CreateScope()
        {
            _Scope = ModelBuilder.ModelContainer.BeginLifetimeScope();
        }

        public T GetProcessor<T>()
        {
            return _Scope.Resolve<T>();
        }

        public void ReleaseScope()
        {
            _Scope.Dispose();
        }
        #endregion
    }
}
