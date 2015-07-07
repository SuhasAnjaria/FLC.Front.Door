using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using flc.FrontDoor.ViewModels;
using flc.FrontDoor.Data;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
namespace flc.FrontDoor.ViewModels

{
    interface IParameterLoader
    {
         ObservableCollection<RatesViewModel> GetData();
    }

    class RatesViewModel:BaseViewModel
    {
        private RelayCommand<object> _selectedAtrributeCommand;
        public RelayCommand<object> _selectedProductCommand;
       

        public ICommand SelectedAttributeCommand
        {
            get {
                if(_selectedAtrributeCommand == null)
                {
                _selectedAtrributeCommand = new RelayCommand<object>(AttributeSelected);
                return this._selectedAtrributeCommand;
                }
                else
                {
                    return this._selectedAtrributeCommand;
                }
            }
            
        }

        
        public ICommand SelectedProductCommand
        {
            get
            {
                if(_selectedProductCommand == null){
                _selectedProductCommand = new RelayCommand<object>(ProductSelected);
                return  this._selectedProductCommand;
                }
                else{
                    return this._selectedProductCommand;
                }
            }
        }

        private void ProductSelected(object obj)
        {
            var A = (TextBlock)obj;
           
            
        }

        private void AttributeSelected(object param)
        {
            var B = param;          
        }


        public ICollectionView A { get; set; }
        public RatesViewModel()
        {
             var B = new FullGrid{
                new GridRow{
                    new GridPoint{GridHeader ="ABC", Value=1},},
                    new GridRow{new GridPoint{GridHeader="AC", Value=1}}
                
            };
             this.A = CollectionViewSource.GetDefaultView(B);
        }
        
    }
}
