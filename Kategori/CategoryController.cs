using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace DolanKuyDesktopPalingbaru.Kategori
{
    public class CategoryController : MyController
    {
        String token;
        public CategoryController(IMyView _myView) : base(_myView)
        {

        }

        public async void getCategory()
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint("api/category")
                .setRequestMethod(HttpMethod.Get);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
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
                .setEndpoint("api/category/" + _locationsId)
                .setRequestMethod(HttpMethod.Get);
                //.setEndpoint("api/category/update/" + _categoryId)
                //.setRequestMethod(HttpMethod.Put);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        //Delete
        public async void deleteService(int _category_id)
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();
            var req = request
                .buildHttpRequest()
                .setEndpoint("api/category/delete/" + _category_id)
                .setRequestMethod(HttpMethod.Delete);
            //client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine(response.getHttpResponseMessage().ToString());
            //Console.WriteLine(response.getJObject()["token"]);
            //client.setAuthorizationToken(response.getJObject()["access_token"].ToString());

        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setCategory", _response.getParsedObject<RootCategory>().category);
            }
        }

        public async void postCategory(string _name, string _token)
        {
            var client = new ApiClient("http://127.0.0.1:8000/");
            var request = new ApiRequestBuilder();
            this.token = _token;
            //string token = "";
            var req = request
                .buildHttpRequest()
                .addParameters("name", _name)
                .setEndpoint("api/category/create")
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(_token);
            client.setOnSuccessRequest(setViewCategoryStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

        }

        private void setViewCategoryStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("setCategoryStatus", this.token);
            }
        }
    }
}
