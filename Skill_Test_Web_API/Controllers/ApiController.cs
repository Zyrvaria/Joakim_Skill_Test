using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Economy;
using System.Diagnostics.CodeAnalysis;

namespace _Skill_Test_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //taken from https://developer.softrig.com/wiki/authentication/web-site-auth-code and altered for my use
    public class ApiController : ControllerBase
    {
        private readonly Client Client = new Client {
            clientId = "f6a294fc-ac05-4fdf-bd72-dd1f4d6cb157",
            clientSecret = "R0v#8EUBuy6@Vv&V"
        };

        [HttpGet("/getToken")]
        public async Task<IActionResult> GetToken([FromQuery(Name = "code")] string code = null) {
            if (code == null) {
                return Ok("No code");
            }

            var httpClient = new HttpClient();

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", Client.clientId),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_secret", Client.clientSecret),
                new KeyValuePair<string, string>("redirect_uri", "https://localhost:4200"),
            };

            var content = new FormUrlEncodedContent(pairs);
            var result = await httpClient.PostAsync(new Uri("https://test-login.softrig.com/connect/token"), content);
            var returnContent = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode) return BadRequest(returnContent);

            var identityResponse = JsonConvert.DeserializeObject<IdentityResponse>(returnContent);

            //token = identityResponse.access_token;
            return Ok(identityResponse.access_token);
            //return await GetContacts(identityResponse.access_token);
        }
        [HttpGet("/getContacts")]
        public async Task<IActionResult> GetContacts([FromQuery(Name = "token")] string accessToken) {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            try {
                var jwtSecurityToken = new JwtSecurityToken(accessToken);
                if (jwtSecurityToken.Payload.TryGetValue("AppFramework", out var baseUrl)) {
                    Console.WriteLine($"Base url is {baseUrl}");
                    var apiResult = await httpClient.GetAsync(new Uri(baseUrl + "api/biz/contacts?expand=Info,Info.InvoiceAddress,Info.DefaultPhone,Info.DefaultEmail,Info.DefaultAddress"));

                    return Ok(await apiResult.Content.ReadAsStringAsync());
                }
                else {
                    return BadRequest($"Could not find claim on token");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return BadRequest("this is wrong");
        }
        [HttpGet("/getContactsWithFilter")]
        public async Task<IActionResult> GetContactsWithFilter([FromQuery(Name = "token")] string accessToken, [FromQuery(Name = "filter")] string filter = "") {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            try {
                var jwtSecurityToken = new JwtSecurityToken(accessToken);
                if (jwtSecurityToken.Payload.TryGetValue("AppFramework", out var baseUrl)) {
                    Console.WriteLine($"Base url is {baseUrl}");
                    var apiResult = await httpClient.GetAsync(new Uri(baseUrl + "api/biz/contacts" + filter + "&expand=Info,Info.InvoiceAddress,Info.DefaultPhone,Info.DefaultEmail,Info.DefaultAddress"));

                    return Ok(await apiResult.Content.ReadAsStringAsync());
                }
                else {
                    return BadRequest($"Could not find claim on token");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return BadRequest("this is wrong");
        }
        [HttpGet("/createContact")]
        public async Task<IActionResult> CreateContact([FromQuery(Name = "token")] string accessToken, [FromQuery(Name = "payload")] string payload) {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            try {
                var jwtSecurityToken = new JwtSecurityToken(accessToken);
                if (jwtSecurityToken.Payload.TryGetValue("AppFramework", out var baseUrl)) {
                    Console.WriteLine($"Base url is {baseUrl}");
                    var apiResult = await httpClient.PostAsJsonAsync(new Uri(baseUrl + "api/biz/contacts"), payload);

                    return Ok(await apiResult.Content.ReadAsStringAsync());
                }
                else {
                    return BadRequest($"Could not find claim on token");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return BadRequest("this is wrong");
        }
        [HttpGet("/updateContact")]
        public async Task<IActionResult> UpdateContact([FromQuery(Name = "token")] string accessToken, [FromQuery(Name = "id")] int contactID, [FromQuery(Name = "payload")] string[] payload) {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            try {
                var jwtSecurityToken = new JwtSecurityToken(accessToken);
                if (jwtSecurityToken.Payload.TryGetValue("AppFramework", out var baseUrl)) {
                    Console.WriteLine($"Base url is {baseUrl}");
                    var apiResult = await httpClient.PostAsJsonAsync(new Uri(baseUrl + "api/biz/contacts/" + contactID), payload);

                    return Ok(await apiResult.Content.ReadAsStringAsync());
                }
                else {
                    return BadRequest($"Could not find claim on token");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return BadRequest("this is wrong");
        }
        [HttpGet("/deleteContact")]
        public async Task<IActionResult> DeleteContact([FromQuery(Name = "token")] string accessToken, [FromQuery(Name = "id")] int contactID) {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            try {
                var jwtSecurityToken = new JwtSecurityToken(accessToken);
                if (jwtSecurityToken.Payload.TryGetValue("AppFramework", out var baseUrl)) {
                    Console.WriteLine($"Base url is {baseUrl}");
                    var apiResult = await httpClient.DeleteAsync(new Uri(baseUrl + "api/biz/contacts/" + contactID));

                    return Ok(await apiResult.Content.ReadAsStringAsync());
                }
                else {
                    return BadRequest($"Could not find claim on token");
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return BadRequest("this is wrong");
        }

    }

    internal class IdentityResponse
    {
        public string id_token { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
    }

    internal class Client
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
    }
}