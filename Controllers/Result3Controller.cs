using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalRegistry.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace DigitalRegistry.Controllers
{
    public class Result3Controller : Controller
    {
        private readonly DigitalRegistryContext _context;
        
        public RootObject3 rootObject;
        private readonly IRepository _repository;
        HttpClient httpClient;
        public string BASE_URL = "https://api.gsa.gov/technology/digital-registry/v1/social_media";

        public Result3Controller(IRepository repository)
        {
            _repository = repository;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public IActionResult socialMedia()
        {

            rootObject = GetAllSocial();
            if (_repository.getSocialData())
            {
                bool areNewRecordsAdded = _repository.SaveSocial(rootObject);
            }
            return View(rootObject);

        }


        public RootObject3 GetAllSocial()
        {
            string CompaniesApi_End_Point = BASE_URL + "?API_KEY=qZEyjY0nTO9R8suzDCwQs06eVpyfFOkY7UVacerl";
            string companyList = string.Empty;
            httpClient.BaseAddress = new Uri(CompaniesApi_End_Point);
            HttpResponseMessage response = httpClient.GetAsync(CompaniesApi_End_Point).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }
            if (!string.IsNullOrEmpty(companyList))
            {
                rootObject = JsonConvert.DeserializeObject<RootObject3>(companyList);
            }
            return rootObject;



        }







        // GET: Result3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Result3.ToListAsync());
        }

        // GET: Result3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result3 = await _context.Result3
                .FirstOrDefaultAsync(m => m.id == id);
            if (result3 == null)
            {
                return NotFound();
            }

            return View(result3);
        }

        // GET: Result3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Result3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,organization,account,service_key,short_description,long_description,service_display_name,service_url,language,created_at,updated_at")] Result3 result3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(result3);
        }

        // GET: Result3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result3 = await _context.Result3.FindAsync(id);
            if (result3 == null)
            {
                return NotFound();
            }
            return View(result3);
        }

        // POST: Result3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,organization,account,service_key,short_description,long_description,service_display_name,service_url,language,created_at,updated_at")] Result3 result3)
        {
            if (id != result3.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Result3Exists(result3.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(result3);
        }

        // GET: Result3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result3 = await _context.Result3
                .FirstOrDefaultAsync(m => m.id == id);
            if (result3 == null)
            {
                return NotFound();
            }

            return View(result3);
        }

        // POST: Result3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result3 = await _context.Result3.FindAsync(id);
            _context.Result3.Remove(result3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Result3Exists(int id)
        {
            return _context.Result3.Any(e => e.id == id);
        }
    }
}
