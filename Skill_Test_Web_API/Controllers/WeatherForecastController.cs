using Microsoft.AspNetCore.Mvc;
using Economy;

namespace Skill_Test_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private Api apiReference = new();

        [HttpGet(Name = "GetContacts")]
        public async Task<string> Login() {
            if (apiReference.HasRefreshToken) {
                Task<string> getContactsTask = apiReference.Get("https://test-api.softrig.com/api/biz/contacts");
                getContactsTask.Wait();
                if (getContactsTask.IsCompletedSuccessfully) {
                    return getContactsTask.Result;
                }
                else {
                    return "Could not get contacts, Error: " + getContactsTask.Exception;
                }
            }
            else {
                /*
                var task = LongRunningOperationAsync();
                await task;
                if (task.IsCompletedSuccessfully) {
                    return "can await basic task";
                }
                else {
                    return "cannot await basic task, Error: " + task.Exception;
                }*/
                var loginTask = apiReference.PKCELogin("AppFramework Accounting.Admin Administrator Accounting.Approval Sales.Admin Timetracking.Admin openid profile offline_access", "f6a294fc-ac05-4fdf-bd72-dd1f4d6cb157");
                var task = LongRunningOperationAsync();
                await task;
                //await loginTask;

                if (loginTask.IsCompletedSuccessfully) {
                    return Login().Result;
                }
                else {
                    return "Failed Login, Error: " + loginTask.Exception;
                }
            }
            //var task = temp.Get("https://test-api.softrig.com/api/biz/contacts");
            /*
            if (task) {
                var task2 = await apiReference.Get("https://test-api.softrig.com/api/biz/contacts");
                return task2;
            }
            else {
                return "did not complete task";
            }*/
        }
        /*
        [HttpGet(Name = "GetContacts")]
        [Route("[controller]/getcontact")]
        public async Task<string> GetContacts() {
            var task = await apiReference.Get("https://test-api.softrig.com/api/biz/contacts");
            if (task != null) {
                return task;
            }
            else {
                return "failure";
            }
        }*/
        public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
{
            await Task.Delay(10000); // 10 second delay
            return 1;
        }
    }
}