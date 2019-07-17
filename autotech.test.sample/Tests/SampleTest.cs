using autotech.test.framework.Enums;
using autotech.test.sample.Rules;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace autotech.test.sample.Tests {
    public class SampleTest {
        private IConfiguration configuration;

        public SampleTest() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            configuration = builder.Build();
        }

        //[Fact] // Use isto para criar um metodo simples de test
        [Theory] // Use isto para criar varios entradas em um unico test
        [InlineData(Browser.Firefox, "carros")]
        [InlineData(Browser.Firefox, "animais")]
        [InlineData(Browser.Firefox, "frutas")]
        [InlineData(Browser.Firefox, "refrigerantes")]
        [InlineData(Browser.Chrome, "carros")]
        [InlineData(Browser.Chrome, "animais")]
        [InlineData(Browser.Chrome, "frutas")]
        [InlineData(Browser.Chrome, "refrigerantes")]
        public void TestInitial(Browser browser, string text) {

            var rule = new SampleRule(configuration, browser);

            rule.OpenPage();
            rule.SetSearchText(text);
            rule.SubmitSearch();
            rule.ValidSearch();
            rule.ClosePage();

            //rule.SampleRuleTeste();

            Assert.True(true); // insira aqui sua validação do test
        }
    }
}