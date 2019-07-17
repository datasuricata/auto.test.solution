using autotech.test.framework.Enums;
using autotech.test.framework.Factory;
using autotech.test.framework.Requests;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace autotech.test.hasta.Rules.Base {
    public class BaseRule {
        private readonly IConfiguration configuration;
        private readonly Browser browser;

        protected IWebDriver driver;

        public BaseRule(IConfiguration configuration, Browser browser) {
            this.configuration = configuration;
            this.browser = browser;

            string path = null;

            // carrega os driver da maquina de acordo com o arquivo de configuração {appsettings.json}
            if (browser == Browser.Firefox)
                path = configuration.GetSection("Drivers:Firefox").Value;
            else
                path = configuration.GetSection("Drivers:Chrome").Value;

            // inicia o driver para inicio da automatização
            driver = DriveFactory.CreateDriver(browser, path, false);
        }
    }
}
