﻿#pragma checksum "..\..\..\PersonalAccountWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35E44EFC2E8E36870ADEE5E5C354A317F813B01E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace restaurant2 {
    
    
    /// <summary>
    /// PersonalAccountWindow
    /// </summary>
    public partial class PersonalAccountWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// NameTextBlock Name Field
        /// </summary>
        
        #line 58 "..\..\..\PersonalAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock NameTextBlock;
        
        #line default
        #line hidden
        
        /// <summary>
        /// LastNameTextBlock Name Field
        /// </summary>
        
        #line 63 "..\..\..\PersonalAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock LastNameTextBlock;
        
        #line default
        #line hidden
        
        /// <summary>
        /// EmailTextBlock Name Field
        /// </summary>
        
        #line 68 "..\..\..\PersonalAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock EmailTextBlock;
        
        #line default
        #line hidden
        
        /// <summary>
        /// RoleTextBlock Name Field
        /// </summary>
        
        #line 73 "..\..\..\PersonalAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock RoleTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/restaurant2;component/personalaccountwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PersonalAccountWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.LastNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.EmailTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.RoleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 77 "..\..\..\PersonalAccountWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogOutButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

