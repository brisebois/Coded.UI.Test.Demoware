﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace LoginCodedUITestProject.LoginWpfApplicationUIMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class LoginWpfApplicationUIMap
    {
        
        /// <summary>
        /// ClickOnLogin
        /// </summary>
        public void ClickOnLogin()
        {
            #region Variable Declarations
            WpfButton uILoginButton = this.UILoginTestApplicationWindow.UILoginButton;
            #endregion

            // Click 'Login' button
            Mouse.Click(uILoginButton, new Point(113, 20));
        }
        
        #region Properties
        public UILoginTestApplicationWindow UILoginTestApplicationWindow
        {
            get
            {
                if ((this.mUILoginTestApplicationWindow == null))
                {
                    this.mUILoginTestApplicationWindow = new UILoginTestApplicationWindow();
                }
                return this.mUILoginTestApplicationWindow;
            }
        }
        #endregion
        
        #region Fields
        private UILoginTestApplicationWindow mUILoginTestApplicationWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UILoginTestApplicationWindow : WpfWindow
    {
        
        public UILoginTestApplicationWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Login Test Application";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Login Test Application");
            #endregion
        }
        
        #region Properties
        public WpfButton UILoginButton
        {
            get
            {
                if ((this.mUILoginButton == null))
                {
                    this.mUILoginButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUILoginButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "LoginButton";
                    this.mUILoginButton.WindowTitles.Add("Login Test Application");
                    #endregion
                }
                return this.mUILoginButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mUILoginButton;
        #endregion
    }
}
