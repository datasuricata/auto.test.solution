using autotech.test.framework.Enums;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace autotech.test.framework.Requests {
    public class BaseRequest {
        public BaseRequest(string baseUri) {
            this.baseUri = baseUri;
        }

        #region [ properties ]

        protected string baseUri;
        private HttpClient Client = new HttpClient();

        #endregion

        #region [ send async ]

        protected async Task<HttpResponseMessage> SendAsync(RequestMethod typerequest, string requestUri, object parametros = null, string token = "") {
            Client.BaseAddress = new Uri(baseUri);
            Client.Timeout = TimeSpan.FromMinutes(30);

            switch (typerequest) {
                case RequestMethod.Get: {
                        if (!string.IsNullOrEmpty(token))
                            return await Get(requestUri, token);
                        return await Get(requestUri);
                    }
                case RequestMethod.Post: {
                        if (!string.IsNullOrEmpty(token))
                            return await Post(requestUri, parametros, token);
                        return await Post(requestUri, parametros);
                    }
                case RequestMethod.Put: {
                        if (!string.IsNullOrEmpty(token))
                            return await Put(requestUri, parametros, token);
                        return await Put(requestUri, parametros);
                    }
                case RequestMethod.Delete: {
                        return null;
                    }
            }
            return null;
        }

        #endregion

        #region [ get ]

        private async Task<HttpResponseMessage> Get(string requestUri, string token = "") {
            using (Client) {
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token))
                    Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                return await Client.GetAsync(requestUri);
            }
        }

        #endregion

        #region [ post ]

        private async Task<HttpResponseMessage> Post(string requestUri, object parameters, string token = "") {
            using (Client) {
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token))
                    Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var json = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                return await Client.PostAsync(requestUri, content);
            }
        }

        #endregion

        #region [ put ]

        private async Task<HttpResponseMessage> Put(string requestUri, object parameters, string token = "") {
            using (Client) {
                if (!string.IsNullOrEmpty(token))
                    Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var json = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                return await Client.PutAsync(requestUri, content);
            }
        }

        #endregion
    }
}
