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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        bool MemberRegister(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberRegister", ReplyAction="http://tempuri.org/IService/MemberRegisterResponse")]
        System.Threading.Tasks.Task<bool> MemberRegisterAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        LibraryApp.DataModel.Client MemberLogin(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MemberLogin", ReplyAction="http://tempuri.org/IService/MemberLoginResponse")]
        System.Threading.Tasks.Task<LibraryApp.DataModel.Client> MemberLoginAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientList", ReplyAction="http://tempuri.org/IService/ClientListResponse")]
        System.Collections.Generic.List<LibraryApp.DataModel.Client> ClientList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientList", ReplyAction="http://tempuri.org/IService/ClientListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Client>> ClientListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditMember", ReplyAction="http://tempuri.org/IService/EditMemberResponse")]
        bool EditMember(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditMember", ReplyAction="http://tempuri.org/IService/EditMemberResponse")]
        System.Threading.Tasks.Task<bool> EditMemberAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteMember", ReplyAction="http://tempuri.org/IService/DeleteMemberResponse")]
        bool DeleteMember(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteMember", ReplyAction="http://tempuri.org/IService/DeleteMemberResponse")]
        System.Threading.Tasks.Task<bool> DeleteMemberAsync(LibraryApp.DataModel.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Collections.Generic.List<LibraryApp.DataModel.Book> BooksList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/BooksList", ReplyAction="http://tempuri.org/IService/BooksListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Book>> BooksListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        bool EditBook(LibraryApp.DataModel.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBook", ReplyAction="http://tempuri.org/IService/EditBookResponse")]
        System.Threading.Tasks.Task<bool> EditBookAsync(LibraryApp.DataModel.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBranch", ReplyAction="http://tempuri.org/IService/AddBranchResponse")]
        bool AddBranch(LibraryApp.DataModel.Branch branch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddBranch", ReplyAction="http://tempuri.org/IService/AddBranchResponse")]
        System.Threading.Tasks.Task<bool> AddBranchAsync(LibraryApp.DataModel.Branch branch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewBranches", ReplyAction="http://tempuri.org/IService/ViewBranchesResponse")]
        System.Collections.Generic.List<LibraryApp.DataModel.Branch> ViewBranches();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ViewBranches", ReplyAction="http://tempuri.org/IService/ViewBranchesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Branch>> ViewBranchesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBranch", ReplyAction="http://tempuri.org/IService/EditBranchResponse")]
        bool EditBranch(LibraryApp.DataModel.Branch branch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EditBranch", ReplyAction="http://tempuri.org/IService/EditBranchResponse")]
        System.Threading.Tasks.Task<bool> EditBranchAsync(LibraryApp.DataModel.Branch branch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteBranch", ReplyAction="http://tempuri.org/IService/DeleteBranchResponse")]
        bool DeleteBranch(LibraryApp.DataModel.Branch branch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteBranch", ReplyAction="http://tempuri.org/IService/DeleteBranchResponse")]
        System.Threading.Tasks.Task<bool> DeleteBranchAsync(LibraryApp.DataModel.Branch branch);
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
        
        public System.Collections.Generic.List<LibraryApp.DataModel.Client> ClientList() {
            return base.Channel.ClientList();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Client>> ClientListAsync() {
            return base.Channel.ClientListAsync();
        }
        
        public bool EditMember(LibraryApp.DataModel.Client client) {
            return base.Channel.EditMember(client);
        }
        
        public System.Threading.Tasks.Task<bool> EditMemberAsync(LibraryApp.DataModel.Client client) {
            return base.Channel.EditMemberAsync(client);
        }
        
        public bool DeleteMember(LibraryApp.DataModel.Client client) {
            return base.Channel.DeleteMember(client);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteMemberAsync(LibraryApp.DataModel.Client client) {
            return base.Channel.DeleteMemberAsync(client);
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
        
        public bool AddBranch(LibraryApp.DataModel.Branch branch) {
            return base.Channel.AddBranch(branch);
        }
        
        public System.Threading.Tasks.Task<bool> AddBranchAsync(LibraryApp.DataModel.Branch branch) {
            return base.Channel.AddBranchAsync(branch);
        }
        
        public System.Collections.Generic.List<LibraryApp.DataModel.Branch> ViewBranches() {
            return base.Channel.ViewBranches();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<LibraryApp.DataModel.Branch>> ViewBranchesAsync() {
            return base.Channel.ViewBranchesAsync();
        }
        
        public bool EditBranch(LibraryApp.DataModel.Branch branch) {
            return base.Channel.EditBranch(branch);
        }
        
        public System.Threading.Tasks.Task<bool> EditBranchAsync(LibraryApp.DataModel.Branch branch) {
            return base.Channel.EditBranchAsync(branch);
        }
        
        public bool DeleteBranch(LibraryApp.DataModel.Branch branch) {
            return base.Channel.DeleteBranch(branch);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBranchAsync(LibraryApp.DataModel.Branch branch) {
            return base.Channel.DeleteBranchAsync(branch);
        }
    }
}
