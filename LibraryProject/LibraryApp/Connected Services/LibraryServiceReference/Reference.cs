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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        bool MemberRegister(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        System.Threading.Tasks.Task<bool> MemberRegisterAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        LibraryApp.DataModel.Client MemberLogin(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        System.Threading.Tasks.Task<LibraryApp.DataModel.Client> MemberLoginAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Collections.Generic.List<LibraryApp.DataModel.Book> BooksList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Book>> BooksListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        bool EditBook(LibraryApp.DataModel.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        System.Threading.Tasks.Task<bool> EditBookAsync(LibraryApp.DataModel.Book book);
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
        
        public bool MemberRegister(LibraryApp.DataModel.Client client) {
            return base.Channel.MemberRegister(client);
        }
        
        public System.Threading.Tasks.Task<bool> MemberRegisterAsync(LibraryApp.DataModel.Client client) {
            return base.Channel.MemberRegisterAsync(client);
        }
        
        public LibraryApp.DataModel.Client MemberLogin(LibraryApp.DataModel.Client client) {
            return base.Channel.MemberLogin(client);
        }
        
        public System.Threading.Tasks.Task<LibraryApp.DataModel.Client> MemberLoginAsync(LibraryApp.DataModel.Client client) {
            return base.Channel.MemberLoginAsync(client);
        }
        
        public System.Collections.Generic.List<LibraryApp.DataModel.Book> BooksList() {
            return base.Channel.BooksList();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Book>> BooksListAsync() {
            return base.Channel.BooksListAsync();
        }
        
        public bool EditBook(LibraryApp.DataModel.Book book) {
            return base.Channel.EditBook(book);
        }
        
        public System.Threading.Tasks.Task<bool> EditBookAsync(LibraryApp.DataModel.Book book) {
            return base.Channel.EditBookAsync(book);
        }
    }
}
