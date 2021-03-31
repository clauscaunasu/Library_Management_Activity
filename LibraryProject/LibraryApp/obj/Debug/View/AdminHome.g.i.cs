﻿#pragma checksum "..\..\..\View\AdminHome.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2818241838E85015E12F233247FADE13184C842DE4ED6D9DDBCBAE9CC01045D7"
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


namespace LibraryApp.View {
    
    
    /// <summary>
    /// AdminHome
    /// </summary>
    public partial class AdminHome : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBookBtn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateCustomerBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteCustomerBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TitleFilterBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthorFilterBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenreFilterBtn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BranchFilterBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/LibraryApp;component/view/adminhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AdminHome.xaml"
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
            this.AddBookBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\View\AdminHome.xaml"
            this.AddBookBtn.Click += new System.Windows.RoutedEventHandler(this.AddBookBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UpdateCustomerBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.DeleteCustomerBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.TitleFilterBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.AuthorFilterBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.GenreFilterBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.BranchFilterBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

