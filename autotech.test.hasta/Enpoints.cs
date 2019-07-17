namespace autotech.test.hasta {
    /// <summary>
    /// Use esta classe para criar os apontamentos das rotas do seu site
    /// </summary>
    public static class Endpoints {
        /// <summary>
        /// Site principal
        /// </summary>
        public const string api = "https://auction-api-dev.azurewebsites.net/api/";
        public const string backoffice = "http://auction-web-dev.azurewebsites.net/backoffice/operador/1";
        public const string web = "http://auction-web-dev.azurewebsites.net/leilao/ao-vivo";
        public const string auctioneer = "http://auction-web-dev.azurewebsites.net/backoffice/leiloeiro";
    }

    public static class ApiActions {
        public const string consult = "Home/project/3/auctions";
        public const string closeAll = "Manager/bo/closeAuctions";
        public const string clearAll = "Manager/bo/clearAuctions";
        public const string generate = "Manager/test/generate";
        public const string open = "Manager/bo/auction";
        public const string end = "Manager/close";
    }
}