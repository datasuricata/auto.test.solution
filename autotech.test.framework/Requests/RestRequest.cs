using System.Threading.Tasks;

namespace autotech.test.framework.Requests {
    public class RestRequest {

        #region [ Task Async ]

        public async Task<T> Get<T>(string baseUrl, string uri, string token = "") {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Get(uri, token);

            return result;
        }

        public async Task<T> GetById<T>(string baseUrl, string uri, string id, string token = "") {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.GetById(uri, id, token);

            return result;
        }

        public async Task<T> Post<T>(string baseUrl, string uri, object command, string token = "") {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Post(uri, command, token);

            return result;
        }

        public async Task<T> Put<T>(string baseUrl, string uri, object command, string token = "") {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Put(uri, command, token);

            return result;
        }

        public async Task PostAnonymous<T>(string baseUrl, string uri, object command, string token = "") {
            var request = new DataRequest<T>(baseUrl);
            await request.PostAnonymous(uri, command);

        }

        #endregion
    }
}
