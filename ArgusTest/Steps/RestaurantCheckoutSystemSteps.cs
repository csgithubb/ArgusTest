using ArgusTest.Base;
using ArgusTest.Hooks.Settings;
using ArgusTest.Library;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ArgusTest.Steps
{
	[Binding]
	public class RestaurantCheckoutSystemSteps
	{		
		private string baseURL = "https://argustest.free.beeceptor.com";
		private Settings _settings;
		public RestaurantCheckoutSystemSteps(Settings settings) => _settings = settings;

		[Given(@"I navigate to Argus home page")]
		public void GivenINavigateToArgusHomePage()
		{			
			RestClient restClient = new RestClient();
			restClient.BaseUrl = new Uri(baseURL);

			RestRequest request = new RestRequest(baseURL, Method.GET);
			IRestResponse response = restClient.Execute(request);
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

		}

		[When(@"a group of '(.*)' orders '(.*)' '(.*)''(.*)' from restaurant")]
		public void WhenAGroupOfOrdersFromRestaurant(int person, int starters, int mains, decimal drinks)
		{
			var startersTotal = (starters * 4);
			var mainsTotal = (mains * 4);
			var drinksTotal = (drinks * 4);
			int taxTotal = 0;
			taxTotal = ((starters * 4) + (mains * 4)) / 10;
			var subtotal = (taxTotal + startersTotal + mainsTotal + drinksTotal) * person;

			RestClient restClient = new RestClient(baseURL);
			var request = new RestRequest("/Order/Total/P1", Method.POST);
			request.RequestFormat = DataFormat.Json;

			request.AddJsonBody(new Posts()
			{ starters = startersTotal, mains = mainsTotal, drinks = (int)drinksTotal, tax = taxTotal, total = (int)subtotal });

			var response = restClient.Execute<Posts>(request);
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}

		[When(@"a group of '(.*)' orders '(.*)' '(.*)'from restaurant then updates order")]
		public void WhenAGroupOfOrdersFromRestaurantThenUpdatesOrder(int person, int starters, int mains)
		{
			var startersTotal = (starters);
			var mainsTotal = (mains * 2);

			var subtotal = (startersTotal + mainsTotal) * person;

			RestClient restClient = new RestClient(baseURL);
			var request = new RestRequest("/Order/Total/P2", Method.POST);
			request.RequestFormat = DataFormat.Json;

			request.AddJsonBody(new Posts()
			{ starters = startersTotal, mains = mainsTotal, total = (int)subtotal });

			var response = restClient.Execute<Posts>(request);
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

			var putRequest = new RestRequest("/Order/Total/Put", Method.PUT);
			request.RequestFormat = DataFormat.Json;
			var updatedOrder = (mains * 2) * person;

			request.AddJsonBody(new Posts()
			{ total = (int)updatedOrder });

			var response2 = restClient.Execute<Posts>(putRequest);
			Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));

		}

		[When(@"a group of '(.*)' orders '(.*)' '(.*)''(.*)' then deletes item in order")]
		public void WhenAGroupOfOrdersThenDeletesItemInOrder(int p0, int p1, int p2, Decimal p3)
		{
			var deleteRequest = new RestRequest("/Order/Total/Put", Method.DELETE);
		}


		[Then(@"I should see the ""(.*)"" as ""(.*)""")]
		public void ThenIShouldSeeTheAs(string key, string value)
		{
			Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
		}

	

		


	}
}
