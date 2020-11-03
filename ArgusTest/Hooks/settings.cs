using ArgusTest.Base;
using RestSharp;

namespace ArgusTest.Hooks.Settings
{
	public class Settings
    {
        public IRestResponse<Posts> Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
    }
}
