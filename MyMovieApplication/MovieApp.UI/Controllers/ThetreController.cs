using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class ThetreController : Controller
    {
        IConfiguration _configuration;

        public ThetreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowThetre()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Thetre/selectThetre";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var thetreModel = JsonConvert.DeserializeObject<List<ThetreModel>>(data);
                        return View(thetreModel);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddThetre()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddThetre(ThetreModel thetreModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(thetreModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiURL"] + "Thetre/addThetre";
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Thetre Added Successfully..!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Soory.. Unable To Add Thetre..!!";
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateThetre(int ThetreId)
        {
            string URL=_configuration["WebApiURL"] + "Thetre/FetchThetreById?id=" + ThetreId;
            using(HttpClient httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(URL))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var body = await response.Content.ReadAsStringAsync();
                        //ThetreModel thetreModel=JsonConvert.DeserializeObject<ThetreModel>(body);
                        var thetreModel = JsonConvert.DeserializeObject<ThetreModel>(body);
                        return View(thetreModel);
                    }
                }
            }
            //return RedirectToAction("ShowThetre", "Thetre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateThetre(ThetreModel thetreModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(thetreModel), Encoding.UTF8, "application/json");
            string URL= _configuration["WebApiURL"] + "Thetre/EditThetre";
            using(HttpClient client=new HttpClient())
            {
                using(var response=await client.PutAsync(URL,body))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowThetre", "Thetre");
                    }
                }
            }
             return RedirectToAction("ShowThetre", "Thetre");
           
        }

        [HttpPost]
        public async Task<IActionResult> DeleteThetreById(int ThetreId)
        {
            string endpoint = _configuration["WebApiURL"] + "Thetre/deletethetre?ThetreId=" + ThetreId;
            using(HttpClient client=new HttpClient())
            {
                using(var response=await client.DeleteAsync(endpoint))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowThetre", "Thetre");
                    }
                }
            }
            return RedirectToAction("ShowThetre", "Thetre");
        }
    }
}
