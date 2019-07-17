using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace autotech.test.framework.Extensions {
    public static class DriveExtensions {

        /// <summary>
        /// Carrega página da web
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="timeOut">Tempo de time out</param>
        /// <param name="url">Rota do site</param>
        public static void OpenPage(this IWebDriver driver, TimeSpan timeOut, string url) {
            driver.Manage().Timeouts().PageLoad = timeOut;
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Fecha tudo relacionado com o navegador
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        public static void ClosePage(this IWebDriver driver) {
            driver.Quit();
            driver = null;
        }

        /// <summary>
        /// Retorna o texto de algum elemento
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo de elemento (classes, ids, css...)</param>
        /// <returns>Informações do elemento html</returns>
        public static string GetText(this IWebDriver driver, By by) {
            IWebElement element = driver.FindElement(by);
            return element.Text;
        }

        /// <summary>
        /// Injeta um valor de texto em um elemento html
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        /// <param name="text">Valor de text</param>
        public static void SetText(this IWebDriver driver, By by, string text) {
            IWebElement element = driver.FindElement(by);
            element.SendKeys(text);
        }

        /// <summary>
        /// Limpa valores em um elemento html
        /// </summary>
        /// <param name="by">Tipo do elemento</param>
        /// <param name="text">Valor de text</param>
        public static void Clear(this IWebDriver driver, By by) {
            IWebElement element = driver.FindElement(by);
            element.Clear();
        }

        /// <summary>
        /// Efetua um click em algum elemento html na tela
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        public static void Click(this IWebDriver driver, By by) {
            driver.FindElement(by).Click();
        }

        /// <summary>
        /// Movimento o mouse até o elemento html
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        public static void MoveTo(this IWebDriver driver, By by) {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(by)).Perform();
        }

        /// <summary>
        /// Retorna se o elemento html esta habilitado ou não
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        public static bool IsEnabled(this IWebDriver driver, By by) {
            return driver.FindElement(by).Enabled;
        }

        /// <summary>
        /// Retorna se o elemento html esta sendo exibido ou não
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        public static bool IsDisplayed(this IWebDriver driver, By by) {
            return driver.FindElement(by).Displayed;
        }

        /// <summary>
        /// Envia um submit de acordo com o navegador
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="by">Tipo do elemento</param>
        public static void Submit(this IWebDriver driver, By by) {
            IWebElement element = driver.FindElement(by);

            if (!(driver is InternetExplorerDriver))
                element.Submit();
            else
                element.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Aguarda com time out
        /// Função pode buscar um elemento, setar um elemento...
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="timeOut">Tempo de time out</param>
        /// <param name="func">Lambda (d) => d.FindElement(By)</param>
        public static void WaitTime(this IWebDriver driver, TimeSpan timeOut) {
            driver.Manage().Timeouts().ImplicitWait = timeOut;
        }

        /// <summary>
        /// Executa um pós processamento com time out em determinada função
        /// Função pode buscar um elemento, setar um elemento...
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="timeOut">Tempo de time out</param>
        /// <param name="func">Lambda (d) => d.FindElement(By)</param>
        public static bool WaitBy(this IWebDriver driver, TimeSpan timeOut, Func<IWebDriver, bool> func) {
            WebDriverWait wait = new WebDriverWait(driver, timeOut);
            return wait.Until(func);
        }

        /// <summary>
        /// Executa um pós processamento com time out e faz a busca de determinado elemento html
        /// </summary>
        /// <param name="driver">Interface criada do WebDriver</param>
        /// <param name="timeOut">Tempo de time out</param>
        /// <param name="criteria">Tipo do elemento</param>
        public static bool WaitFind(this IWebDriver driver, TimeSpan timeOut, By criteria) {
            return WaitBy(driver, timeOut, (d) => d.FindElement(criteria) != null);
        }
    }
}
