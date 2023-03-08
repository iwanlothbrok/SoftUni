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
		protected TestDb testDb;
		protected ApplicationDbContext dbContext;
		private TestEventuresApp<Startup> testEventuresApp;
		protected string baseUrl;
		private AppiumLocalService appiumLocalService;
		private string ApiPath = @"../../../../Eventures.WebAPI";
		private string AppPath = @"../../../../Eventures.DesktopApp/bin/Debug" +
								 @"/net5.0-windows/Eventures.DesktopApp.exe";
		protected WindowsDriver<WindowsElement> driver;
		protected WebDriverWait wait;



		[OneTimeSetUp]
		public void OneTimeSetUpBase()
		{
			//creating
			this.testDb = new TestDb();
			this.dbContext = testDb.CreateDbContext();
			this.testEventuresApp = new TestEventuresApp<Startup>(testDb, ApiPath);
			this.baseUrl = this.testEventuresApp.ServerUri;

			// implement and start service 
			appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
			appiumLocalService.Start();

			// connecting appium
			var appiumOptions = new AppiumOptions() { PlatformName = "Windows" };
			var fullPathName = Path.GetFullPath(AppPath);
			appiumOptions.AddAdditionalCapability("app", fullPathName);

			// setting the options and initializating drivers
			driver = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOptions);

			// setting implicit WAIT 
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			// explecit WAIT
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
		}

		[OneTimeTearDown]
		public void OneTimeTearDownBase()
		{
			//closing and quiting the app
			driver.CloseApp();
			driver.Quit();

			//dispose 
			appiumLocalService.Dispose();

			//dispose the api
			this.testEventuresApp.Dispose();
		}
	}
}
