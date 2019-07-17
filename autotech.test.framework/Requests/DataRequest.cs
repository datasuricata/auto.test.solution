using autotech.test.framework.Enums;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace autotech.test.framework.Requests {
    public class DataRequest<T> : BaseRequest {
        public DataRequest(string baseUri) : base(baseUri) {
        }

        //private async Task HandleResponse(HttpResponseMessage response) {
        //    if (!response.IsSuccessStatusCode) {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var errors = JsonConvert.DeserializeObject<MessageCommand>(content);

        //        if (response.StatusCode == HttpStatusCode.BadRequest) {
        //            DomainException.When(errors == null, "Ops! falha na requisição");
        //            DomainException.When(!string.IsNullOrEmpty(errors.Message), errors.Message);
        //            DomainException.When(errors.Errors.Any(), string.Join("/n", errors.Errors.Select(x => x.Value).ToArray()));
        //        }
        //    }
        //}

        public async Task<T> Get(string endpoint, string token = "") {
            var response = await SendAsync(RequestMethod.Get, endpoint, null, token);
            var retorno = await response.Content.ReadAsStringAsync();
          //  await HandleResponse(response);

            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task<T> GetById(string endpoint, string id, string token = "") {
            var response = await SendAsync(RequestMethod.Get, $"{endpoint}?id={id}", null, token);
            var retorno = await response.Content.ReadAsStringAsync();
          //  await HandleResponse(response);

            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task<T> Put(string endpoint, object command, string token) {
            var response = await SendAsync(RequestMethod.Put, endpoint, command, token);
            var retorno = await response.Content.ReadAsStringAsync();
          //  await HandleResponse(response);

            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task<T> Post(string endpoint, object command, string token = "") {
            var response = await SendAsync(RequestMethod.Post, endpoint, command, token);
            var retorno = await response.Content.ReadAsStringAsync();
          //  await HandleResponse(response);

            return JsonConvert.DeserializeObject<T>(retorno);
        }

        public async Task PostAnonymous(string endpoint, object command, string token = "") {
            var response = await SendAsync(RequestMethod.Post, endpoint, command, token);
            var retorno = await response.Content.ReadAsStringAsync();
          //  await HandleResponse(response);
        }
    }
}
