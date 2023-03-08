using System;
using System.Linq;

using NUnit.Framework;

namespace Eventures.DesktopApp.AppiumTests
{
	public class AppiumTests : AppiumTestsBase
	{
		private string username = "user" + DateTime.Now.Ticks.ToString().Substring(10);
		private string password = "pass" + DateTime.Now.Ticks.ToString().Substring(10);
		private const string EventBoardWindowName = "Event Board";
		private const string CreateWindowNewEvent = "Create a New Event";
		private const string RegisterAUserWindowName = "Register a New User";

		[Test, Order(1)]
		public void Test_Connect_WithEmptyUrl()
		{
			// locating url
			var apiUrlField = driver.FindElementByAccessibilityId("texBoxApiUrl");
			apiUrlField.Clear();

			//locating and clicking btn 
			var connectBtn = driver.FindElementByAccessibilityId("buttonConnect");
			connectBtn.Click();

			//wait and assert 
			var windowAppears = this.wait
				.Until(s => driver.PageSource.Contains("Connect to Eventures API"));
			Assert.IsTrue(windowAppears);
		}

		[Test, Order(2)]
		public void Test_Connect_WithInvalidUrl()
		{
		}

		[Test, Order(3)]
		public void Test_Connect_WithValidUrl()
		{
		}

		[Test, Order(4)]
		public void Test_Register_Invalid()
		{
		}

		[Test, Order(5)]
		public void Test_Register()
		{
		}

		[Test, Order(6)]
		public void Test_Login_Invalid()
		{
		}

		[Test, Order(7)]
		public void Test_Login()
		{
		}

		[Test]
		public void Test_CreateEvent()
		{
		}

		[Test]
		public void Test_CreateEvent_Invalid()
		{
		}
	}
}
