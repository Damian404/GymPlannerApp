﻿#pragma checksum "c:\users\damian curran\documents\visual studio 2015\Projects\GymPlanner\GymPlanner\MuscleGroups.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E855B2418B7C60C4DE9E09BB77EF054B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymPlanner
{
    partial class MuscleGroups : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MuscleLayout = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.Exercise1 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 3:
                {
                    this.Exercise2 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 4:
                {
                    this.ForumPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\MuscleGroups.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ForumPage).Click += this.btn5_click;
                    #line default
                }
                break;
            case 5:
                {
                    this.DupBox = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
