﻿#pragma checksum "..\..\..\Views\EditView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81CB8FCBD36FA76BA32F6DDD6BFFB2426ABD9F6F1DBE05FAD611C384E08DFBB0"
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
using TicketUI.Views;


namespace TicketUI.Views {
    
    
    /// <summary>
    /// EditView
    /// </summary>
    public partial class EditView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Id;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Title;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ArticleIdsString;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ArticleId;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetSuggest;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadLatestArticle;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Views\EditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clear;
        
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
            System.Uri resourceLocater = new System.Uri("/TicketUI;component/views/editview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\EditView.xaml"
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
            this.Id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ArticleIdsString = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ArticleId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.GetSuggest = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.LoadLatestArticle = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.Clear = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

