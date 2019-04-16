using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        private PersonContact GetPersonContact()
        {
            if (Session["PersonInfo"] == null)
            {
                Session["PersonInfo"] = new PersonContact();
            }
            return (PersonContact)Session["PersonInfo"];
        }


        [HttpPost]
        public ActionResult Name(Name data,string prevBtn, string nextBtn)
        {
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    PersonContact obj = GetPersonContact();
                       obj.FirstName = data.FirstName;
                    obj.LastName = data.LastName;
                    return View("Location");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Location(Location data,string prevBtn, string nextBtn)
        {
            PersonContact obj = GetPersonContact();
            if (prevBtn != null)
            {
                Name name = new Name();
                name.FirstName = obj.FirstName;
                name.LastName = obj.LastName;
                return View("Name", name);
            }
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.StreetAddress = data.StreetAddress;
                    obj.Unit = data.Unit;
                    obj.City = data.City;
                    obj.Province = data.Province;
                    return View("Contact");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact data,string prevBtn, string nextBtn)
        {
            PersonContact obj = GetPersonContact();
            if (prevBtn != null)
            {
                Location loc = new Location();
                loc.StreetAddress = obj.StreetAddress;
                loc.City = obj.City;
                loc.Unit = obj.Unit;
                loc.Province = obj.Province;
                return View("Location", loc);
            }
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.Email = data.Email;

                    // NorthwindEntities db = new NorthwindEntities();
                    // db.PersonContact.Add(obj);
                    //db.SaveChanges();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://imc-hiring-test.azurewebsites.net/Contact/Save");

                        //HTTP POST
                      //  var postTask = client.PostAsJsonAsync<PersonContact>("Person", obj);
                        //postTask.Wait();

                       // var result = postTask.Result;
                       // if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                   return Content("User data saved successfully");
                }
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetJsonCity(int stateId)
        {
            var list = new List<string>();
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = httpClient.GetAsync("https://imc-hiring-test.azurewebsites.net/Contact/Cities").Result;
                response.EnsureSuccessStatusCode();
               // List<string> cityList = response.Content.ReadAsAsync<List<string>>().Result;
               // if (!object.Equals(cityList, null))
                {
                 //   var cities = cityList.ToList();
                  
                }
            }
            catch (HttpException ex)
            {
                throw new HttpException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json(new SelectList(list, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}