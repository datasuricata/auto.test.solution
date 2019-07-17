using autotech.test.framework.Enums;
using autotech.test.framework.Extensions;
using autotech.test.hasta.Rules.Base;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;

namespace autotech.test.hasta.Rules.Auction.Auctioneer {
    public class AuctioneerRule : BaseRule {
        public AuctioneerRule(IConfiguration configuration, Browser browser) : base(configuration, browser) {
        }

        public void OpenBackOfficeSite(string auctionId) {
            driver.OpenPage(TimeSpan.FromSeconds(10), $"{Endpoints.auctioneer}/1/{auctionId}");
        }

        public void EndAuction() {
            driver.WaitBy(TimeSpan.FromSeconds(5), (d) => d.IsDisplayed(By.XPath("//button[contains(.,'Confirmar')]")));
            driver.Click(By.XPath("//button[contains(.,'Confirmar')]"));
        }

        public void CloseTest() {
            driver.ClosePage();
        }
    }
}
