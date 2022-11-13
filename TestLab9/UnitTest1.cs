using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System;

namespace TestLab9
{
    public class Tests
    {
        private WebDriver GetChromeDriver()
        {
            return new ChromeDriver(DriverPath, new ChromeOptions());
        }
        private WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"E:\WebDrivers\Chrome";

        [SetUp]
        public void SetUp() 
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void ICanWin()
        {
            WebDriver.Url = "https://pastebin.com";
            WebDriver.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");
            WebDriver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            WebDriver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();
            WebDriver.FindElement(By.Id("postform-name")).SendKeys("helloweb");
            WebDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();
            TearDown();
        }

        [Test]
        public void BringItOn()
        {
            WebDriver.Url = "https://pastebin.com";

            WebDriver.FindElement(By.Id("postform-text")).SendKeys("git config --global user.name  \"New Sheriff in Town\" \ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") \ngit push origin master --force");

            WebDriver.FindElement(By.Id("select2-postform-format-container")).Click();
            WebDriver.FindElement(By.XPath("//li[text()='Bash']")).Click();

            WebDriver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            WebDriver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            WebDriver.FindElement(By.Id("postform-name")).SendKeys("how to gain dominance among developers");
            WebDriver.FindElement(By.XPath("//button[@class='btn -big']")).Click();

            IWebElement syntaxHighlighting = WebDriver.FindElement(By.XPath("//a[text()='Bash']"));
            IWebElement codeFirstLine = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[1]/div/span[1]"));
            IWebElement codeSecondLine = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[2]/div/span[1]"));
            IWebElement codeThirdLine = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[3]/div/span[1]"));

            Assert.That(WebDriver.Title, Is.EqualTo("how to gain dominance among developers - Pastebin.com"));
            Assert.Multiple(() =>
            {
                Assert.That(syntaxHighlighting.Text, Is.EqualTo("Bash"));
                Assert.That(codeFirstLine.Text, Is.EqualTo("git config"));
                Assert.That(codeSecondLine.Text, Is.EqualTo("git reset"));
                Assert.That(codeThirdLine.Text, Is.EqualTo("git push"));
            });
            TearDown();
        }

        [Test]
        public void MyOwnTest()
        {
            WebDriver.Url = "https://lufthansa.com";
            WebDriver.FindElement(By.Id("nav")).Click();
            WebDriver.FindElement(By.LinkText("Багаж")).Click();
            WebDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[2]/div/div[7]/div/div[2]/div[2]/div[4]/a"));
            TearDown(); 
        }
    }   
}