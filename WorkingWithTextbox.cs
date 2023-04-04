using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace learningSelenium;

public class WorkingWithTextbox
{

    IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();

        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);     // Time limit before finishing the pageload
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);    // 
        Driver.Url = "https://test.qatechhub.com/contact-us";
    }

    [Test]
    public void VerifyContactUsFormFill()
    {

        Driver.FindElement(By.Id("wpforms-20-field_0")).SendKeys("Marvin");
        Driver.FindElement(By.Id("wpforms-20-field_0-last")).SendKeys("Santos");
        Driver.FindElement(By.Id("wpforms-20-field_1")).SendKeys("test123@gmail.com");
        Driver.FindElement(By.Id("wpforms-20-field_2")).SendKeys("Testing This Area");
        Driver.FindElement(By.Name("wpforms[submit]")).Click();

        string expectedMessage = "Thanks for contacting us! We will be in touch with you shortly.";
        string actualMessage = Driver.FindElement(By.Id("wpforms-confirmation-20")).Text;
     
        Assert.AreEqual( expectedMessage , actualMessage ); 


    }
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }

}