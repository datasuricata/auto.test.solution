using autotech.test.framework.Enums;
using autotech.test.framework.Extensions;
using autotech.test.hasta.Rules.Base;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;

namespace autotech.test.hasta.Rules.Auction.Watcher {
    public class WatcherRule : BaseRule {
        public WatcherRule(IConfiguration configuration, Browser browser) : base(configuration, browser) {
        }

        public void OpenWatcherSite(string auctionId, string userId) {
            driver.OpenPage(TimeSpan.FromSeconds(10), $"{Endpoints.web}/{auctionId}/{userId}");
        }

        #region [ bids ]

       public void SendMinBid() {
            driver.Click(By.XPath("//div[2]/button/span"));
        }

        public void SendMaxBid() {
            driver.Click(By.XPath("//button[3]/span"));
        }

        public void EndAuction() {
            driver.WaitBy(TimeSpan.FromSeconds(5), (d) => d.IsDisplayed(By.XPath("//button[contains(.,'Confirmar')]")));
            driver.Click(By.XPath("//button[contains(.,'Confirmar')]"));
        }

        public void CloseTest() {
            driver.ClosePage();
        }

        #endregion
    }
}
