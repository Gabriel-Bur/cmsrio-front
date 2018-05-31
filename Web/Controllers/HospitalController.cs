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
            string pagina2 = "https://cmsrio.azurewebsites.net/api/Avaliacao/" + id + "?type=json";

            HttpResponseMessage response = await client.GetAsync(pagina.ToString());
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            HospitalViewModel Hospital = Newtonsoft.Json.JsonConvert.DeserializeObject<HospitalViewModel>(result);

            HttpResponseMessage response2 = await client.GetAsync(pagina2.ToString());
            response.EnsureSuccessStatusCode();
            string result2 = response2.Content.ReadAsStringAsync().Result;
            List<AvaliacaoViewModel> avaliacoes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AvaliacaoViewModel>>(result2);



            return View(new Tuple<HospitalViewModel,List<AvaliacaoViewModel>>(Hospital,avaliacoes));
        }

    }
}
