using autotech.test.framework.Enums;
using autotech.test.framework.Extensions;
using autotech.test.hasta.Rules.Base;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;

namespace autotech.test.hasta.Rules.Auction.Manager {
    public class ManagerRule : BaseRule {
        public ManagerRule(IConfiguration configuration, Browser browser) : base(configuration, browser) {
        }

        public void OpenBackOfficeSite(string auctionId) {
            driver.OpenPage(TimeSpan.FromSeconds(10), $"{Endpoints.backoffice}/{auctionId}");
        }

        public void SendBid() {
            driver.Click(By.XPath("//div[2]/div/button/span"));
        }

        public void ChangeSale() {
            driver.Click(By.XPath("//button[contains(.,'VENDIDO')]"));
        }

        public void ChangeTwice() {
            driver.Click(By.XPath("//button[contains(.,'DOU-LHE DUAS')]"));
        }

        public void ChangeConditional() {
            driver.Click(By.XPath("//button[contains(.,'CONDICIONAL')]"));
        }

        public void ChangeNoOffer() {
            driver.Click(By.XPath("//button[contains(.,'SEM OFERTAS')]"));
        }

        public void RemoveFirstBid() {
            driver.Click(By.CssSelector(".dark:nth-child(1) .remove > .fa"));
            driver.WaitBy(TimeSpan.FromSeconds(5), (d) => d.IsDisplayed(By.XPath("//button[contains(.,'Confirmar')]")));
            driver.Click(By.XPath("//button[contains(.,'Confirmar')]"));
        }

        public void NextProduct() {
            driver.Click(By.XPath("//span[contains(.,'Próximo lote')]"));
        }

        public void ChangeMinimalIncrement() {
            driver.Click(By.XPath("//div[4]/div/div[2]/div[6]/button/span"));
        }

        public void ChangeMaxIncrement() {
            driver.Click(By.XPath("//div[4]/div/div[2]/div[2]/button/span"));
        }

        public void SendMessage(string message) {
            driver.Clear(By.XPath("//div[2]/div/form/input"));
            driver.SetText(By.XPath("//div[2]/div/form/input"), message);
            driver.Click(By.XPath("//div[2]/div/form/button"));
            driver.WaitBy(TimeSpan.FromSeconds(5), (d) => d.IsDisplayed(By.XPath("//button[contains(.,'Confirmar')]")));
            driver.Click(By.XPath("//button[contains(.,'Confirmar')]"));
        }

        public void EndAuction() {
            driver.Click(By.XPath("//span[contains(.,' Finalizar')]"));
            driver.WaitBy(TimeSpan.FromSeconds(5), (d) => d.IsDisplayed(By.XPath("//button[contains(.,'Confirmar')]")));
            driver.Click(By.XPath("//button[contains(.,'Confirmar')]"));
        }

        public void CloseTest() {
            driver.ClosePage();
        }
    }
}
