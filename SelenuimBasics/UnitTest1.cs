using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumBasics
{
    public class GoogleSmokeTests
    {
        private IWebDriver _driver = null!;
        private WebDriverWait _wait = null!;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            _driver = new ChromeDriver(options); // Selenium Manager handles driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Can_Open_Google_And_See_Title()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
            _wait.Until(d => d.Title.Length > 0);
            Assert.That(_driver.Title, Does.Contain("Google"));
        }
    }
}
