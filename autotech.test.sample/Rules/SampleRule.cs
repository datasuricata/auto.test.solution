using autotech.test.framework.Enums;
using autotech.test.framework.Extensions;
using autotech.test.framework.Factory;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;

namespace autotech.test.sample.Rules {
    public class SampleRule {
        private IConfiguration configuration;
        private Browser browser;
        private IWebDriver driver;

        /// <summary>
        /// Inicia o construtor do case com todas as regras
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="browser"></param>
        public SampleRule(IConfiguration configuration, Browser browser) {
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

        // abre a página com tempo limite de carregamento
        public void OpenPage() 
            => driver.OpenPage(TimeSpan.FromSeconds(10), Endpoints.principal);

        // seta um texto no input html
        public void SetSearchText(string param) 
            => driver.SetText(By.Name("q"), param);

        // processa a chamada
        public void SubmitSearch() 
            => driver.Submit(By.Name("btnK"));

        // valida se vai encontrar o elemento pós processamento
        public void ValidSearch() 
            => driver.WaitFind(TimeSpan.FromSeconds(5), By.Id("rcnt"));

        // fecha a pagina
        public void ClosePage() 
            => driver.ClosePage();
    }
}