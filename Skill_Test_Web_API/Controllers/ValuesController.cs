using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Economy;

namespace _Skill_Test_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Api apiReference = new Api();
        /*
        [HttpGet(Name = "Login")]
        public async Task<string> Login() {
            return "Login is running";
            var task = apiReference.PKCELogin("AppFramework Accounting.Admin Administrator Accounting.Approval Sales.Admin Timetracking.Admin openid profile offline_access", "f6a294fc-ac05-4fdf-bd72-dd1f4d6cb157");
            await task;
            if (task.IsCompletedSuccessfully) {
                return "success";
            }
            else {
                return "failure";
            }
        }
        [HttpGet(Name = "GetContacts")]
        public async Task<string> GetContacts() {
            var task = apiReference.Get("https://test-api.softrig.com/api/biz/contacts");
            await task;
            if (task.IsCompletedSuccessfully) {
                return task.Result;
            }
            else {
                return "failure";
            }
        }*/
    }
}
