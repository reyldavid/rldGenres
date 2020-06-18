using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Genres2020.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Genres2020
{
    public class GenreController : Controller
    {
        // GET: Genre
        public async Task<ActionResult> Index()
        {
            IEnumerable<GenreModel> genres = null;
            string serviceUrl = "https://animegination2.azurewebsites.net/api/categories";
            
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(serviceUrl);

                //client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                //client.DefaultRequestHeaders.Add("AnimeApiClientKey", "AA46C009-49F8-4411-A4D6-131D4BA6D91B");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("AnimeApiClientKey", "AA46C009-49F8-4411-A4D6-131D4BA6D91B");

                using (var response = await client.GetAsync(serviceUrl))
                {
                    //var requestTask = client.GetAsync("categories");
                    //requestTask.Wait();

                    //var response = requestTask.Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    string readResponse = "";
                    try
                    {
                        readResponse = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine("aya ", readResponse);
                    }
                    catch (Exception exc)
                    {
                        System.Diagnostics.Debug.WriteLine("aya resp ", response.Content);
                        System.Diagnostics.Debug.WriteLine("aya exc ", exc.Message);
                    }
                    //readTask.Wait();

                    //genres = readTask.Result;
                    genres = JsonConvert.DeserializeObject<IEnumerable<GenreModel>>(readResponse);
                    //}
                    //else
                    //{
                    //    genres = Enumerable.Empty<GenreModel>();

                    //    ModelState.AddModelError("", "Uh oh!  Better check the error.");
                    //}
                }
            }

            return View(genres);
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Genre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}