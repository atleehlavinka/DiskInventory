using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace DiskInventory.Controllers
{
    
    public class BorrowerController : Controller
    {
        private disk_inventoryahContext context { get; set; }
        public BorrowerController(disk_inventoryahContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            List<DiskBorrower> borrowers = context.DiskBorrowers.OrderBy(b => b.Lname).ThenBy(b => b.Fname).ToList();
            return View(borrowers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Fname = context.DiskBorrowers.OrderBy(f => f.Fname).ToList();
            ViewBag.Lname = context.DiskBorrowers.OrderBy(l => l.Fname).ToList();
            ViewBag.PhoneNum = context.DiskBorrowers.OrderBy(p => p.Fname).ToList();
            return View("Edit", new DiskBorrower());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Fname = context.DiskBorrowers.OrderBy(f => f.Fname).ToList();
            ViewBag.Lname = context.DiskBorrowers.OrderBy(l => l.Fname).ToList();
            ViewBag.PhoneNum = context.DiskBorrowers.OrderBy(p => p.Fname).ToList();
            var borrower = context.DiskBorrowers.Find(id);
            return View(borrower);
        }
        [HttpPost]
        public IActionResult Edit(DiskBorrower borrower)
        {
            if (ModelState.IsValid)
            {
                if (borrower.BorrowerId == 0)
                    context.DiskBorrowers.Add(borrower);
                else
                    context.DiskBorrowers.Update(borrower);
                context.SaveChanges();
                return RedirectToAction("Index", "Borrower");
            }
            else
            {
                ViewBag.Action = (borrower.BorrowerId == 0) ? "Add" : "Edit";
                ViewBag.Fname = context.DiskBorrowers.OrderBy(f => f.Fname).ToList();
                ViewBag.Lname = context.DiskBorrowers.OrderBy(l => l.Fname).ToList();
                ViewBag.PhoneNum = context.DiskBorrowers.OrderBy(p => p.Fname).ToList();
                return View(borrower);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var borrower = context.DiskBorrowers.Find(id);
            return View(borrower);
        }
        [HttpPost]
        public IActionResult Delete(DiskBorrower borrower)
        {
            context.DiskBorrowers.Remove(borrower);
            context.SaveChanges();
            return RedirectToAction("Index", "Borrower");
        }
    }
}
