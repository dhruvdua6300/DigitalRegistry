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
    public class Result2Controller : Controller
    {
        private readonly DigitalRegistryContext _context;
        public RootObject2 rootObject;
        private readonly IRepository _repository;
        HttpClient httpClient;
        public string BASE_URL = "https://api.gsa.gov/technology/digital-registry/v1/mobile_apps";

        public Result2Controller(IRepository repository)
        {
            _repository = repository;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public IActionResult results2() {

            rootObject = GetAllResults2();
            if (_repository.getCount2())
            {
                bool areNewRecordsAdded = _repository.SaveMobileApps(rootObject);
            }
            return View(rootObject);

        }


        public RootObject2 GetAllResults2() {
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
                Console.WriteLine();
                rootObject = JsonConvert.DeserializeObject<RootObject2>(companyList);
            }
            return rootObject;



        }






        // GET: Result2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Result2.ToListAsync());
        }

        // GET: Result2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result2 = await _context.Result2
                .FirstOrDefaultAsync(m => m.id == id);
            if (result2 == null)
            {
                return NotFound();
            }

            return View(result2);
        }

        // GET: Result2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Result2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,short_description,long_description,icon_url,language,created_at,updated_at")] Result2 result2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(result2);
        }

        // GET: Result2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result2 = await _context.Result2.FindAsync(id);
            if (result2 == null)
            {
                return NotFound();
            }
            return View(result2);
        }

        // POST: Result2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,short_description,long_description,icon_url,language,created_at,updated_at")] Result2 result2)
        {
            if (id != result2.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Result2Exists(result2.id))
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
            return View(result2);
        }

        // GET: Result2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result2 = await _context.Result2
                .FirstOrDefaultAsync(m => m.id == id);
            if (result2 == null)
            {
                return NotFound();
            }

            return View(result2);
        }

        // POST: Result2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result2 = await _context.Result2.FindAsync(id);
            _context.Result2.Remove(result2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Result2Exists(int id)
        {
            return _context.Result2.Any(e => e.id == id);
        }
    }
}
