using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace learningSelenium;

public class WorkingWithChrome
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
        Driver.Url = "https://test.qatechhub.com/";
    }

    [Test]
    public void VerifyTitleOfThePage()
    {

        string expectedTitle = "Test QA Tech Hub – Learning By Doing is the best way to learn!";
        String actualTitle = Driver.Title;

        Assert.AreEqual(expectedTitle, actualTitle);
        
    }
[TearDown]
public void TearDown(){
    Driver.Quit();
}

}