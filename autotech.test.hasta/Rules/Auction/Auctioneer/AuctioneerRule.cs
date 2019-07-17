using autotech.test.framework.Enums;
using autotech.test.framework.Extensions;
using autotech.test.hasta.Rules.Base;
using Microsoft.Extensions.Configuration;
using System;

namespace autotech.test.hasta.Rules.Auction.Auctioneer {
    public class AuctioneerRule : BaseRule {
        public AuctioneerRule(IConfiguration configuration, Browser browser) : base(configuration, browser) {
        }

        public void OpenBackOfficeSite(string auctionId) {
            driver.OpenPage(TimeSpan.FromSeconds(10), $"{Endpoints.auctioneer}/1/{auctionId}");
        }
    }
}
