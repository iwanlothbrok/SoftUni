using System;
using System.Linq;

using NUnit.Framework;

namespace Eventures.DesktopApp.AppiumTests
{
    public class AppiumTests : AppiumTestsBase
    {
        [Test, Order(1)]
        public void Test_Connect_WithEmptyUrl()
        {
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
