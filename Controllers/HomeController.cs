﻿using INTEX2_group1_3.Models;
using INTEX2_group1_3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace INTEX2_group1_3.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //private  IBurialRepository repo;
        private TheMummyProjectContext context;
        public HomeController(/*IBurialRepository temp, */TheMummyProjectContext con)
        {
            //repo = temp;
            context = con;
        }

        [RequireHttps]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> YourTableIndex()
        {
            return View(await context.Burialmain.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [RequireHttps]
        public IActionResult SupervisedPage()
        {
            return View();
        }
        [RequireHttps]
        public IActionResult UnsupervisedPage()
        {
            return View();
        }
        [RequireHttps]
        public IActionResult Search(string burialDirection, int pageNum = 1)
        {
            int pageSize = 20;
            var x = new SearchViewModel 
            {
                Burials = context.Burialmain
                .Where(p => p.Squarenorthsouth == burialDirection | burialDirection == null)
                .OrderBy(p=>p.Id)
                .Skip((pageNum - 1) * pageSize)
                .ToList()
            };

            return View(x);
        }


        [HttpGet]
        public IActionResult Edit(long id)
        {
            var update = context.Burialmain.Single(x => x.Id == id);
            return View("Edit", update);
        }
        [HttpPost]
        public IActionResult Edit(Burialmain bm)
        {
            context.Update(bm);
            context.SaveChanges();
            return RedirectToAction("Search");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var deletion = context.Burialmain.Single(x => x.Id == id);
            return View(deletion);
        }

        [HttpPost]
        public IActionResult Delete(Burialmain bm)
        {
            context.Burialmain.Remove(bm);
            context.SaveChanges();
            return RedirectToAction("Search");
        }
        public IActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> Records(string searchQuery, int? pageNumber)
        {
            int pageSize = 20;
            var query = context.Burialmain.AsQueryable();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(b => (b.Squarenorthsouth.Contains(searchQuery)) || b.Headdirection.Contains(searchQuery) || b.Sex.Contains(searchQuery));
            }
            var paginatedBurials = await PaginatedList<Burialmain>.CreateAsync(query, pageNumber ?? 1, pageSize);
            // Retrieve unique values for the filters
            var Sex = await context.Burialmain
                                             .Select(b => b.Sex)
                                             .Distinct()
                                             .ToListAsync();
            var Depth = await context.Burialmain
                                                 .Select(b => b.Depth)
                                                 .Distinct()
                                                 .ToListAsync();
            var Length = await context.Burialmain
                                                 .Select(b => b.Length)
                                                 .Distinct()
                                                 .ToListAsync();
            var Ageatdeath = await context.Burialmain
                                                 .Select(b => b.Ageatdeath)
                                                 .Distinct()
                                                 .ToListAsync();
            var Headdirection = await context.Burialmain
                                                 .Select(b => b.Headdirection)
                                                 .Distinct()
                                                 .ToListAsync();
            var Burialid = await context.Burialmain
                                                 .Select(b => b.Burialid)
                                                 .Distinct()
                                                 .ToListAsync();
            var Haircolor = await context.Burialmain
                                                 .Select(b => b.Haircolor)
                                                 .Distinct()
                                                 .ToListAsync();
            var Facebundles = await context.Burialmain
                                                 .Select(b => b.Facebundles)
                                                 .Distinct()
                                                 .ToListAsync();

            // Add other LINQ queries for the filters you want to use
            var filterViewModel = new FilterViewModel
            {
                Sex = Sex,
                Depth = Depth,
                Length = Length,
                Ageatdeath = Ageatdeath,
                Headdirection = Headdirection,
                Burialid = Burialid,
                Haircolor = Haircolor,
                Facebundles = Facebundles
                // Add other properties for the filters you want to use
            };
            var viewModel = new SearchViewModel
            {
                Burials = paginatedBurials,
                SearchQuery = searchQuery,
                Filters = filterViewModel // Add the FilterViewModel to the SearchViewModel
            };
            var records = context.Burialmain.OrderBy(b => b.Id);
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}