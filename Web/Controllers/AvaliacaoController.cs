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
    public class AvaliacaoController : Controller
    {
        HttpClient client = new HttpClient();
        DateTime date;

        // GET: Avaliacao/Create

        public ActionResult Create(int id)
        {
            Session["idhospital"] = id;
            return View();

        }

        // POST: Avaliacao/Create
        [HttpPost]
        public async Task<ActionResult> Create(AvaliacaoViewModel avaliacao)
        {
            avaliacao.IDHospital = Convert.ToInt32(Session["idhospital"]);
            avaliacao.Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            if (ModelState.IsValid)
            {
                try
                {
                    string pagina = "https://cmsrio.azurewebsites.net/api/Avaliacao/";

                    HttpResponseMessage response = await client.PostAsJsonAsync(pagina, avaliacao);
                    response.EnsureSuccessStatusCode();

                    return RedirectToAction("Details","Hospital",new { id = Convert.ToInt32(Session["idhospital"]) });
                }
                catch
                {
                    return View();
                }
            }

            return View();

        }

    }
}
