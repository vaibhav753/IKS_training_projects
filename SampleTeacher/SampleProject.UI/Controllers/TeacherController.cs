using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SampleProject.Entity.Entity;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.UI.Controllers
{
    public class TeacherController : Controller
    {
        IConfiguration _iconfiguration;

        public TeacherController(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }

        public async Task<IActionResult> FetchTeachers()
        {
            string url = _iconfiguration["URL"] + "Teacher/fetchteacher";
            using(HttpClient client=new HttpClient())
            {
                using(var response=await client.GetAsync(url))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var data= await response.Content.ReadAsStringAsync();
                        var teacherModel = JsonConvert.DeserializeObject<List<TeacherModel>>(data);
                        return View(teacherModel);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherModel teacherModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(teacherModel), Encoding.UTF8, "application/json");
            string url = _iconfiguration["URL"] + "Teacher/addteacher";
            using(HttpClient client= new HttpClient())
            {
                using(var response=await client.PostAsync(url,body))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.Status = "success";
                        ViewBag.message = "Teacher Added Successfully..!!";
                    }
                    else
                    {
                        ViewBag.Status = "eror";
                        ViewBag.message = "Teacher added Failed..!!";
                    }
                }
            }
            return View();
        }

    }
}
