﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryApp.LibraryServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/LibraryApp.DataModel")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DesiredField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DutyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelephoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Desired {
            get {
                return this.DesiredField;
            }
            set {
                if ((this.DesiredField.Equals(value) != true)) {
                    this.DesiredField = value;
                    this.RaisePropertyChanged("Desired");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Duty {
            get {
                return this.DutyField;
            }
            set {
                if ((object.ReferenceEquals(this.DutyField, value) != true)) {
                    this.DutyField = value;
                    this.RaisePropertyChanged("Duty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telephone {
            get {
                return this.TelephoneField;
            }
            set {
                if ((object.ReferenceEquals(this.TelephoneField, value) != true)) {
                    this.TelephoneField = value;
                    this.RaisePropertyChanged("Telephone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/LibraryApp.DataModel")]
    [System.SerializableAttribute()]
    public partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EditureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniqueCodeField;
        
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
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Editure {
            get {
                return this.EditureField;
            }
            set {
                if ((object.ReferenceEquals(this.EditureField, value) != true)) {
                    this.EditureField = value;
                    this.RaisePropertyChanged("Editure");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UniqueCode {
            get {
                return this.UniqueCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.UniqueCodeField, value) != true)) {
                    this.UniqueCodeField = value;
                    this.RaisePropertyChanged("UniqueCode");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryServiceReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBranches", ReplyAction="http://tempuri.org/IService/GetBranchesResponse")]
        System.Collections.Generic.List<string> GetBranches();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetBranches", ReplyAction="http://tempuri.org/IService/GetBranchesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetBranchesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogIn", ReplyAction="http://tempuri.org/IService/LogInResponse")]
        bool LogIn(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/LogIn", ReplyAction="http://tempuri.org/IService/LogInResponse")]
        System.Threading.Tasks.Task<bool> LogInAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        bool Register(string firstName, string lastName, string address, string telephone, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Register", ReplyAction="http://tempuri.org/IService/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string firstName, string lastName, string address, string telephone, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BranchListLoader", ReplyAction="http://tempuri.org/IService/BranchListLoaderResponse")]
        System.Collections.Generic.List<string> BranchListLoader();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BranchListLoader", ReplyAction="http://tempuri.org/IService/BranchListLoaderResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> BranchListLoaderAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBook", ReplyAction="http://tempuri.org/IService/AddBookResponse")]
        System.Threading.Tasks.Task<bool> AddBookAsync(string title, string isbn, string authors, string editure, string branch, int copies);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        bool MemberRegister(LibraryApp.LibraryServiceReference.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        System.Threading.Tasks.Task<bool> MemberRegisterAsync(LibraryApp.LibraryServiceReference.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        LibraryApp.LibraryServiceReference.Client MemberLogin(LibraryApp.LibraryServiceReference.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        System.Threading.Tasks.Task<LibraryApp.LibraryServiceReference.Client> MemberLoginAsync(LibraryApp.LibraryServiceReference.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Collections.Generic.List<LibraryApp.LibraryServiceReference.Book> BooksList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.LibraryServiceReference.Book>> BooksListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : LibraryApp.LibraryServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<LibraryApp.LibraryServiceReference.IService>, LibraryApp.LibraryServiceReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<string> GetBranches() {
            return base.Channel.GetBranches();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetBranchesAsync() {
            return base.Channel.GetBranchesAsync();
        }
        
        public bool LogIn(string username, string password) {
            return base.Channel.LogIn(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> LogInAsync(string username, string password) {
            return base.Channel.LogInAsync(username, password);
        }
        
        public bool Register(string firstName, string lastName, string address, string telephone, string username, string password) {
            return base.Channel.Register(firstName, lastName, address, telephone, username, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string firstName, string lastName, string address, string telephone, string username, string password) {
            return base.Channel.RegisterAsync(firstName, lastName, address, telephone, username, password);
        }
        
        public System.Collections.Generic.List<string> BranchListLoader() {
            return base.Channel.BranchListLoader();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> BranchListLoaderAsync() {
            return base.Channel.BranchListLoaderAsync();
        }
        
        public bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies) {
            return base.Channel.AddBook(title, isbn, authors, editure, branch, copies);
        }
        
        public System.Threading.Tasks.Task<bool> AddBookAsync(string title, string isbn, string authors, string editure, string branch, int copies) {
            return base.Channel.AddBookAsync(title, isbn, authors, editure, branch, copies);
        }
        
        public bool MemberRegister(LibraryApp.LibraryServiceReference.Client client) {
            return base.Channel.MemberRegister(client);
        }
        
        public System.Threading.Tasks.Task<bool> MemberRegisterAsync(LibraryApp.LibraryServiceReference.Client client) {
            return base.Channel.MemberRegisterAsync(client);
        }
        
        public LibraryApp.LibraryServiceReference.Client MemberLogin(LibraryApp.LibraryServiceReference.Client client) {
            return base.Channel.MemberLogin(client);
        }
        
        public System.Threading.Tasks.Task<LibraryApp.LibraryServiceReference.Client> MemberLoginAsync(LibraryApp.LibraryServiceReference.Client client) {
            return base.Channel.MemberLoginAsync(client);
        }
        
        public System.Collections.Generic.List<LibraryApp.LibraryServiceReference.Book> BooksList() {
            return base.Channel.BooksList();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.LibraryServiceReference.Book>> BooksListAsync() {
            return base.Channel.BooksListAsync();
        }
    }
}
