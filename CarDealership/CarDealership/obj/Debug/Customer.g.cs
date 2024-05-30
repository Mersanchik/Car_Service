﻿#pragma checksum "..\..\Customer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DE90B233E724E1F9041E358B7831BBBDCE8AE1137DBDFFAE23C3297FB5E48C2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarDealership;
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


namespace CarDealership {
    
    
    /// <summary>
    /// Customer
    /// </summary>
    public partial class Customer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 71 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Close;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Minimized;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fname;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Sname;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phone;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCustomer;
        
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
            System.Uri resourceLocater = new System.Uri("/CarDealership;component/customer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Customer.xaml"
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
            this.Close = ((System.Windows.Controls.TextBlock)(target));
            
            #line 72 "..\..\Customer.xaml"
            this.Close.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minimized = ((System.Windows.Controls.TextBlock)(target));
            
            #line 74 "..\..\Customer.xaml"
            this.Minimized.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MinimizedMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Fname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Sname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.AddCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 185 "..\..\Customer.xaml"
            this.AddCustomer.Click += new System.Windows.RoutedEventHandler(this.AddCustomerClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

