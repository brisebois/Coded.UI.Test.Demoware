﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using LoginCodedUITestProject.LoginWindowIUMapClasses;
using LoginCodedUITestProject.LoginWpfApplicationUIMapClasses;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace LoginCodedUITestProject
{
    /// <summary>
    /// Summary description for LoginCodedUITests
    /// </summary>
    [CodedUITest]
    public class LoginCodedUITests
    {
        public LoginCodedUITests()
        {
            container = new UIMapContainer<LoginWpfApplicationUIMap>();
            container.Configure<LoginWindowIUMap>(m => m.UILoginTestApplicationWindow,
                                                    r => r.UILoginTestApplicationWindow);
        }

        const string path = @"C:\Users\alexandre\Documents\Visual Studio 2012\Projects\LoginCodedUITestProject\LoginWpfApplication\bin\Debug\";

        /// <summary>
        /// Given that I have a valid username and password when I 
        /// Login I expect that I will be redirected to the proper screen.
        /// </summary>
        [TestMethod]
        public void GivenValidCredentialsWhenILoginIExpectThatTheLoginWindowWillDisapear()
        {

            string fileName = string.Format(@"{0}LoginWpfApplication.exe", path);
            using (ApplicationUnderTest.Launch(fileName))
            {
                container.UIMap.ClickOnLogin();
                var loginWindow = container.Get<LoginWindowIUMap>();

                loginWindow.TypeUsername();
                loginWindow.TypeUserPassword();

                loginWindow.ClickLogin();

                UILoginWindow uiLoginWindow = loginWindow.UILoginWindow;

                bool loginWindowNotExit = uiLoginWindow.WaitForControlNotExist(1000);
                Assert.IsTrue(loginWindowNotExit);
            }
        }

        /// <summary>
        /// Given that I have a valid username and an invalid password when I Login 
        /// I expect that the error message will be
        /// “The username and password combination was invalid”.
        /// </summary>
        [TestMethod]
        public void GivenValidUserNameAndInvalidPasswordWhenILoginIExpectAnErrorMessage()
        {
            string fileName = string.Format(@"{0}LoginWpfApplication.exe", path);
            using (ApplicationUnderTest.Launch(fileName))
            {
                container.UIMap.ClickOnLogin();
                var loginWindow = container.Get<LoginWindowIUMap>();

                loginWindow.TypeUsernameParams.UIUserNameTextboxEditText = "alexandre";
                loginWindow.TypeUsername();
                loginWindow.TypeUserPasswordParams.UIPasswordTextboxEditText = "none";
                loginWindow.TypeUserPassword();

                loginWindow.ClickLogin();

                const string msg = "The username and password combination was invalid";
                loginWindow.AssertValidErrMsgExpectedValues.ErrorMsgDisplayText = msg;
                loginWindow.AssertValidErrMsg();
            }
        }

        /// <summary>
        /// Given that I have an invalid username and a valid password when I Login 
        /// I expect that the error message will be 
        /// “The username and password combination was invalid”.
        /// </summary>
        [TestMethod]
        public void GivenInvalidUserNameAndValidPasswordWhenILoginIExpectAnErrorMessage()
        {
            string fileName = string.Format(@"{0}LoginWpfApplication.exe", path);
            using (ApplicationUnderTest.Launch(fileName))
            {
                container.UIMap.ClickOnLogin();
                var loginWindow = container.Get<LoginWindowIUMap>();

                loginWindow.TypeUsernameParams.UIUserNameTextboxEditText = "none";
                loginWindow.TypeUsername();
                loginWindow.TypeUserPasswordParams.UIPasswordTextboxEditText = "P@ssword";
                loginWindow.TypeUserPassword();

                loginWindow.ClickLogin();

                const string msg = "The username and password combination was invalid";
                loginWindow.AssertValidErrMsgExpectedValues.ErrorMsgDisplayText = msg;
                loginWindow.AssertValidErrMsg();
            }
        }

        /// <summary>
        /// Given that I have an empty username and an empty password when I Login 
        /// I expect that the error message will be 
        /// “The username and password are required”.
        /// </summary>
        [TestMethod]
        public void GivenNoCredentialsWhenILoginIExpectAnErrorMessage()
        {
            string fileName = string.Format(@"{0}LoginWpfApplication.exe", path);
            using (ApplicationUnderTest.Launch(fileName))
            {
                container.UIMap.ClickOnLogin();
                var loginWindow = container.Get<LoginWindowIUMap>();

                loginWindow.ClickLogin();

                const string msg = "The username and password are required";
                loginWindow.AssertValidErrMsgExpectedValues.ErrorMsgDisplayText = msg;
                loginWindow.AssertValidErrMsg();
            }
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private TestContext testContextInstance;
        private UIMapContainer<LoginWpfApplicationUIMap> container;
    }
}
