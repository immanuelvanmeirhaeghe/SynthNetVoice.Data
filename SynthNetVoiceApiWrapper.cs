using RestSharp;

namespace SynthNetVoice.Data
{
    public class SynthNetVoiceApiWrapper
    {
        public static string? CallApi(string method, string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Enum.Parse<Method>(method));
            var response = client.Execute(request);
            if (response != null)
            {
                return response.Content;
            }
            else 
            {
                return null; 
            }
        }
    }
}
