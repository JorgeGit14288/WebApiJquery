using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebClient.Controllers
{
    public class ContactosController : Controller

    {
        private string urlBase = "http://localhost:16350/";

        // GET: Contactos
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<PersonasRest> lista = new List<PersonasRest>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Personas/Listar");
                if (response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;

                    lista = JsonConvert.DeserializeObject<List<PersonasRest>>(resp);

                }
            }
       
            return View(lista);
        }

        // GET: Contactos/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            PersonasRest p = new PersonasRest();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Personas/Buscar/"+id);
                if(response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<PersonasRest>(res);
                }
            }
            return View(p);
        }

        // GET: Contactos/Create
        public ActionResult Create()
        {
            return View(new PersonasRest());
        }

        // POST: Contactos/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(FormCollection collection, PersonasRest persona)
        {
            try
            {
                // TODO: Add insert logic here
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Personas/Crear", persona);
                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    ViewBag.Error = "Ha ocurrido un error " + response.Content.ReadAsStringAsync().Result;
                    return View(persona);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error " + ex.ToString();
                return View(persona);
            }
        }

        // GET: Contactos/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            PersonasRest p = new PersonasRest();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Personas/Buscar/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<PersonasRest>(res);
                }
            }
            return View(p);
        }

        // POST: Contactos/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id, FormCollection collection, PersonasRest persona)
        {
            try
            {
                // TODO: Add update logic here
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/Personas/Actualizar", persona);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");

                    }
                    ViewBag.Error = "Ha ourrido un error inesperado " + response.StatusCode;
                    return View(persona);
                }

               
            }
            catch (Exception ex)
            {
                ViewBag.Error = "ha ocurrido un error " + ex.ToString();
                return View(persona);
            }
        }

        // GET: Contactos/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            PersonasRest p = new PersonasRest();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Personas/Buscar/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<PersonasRest>(res);
                }
            }
            return View(p);
        }

        // POST: Contactos/Delete/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync("api/Personas/Eliminar/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");


                    }
                    ViewBag.Error = "Ha ocurrido un error al eliminar el archivo " + response.StatusCode;
                    return View(id);
                }

            }
            catch(Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error al eliminar el archivo " + ex.ToString();
                return View();
            }
        }
        // GET: Contactos/Test
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Test()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Personas/Test" );
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        string respuesta = JsonConvert.DeserializeObject<string>(res);
                        ViewBag.Error = respuesta;
                        return View();


                    }
                    ViewBag.Error = "Ha ocurrido un error al eliminar el archivo " + response.StatusCode;
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error al eliminar el archivo " + ex.ToString();
                return View();
            }
        }
    }
}
