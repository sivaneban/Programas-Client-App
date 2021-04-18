using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;
using Domain;


namespace Application
{
    public class AddressService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> getAddressList(string term)
        {
            client.DefaultRequestHeaders.Accept.Clear();



            var streamTask = client.GetStringAsync($"https://api.addressify.com.au/addresspro/autocomplete?api_key=25696b42-b08d-4f8a-b51c-0ffa9bcfc54c&term={term}");
            var msg = await streamTask;
            

            return msg;
        }

        public static async Task<Address> getAddress(string address)
        {
            client.DefaultRequestHeaders.Accept.Clear();



            var streamTask = client.GetStringAsync($"https://api.addressify.com.au/addresspro/info?api_key=25696b42-b08d-4f8a-b51c-0ffa9bcfc54c&term={address}");
            var msg = await streamTask;
            Address finaladdress = JsonSerializer.Deserialize<Address>(msg);

            return finaladdress;
        }

    }
}
