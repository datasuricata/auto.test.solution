using autotech.test.framework.Enums;
using autotech.test.hasta.Rules.Auction.Auctioneer;
using autotech.test.hasta.Rules.Auction.Manager;
using autotech.test.hasta.Rules.Auction.Watcher;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace autotech.test.hasta.Tests.Auction.Manager {
    public class ManagerTest {
        private IConfiguration configuration;
        private string Id { get; set; }

        public ManagerTest() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            configuration = builder.Build();
        }

        [Theory] 
        [InlineData(Browser.Firefox, "7b774fba-e94f-45b8-ae59-839ae9307010")]
        public void InitTest(Browser browser, string userId) {
            var api = new ApiStartRule();
            api.GenerateAuction();
            Id = api.OpenAuction();

            var auctioneer = new AuctioneerRule(configuration, browser);
            auctioneer.OpenBackOfficeSite(Id);

            var watcher = new WatcherRule(configuration, browser);
            watcher.OpenWatcherSite(Id, userId);

            var manager = new ManagerRule(configuration, browser);
            manager.OpenBackOfficeSite(Id);

            watcher.SendMinBid();
            manager.SendBid();
            watcher.SendMaxBid();
            manager.ChangeMinimalIncrement();
            watcher.SendMinBid();
            watcher.SendMaxBid();
            manager.RemoveFirstBid();
            manager.SendBid();
            manager.SendMessage("Vou finalizar o lote.");
            manager.ChangeTwice();
            watcher.SendMinBid();
            manager.ChangeTwice();
            manager.ChangeSale();
            manager.NextProduct();

            manager.SendMessage("Lote aberto, iniciem os lances");
            watcher.SendMinBid();
            manager.ChangeMaxIncrement();
            manager.SendBid();
            manager.SendMessage("Vou vender!");
            manager.ChangeTwice();
            watcher.SendMinBid();
            manager.SendBid();
            manager.EndAuction();
            manager.ChangeTwice();
            manager.ChangeConditional();
            manager.NextProduct();

            manager.SendMessage("Lote na promoção, aproveitem!");
            watcher.SendMinBid();
            manager.SendBid();
            watcher.SendMaxBid();
            manager.ChangeMaxIncrement();
            manager.SendBid();
            manager.SendBid();
            manager.SendMessage("Ops entra de lance a mais pelo operador, aguardem!");
            manager.RemoveFirstBid();
            watcher.SendMaxBid();
            manager.SendMessage("Vou vender!");
            manager.ChangeTwice();
            manager.ChangeSale();
            manager.NextProduct();

            manager.SendMessage("Apertem os cintos!");
            manager.ChangeNoOffer();
            manager.NextProduct();

            manager.SendMessage("Ultimo produto no leilão aproveitem!");
            manager.SendBid();
            watcher.SendMaxBid();
            manager.ChangeMaxIncrement();
            manager.SendBid();
            watcher.SendMaxBid();
            manager.SendMessage("Vou vender!");
            manager.ChangeTwice();
            manager.ChangeSale();

            manager.EndAuction();
            watcher.EndAuction();
            auctioneer.EndAuction();

            manager.CloseTest();
            watcher.CloseTest();
            auctioneer.CloseTest();

            Assert.True(true);
        }
    }
}
