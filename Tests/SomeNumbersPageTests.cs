using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverCalculatorPOM.Pages;

namespace WebDriverCalculatorPOM.Tests
{
    public class SumNumberPageTests : BaseTest
    {

        private SomeNumbersPage page;

        [SetUp]
        public void Setup()
        {
            
            this.page = new SomeNumbersPage(driver);
            page.Open();
        }

        

        [Test]
        public void Test_SumNumberPage_CheckTitle()
        {

            Assert.That(page.GetPageTitle, Is.EqualTo("Number Calculator"));
        }

        [Test]
        public void Test_SumNumberPage_SumTwoPositiveNumbers()
        {

            var actualResult = page.CalculateNumbers("5", "+", "15");
            Assert.That(actualResult, Is.EqualTo("Result: 20"));
        }

        [Test]
        public void Test_SumNumberPage_MultiplyTwoPositiveNumbers()
        {

            var actualResult = page.CalculateNumbers("3", "*", "5");
            Assert.That(actualResult, Is.EqualTo("Result: 15"));
        }

        [Test]
        public void Test_SumNumberPage_SubstractTwoPositiveNumbers()
        {

            var actualResult = page.CalculateNumbers("8", "-", "4");
            Assert.That(actualResult, Is.EqualTo("Result: 4"));
        }

        [Test]
        public void Test_SumNumberPage_DivideTwoPositiveNumbers()
        {

            var actualResult = page.CalculateNumbers("20", "/", "2");
            Assert.That(actualResult, Is.EqualTo("Result: 10"));
        }

        [Test]
        public void Test_SumNumberPage_SumTwoNegativeNumbers()
        {

            var actualResult = page.CalculateNumbers("-9", "+", "-5");
            Assert.That(actualResult, Is.EqualTo("Result: -14"));
        }

        [Test]
        public void Test_SumNumberPage_SubstractTwoNegativeNumbers()
        {

            var actualResult = page.CalculateNumbers("-9", "-", "-5");
            Assert.That(actualResult, Is.EqualTo("Result: -4"));
        }

        [Test]
        public void Test_SumNumberPage_MultiplyTwoNegativeNumbers()
        {

            var actualResult = page.CalculateNumbers("-2", "*", "-6");
            Assert.That(actualResult, Is.EqualTo("Result: 12"));
        }

        [TestCase("5","+","15","Result: 20")]
        [TestCase("3","*","5","Result: 15")]
        [TestCase("8","-","4","Result: 4")]
        [TestCase("20","/","2","Result: 10")]
        [TestCase("-9","+","-5","Result: -14")]
        [TestCase("-9","-","-5","Result: -4")]
        [TestCase("-2","*","-6","Result: 12")]

        public void Test_NumberPage_CalculateNumbers(
            string firstValue, string operation, string secondValue, string result)
        {
            var actualResult = page.CalculateNumbers(firstValue, operation, secondValue);   
            Assert.That(actualResult, Is.EqualTo(result));
        }
        

    }

}