using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace developererkankilic.Authentication.WebAPI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("userinfo")]
        public async Task<IActionResult> GetUserInfo(string token)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"https://www.googleapis.com/oauth2/v3/userinfo?access_token={token}");
            var userInfo = JsonConvert.DeserializeObject<GoogleJsonWebSignature.Payload>(response);

            return Ok(userInfo);
        }
    }
}
