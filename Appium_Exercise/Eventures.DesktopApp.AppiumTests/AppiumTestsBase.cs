using System;
using System.IO;

using Eventures.Data;
using Eventures.WebAPI;
using Eventures.Tests.Common;

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace Eventures.DesktopApp.AppiumTests
{
    public class AppiumTestsBase
    {        
        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
        }
    }
}
