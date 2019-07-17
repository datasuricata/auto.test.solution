using autotech.test.framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace autotech.test.framework.Factory {
    public static class DriveFactory {

        /// <summary>
        /// Cria um novo web driver
        /// </summary>
        /// <param name="browser">browser que deseja executar</param>
        /// <param name="pathUrl">url do site que deseja executar</param>
        /// <param name="less">Ativa modo sem janela de navegação</param>
        /// <returns>Injeção Selenium WebDriver</returns>
        public static IWebDriver CreateDriver(Browser browser, string pathUrl, bool less = false) {
            IWebDriver driver = null;

            switch (browser) {
                case Browser.Firefox:
                    var fo = new FirefoxOptions();
                    if (less)
                        fo.AddArgument("--headless");
                    driver = new FirefoxDriver(pathUrl, fo);
                    break;
                case Browser.Chrome:
                    var co = new ChromeOptions();
                    if (less)
                        co.AddArgument("--headless");
                    driver = new ChromeDriver(pathUrl, co);
                    break;
            }

            return driver;
        }
    }
}
