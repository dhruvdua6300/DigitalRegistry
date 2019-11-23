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
    public class TagsController : Controller
    {
        
        private readonly DigitalRegistryContext _context;

        public TagsRoot rootObject;
        private readonly IRepository _repository;
        HttpClient httpClient;
        public string BASE_URL = "https://api.gsa.gov/technology/digital-registry/v1/tags";

        public TagsController(IRepository repository)
        {
            
            _repository = repository;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public IActionResult TagsAll()
        {

            rootObject = GetAllTags();
            if (_repository.getTagsData())
            {
                bool areNewRecordsAdded = _repository.saveTags(rootObject);
            }
            return View(rootObject);

        }


        public TagsRoot GetAllTags()
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
                rootObject = JsonConvert.DeserializeObject<TagsRoot>(companyList);
            }
            return rootObject;



        }












        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tags.ToListAsync());
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags
                .FirstOrDefaultAsync(m => m.id == id);
            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tag_text,tag_type,social_media_count,mobile_app_count,gallery_count")] Tags tags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tags);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }
            return View(tags);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tag_text,tag_type,social_media_count,mobile_app_count,gallery_count")] Tags tags)
        {
            if (id != tags.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsExists(tags.id))
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
            return View(tags);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = await _context.Tags
                .FirstOrDefaultAsync(m => m.id == id);
            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tags = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tags);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagsExists(int id)
        {
            return _context.Tags.Any(e => e.id == id);
        }
    }
}
