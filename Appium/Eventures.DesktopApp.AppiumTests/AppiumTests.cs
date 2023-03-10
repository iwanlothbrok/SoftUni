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
			var apiUrlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
			apiUrlField.Clear();

			//locating and clicking btn 
			var connectBtn = driver.FindElementByAccessibilityId("buttonConnect");
			connectBtn.Click();

			//wait and assert 
			var windowAppears = this.wait
				.Until(s => driver.PageSource.Contains("Connect to Eventures API"));
			Assert.IsTrue(windowAppears);

			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");

			var messageAppears = this.wait
				.Until(s => statusTextBox.Text.Contains("Error: Value cannot be null."));
			Assert.IsTrue(messageAppears);
		}

		[Test, Order(2)]
		public void Test_Connect_WithInvalidUrl()
		{
			// locating url
			var apiUrlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
			string apiUrl = apiUrlField.Text;

			UriBuilder builder = new UriBuilder(apiUrl);
			builder.Port = 7591; // Change the port number to 8080
			string newApiUrl = builder.Uri.ToString();

			apiUrlField.SendKeys(newApiUrl);

			//locating and clicking btn 
			var connectBtn = driver.FindElementByAccessibilityId("buttonConnect");
			connectBtn.Click();

			//wait and assert 
			var windowAppears = this.wait
				.Until(s => driver.PageSource.Contains("Connect to Eventures API"));
			Assert.IsTrue(windowAppears);


			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");
			var messageAppears = this.wait
				.Until(s => statusTextBox.Text.Contains("Error: HTTP error `No connection"));
			Assert.IsTrue(messageAppears);
		}

		[Test, Order(3)]
		public void Test_Connect_WithValidUrl()
		{
			// locating url
			var apiUrlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
			apiUrlField.Clear();
			apiUrlField.SendKeys("http://127.0.0.1/api");

			//locating and clicking btn 
			var connectBtn = driver.FindElementByAccessibilityId("buttonConnect");
			connectBtn.Click();

			//wait and assert 
			var windowAppears = this.wait
				.Until(s => driver.PageSource.Contains(EventBoardWindowName));
			Assert.IsTrue(windowAppears);

			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");
			var messageAppears = this.wait
				.Until(s => statusTextBox.Text.Contains("Connected to the Web API."));
			Assert.IsTrue(messageAppears);
		}

		[Test, Order(4)]
		public void Test_Register_Invalid()
		{
			// getting btns
			var createBtn = driver.FindElementByAccessibilityId("buttonCreate");
			Assert.IsFalse(createBtn.Enabled);
			var reloadBtn = driver.FindElementByAccessibilityId("buttonReload");
			Assert.IsFalse(reloadBtn.Enabled);

			// register 
			var registerBtn = driver.FindElementByAccessibilityId("buttonRegister");
			registerBtn.Click();


			//textBoxUsername
			var usernameField = driver.FindElementByAccessibilityId("textBoxUsername");
			usernameField.Clear();

			//email
			var emailField = driver.FindElementByAccessibilityId("textBoxEmail");
			emailField.Clear();

			//pass
			var passwordField = driver.FindElementByAccessibilityId("textBoxPassword");
			passwordField.Clear();
			passwordField.SendKeys(this.password);

			//confirm pass
			var confirmPassField = driver.FindElementByAccessibilityId("textBoxConfirmPassword");
			confirmPassField.Clear();
			confirmPassField.SendKeys(this.password);

			//first name
			var firstNameField = driver.FindElementByAccessibilityId("textBoxFirstName");
			firstNameField.Clear();
			firstNameField.SendKeys("User");

			//last name
			var lastNameField = driver.FindElementByAccessibilityId("textBoxLastName");
			lastNameField.Clear();
			lastNameField.SendKeys("Userov");


			//last name
			var confirm = driver.FindElementByAccessibilityId("buttonRegisterConfirm");
			confirm.Click();

			// check if its right 
			Assert.True(driver.PageSource.Contains(EventBoardWindowName));


			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");
			var messageAppears = this.wait
				//check this message 
				.Until(s => statusTextBox.Text.Contains("Connected to the Web API."));
			Assert.IsTrue(messageAppears);

			var eventsInDb = this.dbContext.Events.Count();

			var asd = this.wait
			.Until(s => statusTextBox.Text.Contains("Error: Value cannot be null."));
			Assert.IsTrue(messageAppears);

			Assert.IsTrue(createBtn.Enabled);
			Assert.IsTrue(reloadBtn.Enabled);
		}

		[Test, Order(5)]
		public void Test_Register()
		{
			// getting btns
			var createBtn = driver.FindElementByAccessibilityId("buttonCreate");
			Assert.IsFalse(createBtn.Enabled);
			var reloadBtn = driver.FindElementByAccessibilityId("buttonReload");
			Assert.IsFalse(reloadBtn.Enabled);

			// register 
			var registerBtn = driver.FindElementByAccessibilityId("buttonRegister");
			registerBtn.Click();


			//textBoxUsername
			var usernameField = driver.FindElementByAccessibilityId("textBoxUsername");
			usernameField.Clear();
			usernameField.SendKeys(this.username);

			//email
			var emailField = driver.FindElementByAccessibilityId("textBoxEmail");
			emailField.Clear();
			emailField.SendKeys(this.username + "@mail.com");

			//pass
			var passwordField = driver.FindElementByAccessibilityId("textBoxPassword");
			passwordField.Clear();
			passwordField.SendKeys(this.password);

			//confirm pass
			var confirmPassField = driver.FindElementByAccessibilityId("textBoxConfirmPassword");
			confirmPassField.Clear();
			confirmPassField.SendKeys(this.password);

			//first name
			var firstNameField = driver.FindElementByAccessibilityId("textBoxFirstName");
			firstNameField.Clear();
			firstNameField.SendKeys("User");

			//last name
			var lastNameField = driver.FindElementByAccessibilityId("textBoxLastName");
			lastNameField.Clear();
			lastNameField.SendKeys("Userov");


			//last name
			var confirm = driver.FindElementByAccessibilityId("buttonRegisterConfirm");
			confirm.Click();

			// check if its right 
			Assert.True(driver.PageSource.Contains(EventBoardWindowName));


			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");
			var messageAppears = this.wait
				//check this message 
				.Until(s => statusTextBox.Text.Contains("Connected to the Web API."));
			Assert.IsTrue(messageAppears);

			var eventsInDb = this.dbContext.Events.Count();

			Assert.AreEqual($"Load succsessful: {eventsInDb} events loaded.", statusTextBox.Text);

			Assert.IsTrue(createBtn.Enabled);
			Assert.IsTrue(reloadBtn.Enabled);
		}

		[Test, Order(6)]
		public void Test_Login_Invalid()
		{
		}

		[Test, Order(7)]
		public void Test_Login()
		{
			// login 
			var loginBtn = driver.FindElementByAccessibilityId("buttonLogin");
			loginBtn.Click();

			//user name
			var userName = driver.FindElementByAccessibilityId("textBoxUsername");
			userName.Clear();
			userName.SendKeys("User");

			//pass
			var passwordField = driver.FindElementByAccessibilityId("textBoxPassword");
			passwordField.Clear();
			passwordField.SendKeys(this.password);

			// confirm login 
			var loginConfirmBtn = driver.FindElementByAccessibilityId("buttonLoginConfirm");
			loginConfirmBtn.Click();

			// check if its right 
			Assert.True(driver.PageSource.Contains(EventBoardWindowName));


			var statusTextBox = driver.FindElementByXPath("/Window/StatusBar/Text");
			var messageAppears = this.wait
				//check this message 
				.Until(s => statusTextBox.Text.Contains("Connected to the Web API."));
			Assert.IsTrue(messageAppears);

			var eventsInDb = this.dbContext.Events.Count();

			Assert.AreEqual($"Load succsessful: {eventsInDb} events loaded.", statusTextBox.Text);
		}

		[Test]
		public void Test_CreateEvent()
		{
			// getting the events 
			var eventsCountBefore = this.dbContext.Events.Count();

			// create event
			var createEvent = driver.FindElementByAccessibilityId("buttonCreate");
			createEvent.Click();

			Assert.That(driver.PageSource.Contains(CreateWindowNewEvent));

			// fill event name
			var eventName = "Fun Event" + DateTime.Now.Ticks;
			var nameField = driver.FindElementByAccessibilityId("textBoxName");
			nameField.Clear();
			nameField.SendKeys(eventName);

			// fill event place
			var eventPlace = "Beach";
			var placeField = driver.FindElementByAccessibilityId("textBoxPlace");
			placeField.SendKeys(eventPlace);
		}

		[Test]
		public void Test_CreateEvent_Invalid()
		{
		}
	}
}
