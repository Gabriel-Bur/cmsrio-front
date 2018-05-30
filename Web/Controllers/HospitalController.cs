using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HospitalController : Controller
    {
        HttpClient client = new HttpClient();

        // GET: Hospital/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string pagina = "https://cmsrio.azurewebsites.net/api/Hospital/" + id + "?type=json";

            HttpResponseMessage response = await client.GetAsync(pagina.ToString());
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            HospitalViewModel Hospital = Newtonsoft.Json.JsonConvert.DeserializeObject<HospitalViewModel>(result);

            return View(Hospital);
        }

    }
}
