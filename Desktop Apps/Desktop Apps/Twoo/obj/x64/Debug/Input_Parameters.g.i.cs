﻿#pragma checksum "..\..\..\Input_Parameters.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D27A2FAB3C501BB71420AA023896D468DDF3D98CCEFDA5078C089BDA91DDF9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Twoo;


namespace Twoo {
    
    
    /// <summary>
    /// Input_Parameters
    /// </summary>
    public partial class Input_Parameters : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Error_Message;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Browse_Button;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label File_selected;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Username_Box;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Message_Box;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Input_Parameters.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/Twoo;component/input_parameters.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Input_Parameters.xaml"
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
            this.Error_Message = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Browse_Button = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Input_Parameters.xaml"
            this.Browse_Button.Click += new System.Windows.RoutedEventHandler(this.Btn_Open_Browser_File);
            
            #line default
            #line hidden
            return;
            case 3:
            this.File_selected = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Username_Box = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Message_Box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Start_Button = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Input_Parameters.xaml"
            this.Start_Button.Click += new System.Windows.RoutedEventHandler(this.Btn_Click_Start);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

