using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult>  Index()
        {
            var httpClient= new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7067/api/Default");
            var jsontString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsontString);
            return View(values);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient= new HttpClient();
            var  jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7067/api/Default", content);
            if(responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient= new HttpClient();
            var apiUrl = $"https://localhost:7067/api/Default/{id}";
            var responseMessage = await httpClient.GetAsync(apiUrl);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient= new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var apiUrl = "https://localhost:7067/api/Default/";
            var content  = new StringContent (jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync(apiUrl,content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var apiUrl = $"https://localhost:7067/api/Default/{id}";
            var responseMessage = await httpClient.DeleteAsync(apiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }

    public class Class1 
    {
        public int ID { get; set; }
        public String ?Name { get; set; }
    }
}
