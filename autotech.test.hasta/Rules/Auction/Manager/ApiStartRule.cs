using autotech.test.framework.Requests;
using System.Threading.Tasks;

namespace autotech.test.hasta.Rules.Auction.Manager {
    public class ApiStartRule {
        private RestRequest Rest => new RestRequest();
        private string auction;

        public void GenerateAuction() {
            Task.Run(async () => { await Rest.Get<dynamic>(Endpoints.api, ApiActions.closeAll); }).Wait();
            Task.Run(async () => { await Rest.Get<dynamic>(Endpoints.api, ApiActions.clearAll); }).Wait();
            Task.Run(async () => { await Rest.Get<dynamic>(Endpoints.api, ApiActions.generate); }).Wait();
        }

        public string OpenAuction() {
            Task.Run(async () => {
                var request = await Rest.Get<dynamic>(Endpoints.api, ApiActions.consult);
                auction = (string)request[0].auctionReferenceId;
            }).Wait();

            Task.Run(async () => { await Rest.Get<dynamic>(Endpoints.api, $"{ApiActions.open}/{auction}"); }).Wait();
            return auction;
        }
    }
}
