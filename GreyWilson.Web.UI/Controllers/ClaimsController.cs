using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreyWilson.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreyWilson.Web.UI.Controllers
{
    
    public class ClaimsController : Controller
    {

        private readonly ClaimRepository ClaimRepository;
        public ClaimsController()
        {
            ClaimRepository = new ClaimRepository();
        }

        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        // GET: Claims/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CustomerNumber,LastName,Description,ClaimAmount,CreatedOn")] Claim claim)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ClaimRepository.Create(claim);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(claim);
                }

            }
            catch
            {
                return View();
            }


        }

        // GET: Claims/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Claims/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            var claim = ClaimRepository.GetByID(id);

            if (await TryUpdateModelAsync(claim))
            {
                try
                {
                    ClaimRepository.Update(claim);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

            return View(claim);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Claims/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}