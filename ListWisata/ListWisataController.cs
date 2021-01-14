using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.ListWisata
{
    class ListWisataController : MyController
    {
        public ListWisataController(IMyView _myView) : base(_myView)
        {

        }

        public async void getLocation()
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/locations")
                .setRequestMethod(HttpMethod.Get);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setLocation", _response.getParsedObject<RootLocation>().locations);
            }
        }

        //Update
        public async void putCategory(int _locationsId)
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();
            //String _categoryName, int _categoryId,
            var req = request
                .buildHttpRequest()
                //.addParameters("name", _categoryName)
                .setEndpoint("api/locations/" + _locationsId)
                .setRequestMethod(HttpMethod.Get);
            //.setEndpoint("api/category/update/" + _categoryId)
            //.setRequestMethod(HttpMethod.Put);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        //Delete
        public async void deleteService(int _locations_id)
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();
            var req = request
                .buildHttpRequest()
                .setEndpoint("api/locations/delete/" + _locations_id)
                .setRequestMethod(HttpMethod.Delete);
            //client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine(response.getHttpResponseMessage().ToString());
            //Console.WriteLine(response.getJObject()["token"]);
            //client.setAuthorizationToken(response.getJObject()["access_token"].ToString());

        }
    }
}
