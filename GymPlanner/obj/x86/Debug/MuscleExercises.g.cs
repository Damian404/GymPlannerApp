﻿#pragma checksum "c:\users\damian curran\documents\visual studio 2015\Projects\GymPlanner\GymPlanner\MuscleExercises.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9BDF32EF898AAD1E5B563BE1A144C197"
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
    partial class MuscleExercises : 
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
                    this.MuscleExerciseLayout = (global::Windows.UI.Xaml.Controls.Grid)(target);
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
                    this.Exercise3 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5:
                {
                    this.Exercise4 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6:
                {
                    this.Exercise5 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7:
                {
                    this.Exercise6 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8:
                {
                    this.ForumPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 109 "..\..\..\MuscleExercises.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ForumPage).Click += this.btn5_click;
                    #line default
                }
                break;
            case 9:
                {
                    this.returnPage = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 112 "..\..\..\MuscleExercises.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.returnPage).Click += this.returnButton;
                    #line default
                }
                break;
            case 10:
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

