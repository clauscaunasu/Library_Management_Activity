﻿#pragma checksum "..\..\RegisterUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97AE79F73C2F6D7BE51AB65A2F128DF47E4E9C8C5A4B85369CF9A0E80BCFE29F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LibraryApp;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LibraryApp {
    
    
    /// <summary>
    /// RegisterUser
    /// </summary>
    public partial class RegisterUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtFirstname;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtLastname;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtEmail;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtUsername;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TxtPassword;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPhone;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtAddress;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegister;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\RegisterUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LibraryApp;component/registeruser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterUser.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\RegisterUser.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtFirstname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtLastname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TxtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.TxtPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TxtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.BtnRegister = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\RegisterUser.xaml"
            this.BtnRegister.Click += new System.Windows.RoutedEventHandler(this.BtnRegister_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnExit = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\RegisterUser.xaml"
            this.BtnExit.Click += new System.Windows.RoutedEventHandler(this.BtnExit_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
