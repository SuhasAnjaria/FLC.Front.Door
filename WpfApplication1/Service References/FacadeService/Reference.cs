﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace flc.FrontDoor.FacadeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InstrumentDTO", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class InstrumentDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AssetTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] BloombergTickersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrencyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] DataQueryTickersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FLCTickerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] FieldsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnderlyingField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AssetType {
            get {
                return this.AssetTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.AssetTypeField, value) != true)) {
                    this.AssetTypeField = value;
                    this.RaisePropertyChanged("AssetType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] BloombergTickers {
            get {
                return this.BloombergTickersField;
            }
            set {
                if ((object.ReferenceEquals(this.BloombergTickersField, value) != true)) {
                    this.BloombergTickersField = value;
                    this.RaisePropertyChanged("BloombergTickers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Currency {
            get {
                return this.CurrencyField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrencyField, value) != true)) {
                    this.CurrencyField = value;
                    this.RaisePropertyChanged("Currency");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] DataQueryTickers {
            get {
                return this.DataQueryTickersField;
            }
            set {
                if ((object.ReferenceEquals(this.DataQueryTickersField, value) != true)) {
                    this.DataQueryTickersField = value;
                    this.RaisePropertyChanged("DataQueryTickers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FLCTicker {
            get {
                return this.FLCTickerField;
            }
            set {
                if ((object.ReferenceEquals(this.FLCTickerField, value) != true)) {
                    this.FLCTickerField = value;
                    this.RaisePropertyChanged("FLCTicker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Fields {
            get {
                return this.FieldsField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldsField, value) != true)) {
                    this.FieldsField = value;
                    this.RaisePropertyChanged("Fields");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductType {
            get {
                return this.ProductTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductTypeField, value) != true)) {
                    this.ProductTypeField = value;
                    this.RaisePropertyChanged("ProductType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Underlying {
            get {
                return this.UnderlyingField;
            }
            set {
                if ((object.ReferenceEquals(this.UnderlyingField, value) != true)) {
                    this.UnderlyingField = value;
                    this.RaisePropertyChanged("Underlying");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class FacadeFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FaultMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FaultMessage {
            get {
                return this.FaultMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.FaultMessageField, value) != true)) {
                    this.FaultMessageField = value;
                    this.RaisePropertyChanged("FaultMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TickerDTO", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class TickerDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataSourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataSource {
            get {
                return this.DataSourceField;
            }
            set {
                if ((object.ReferenceEquals(this.DataSourceField, value) != true)) {
                    this.DataSourceField = value;
                    this.RaisePropertyChanged("DataSource");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataSourceDTO", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class DataSourceDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RatesMatrixDTO", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class RatesMatrixDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrencyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] DataRowListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FieldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnderlyingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Currency {
            get {
                return this.CurrencyField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrencyField, value) != true)) {
                    this.CurrencyField = value;
                    this.RaisePropertyChanged("Currency");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] DataRowList {
            get {
                return this.DataRowListField;
            }
            set {
                if ((object.ReferenceEquals(this.DataRowListField, value) != true)) {
                    this.DataRowListField = value;
                    this.RaisePropertyChanged("DataRowList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Field {
            get {
                return this.FieldField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldField, value) != true)) {
                    this.FieldField = value;
                    this.RaisePropertyChanged("Field");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductType {
            get {
                return this.ProductTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductTypeField, value) != true)) {
                    this.ProductTypeField = value;
                    this.RaisePropertyChanged("ProductType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Underlying {
            get {
                return this.UnderlyingField;
            }
            set {
                if ((object.ReferenceEquals(this.UnderlyingField, value) != true)) {
                    this.UnderlyingField = value;
                    this.RaisePropertyChanged("Underlying");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Units {
            get {
                return this.UnitsField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitsField, value) != true)) {
                    this.UnitsField = value;
                    this.RaisePropertyChanged("Units");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeSeriesDTO", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
    [System.SerializableAttribute()]
    public partial class TimeSeriesDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime[] DatesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FieldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TickerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double[] ValuesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime[] Dates {
            get {
                return this.DatesField;
            }
            set {
                if ((object.ReferenceEquals(this.DatesField, value) != true)) {
                    this.DatesField = value;
                    this.RaisePropertyChanged("Dates");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Field {
            get {
                return this.FieldField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldField, value) != true)) {
                    this.FieldField = value;
                    this.RaisePropertyChanged("Field");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ticker {
            get {
                return this.TickerField;
            }
            set {
                if ((object.ReferenceEquals(this.TickerField, value) != true)) {
                    this.TickerField = value;
                    this.RaisePropertyChanged("Ticker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Units {
            get {
                return this.UnitsField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitsField, value) != true)) {
                    this.UnitsField = value;
                    this.RaisePropertyChanged("Units");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] Values {
            get {
                return this.ValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.ValuesField, value) != true)) {
                    this.ValuesField = value;
                    this.RaisePropertyChanged("Values");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FacadeService.IFacadeService")]
    public interface IFacadeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetInstruments", ReplyAction="http://tempuri.org/IFacadeService/GetInstrumentsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(flc.FrontDoor.FacadeService.FacadeFault), Action="http://tempuri.org/IFacadeService/GetInstrumentsFacadeFaultFault", Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
        flc.FrontDoor.FacadeService.InstrumentDTO[] GetInstruments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetInstruments", ReplyAction="http://tempuri.org/IFacadeService/GetInstrumentsResponse")]
        System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.InstrumentDTO[]> GetInstrumentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetTickerByMappingSrcToDest", ReplyAction="http://tempuri.org/IFacadeService/GetTickerByMappingSrcToDestResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(flc.FrontDoor.FacadeService.FacadeFault), Action="http://tempuri.org/IFacadeService/GetTickerByMappingSrcToDestFacadeFaultFault", Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
        flc.FrontDoor.FacadeService.TickerDTO GetTickerByMappingSrcToDest(string srcTickerName, string srcDataSource, string destDataSource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetTickerByMappingSrcToDest", ReplyAction="http://tempuri.org/IFacadeService/GetTickerByMappingSrcToDestResponse")]
        System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.TickerDTO> GetTickerByMappingSrcToDestAsync(string srcTickerName, string srcDataSource, string destDataSource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetDataSources", ReplyAction="http://tempuri.org/IFacadeService/GetDataSourcesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(flc.FrontDoor.FacadeService.FacadeFault), Action="http://tempuri.org/IFacadeService/GetDataSourcesFacadeFaultFault", Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
        flc.FrontDoor.FacadeService.DataSourceDTO[] GetDataSources();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetDataSources", ReplyAction="http://tempuri.org/IFacadeService/GetDataSourcesResponse")]
        System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.DataSourceDTO[]> GetDataSourcesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetRatesMatrix", ReplyAction="http://tempuri.org/IFacadeService/GetRatesMatrixResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(flc.FrontDoor.FacadeService.FacadeFault), Action="http://tempuri.org/IFacadeService/GetRatesMatrixFacadeFaultFault", Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
        flc.FrontDoor.FacadeService.RatesMatrixDTO GetRatesMatrix(string currency, string productType, string underlying, string dataType, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetRatesMatrix", ReplyAction="http://tempuri.org/IFacadeService/GetRatesMatrixResponse")]
        System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.RatesMatrixDTO> GetRatesMatrixAsync(string currency, string productType, string underlying, string dataType, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetTimeSeries", ReplyAction="http://tempuri.org/IFacadeService/GetTimeSeriesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(flc.FrontDoor.FacadeService.FacadeFault), Action="http://tempuri.org/IFacadeService/GetTimeSeriesFacadeFaultFault", Name="FacadeFault", Namespace="http://schemas.datacontract.org/2004/07/flcFacadeService")]
        flc.FrontDoor.FacadeService.TimeSeriesDTO GetTimeSeries(string flcTicker, string field, System.DateTime fromDate, System.DateTime toDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFacadeService/GetTimeSeries", ReplyAction="http://tempuri.org/IFacadeService/GetTimeSeriesResponse")]
        System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.TimeSeriesDTO> GetTimeSeriesAsync(string flcTicker, string field, System.DateTime fromDate, System.DateTime toDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFacadeServiceChannel : flc.FrontDoor.FacadeService.IFacadeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FacadeServiceClient : System.ServiceModel.ClientBase<flc.FrontDoor.FacadeService.IFacadeService>, flc.FrontDoor.FacadeService.IFacadeService {
        
        public FacadeServiceClient() {
        }
        
        public FacadeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FacadeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FacadeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FacadeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public flc.FrontDoor.FacadeService.InstrumentDTO[] GetInstruments() {
            return base.Channel.GetInstruments();
        }
        
        public System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.InstrumentDTO[]> GetInstrumentsAsync() {
            return base.Channel.GetInstrumentsAsync();
        }
        
        public flc.FrontDoor.FacadeService.TickerDTO GetTickerByMappingSrcToDest(string srcTickerName, string srcDataSource, string destDataSource) {
            return base.Channel.GetTickerByMappingSrcToDest(srcTickerName, srcDataSource, destDataSource);
        }
        
        public System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.TickerDTO> GetTickerByMappingSrcToDestAsync(string srcTickerName, string srcDataSource, string destDataSource) {
            return base.Channel.GetTickerByMappingSrcToDestAsync(srcTickerName, srcDataSource, destDataSource);
        }
        
        public flc.FrontDoor.FacadeService.DataSourceDTO[] GetDataSources() {
            return base.Channel.GetDataSources();
        }
        
        public System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.DataSourceDTO[]> GetDataSourcesAsync() {
            return base.Channel.GetDataSourcesAsync();
        }
        
        public flc.FrontDoor.FacadeService.RatesMatrixDTO GetRatesMatrix(string currency, string productType, string underlying, string dataType, System.DateTime date) {
            return base.Channel.GetRatesMatrix(currency, productType, underlying, dataType, date);
        }
        
        public System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.RatesMatrixDTO> GetRatesMatrixAsync(string currency, string productType, string underlying, string dataType, System.DateTime date) {
            return base.Channel.GetRatesMatrixAsync(currency, productType, underlying, dataType, date);
        }
        
        public flc.FrontDoor.FacadeService.TimeSeriesDTO GetTimeSeries(string flcTicker, string field, System.DateTime fromDate, System.DateTime toDate) {
            return base.Channel.GetTimeSeries(flcTicker, field, fromDate, toDate);
        }
        
        public System.Threading.Tasks.Task<flc.FrontDoor.FacadeService.TimeSeriesDTO> GetTimeSeriesAsync(string flcTicker, string field, System.DateTime fromDate, System.DateTime toDate) {
            return base.Channel.GetTimeSeriesAsync(flcTicker, field, fromDate, toDate);
        }
    }
}
