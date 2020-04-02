﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueSkyTravel.Models;
using BlueSkyTravel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueSkyTravel.Controllers
{
    public class HotelController : Controller
    {
        IRepository<Hotel> hotelRepo;

        public HotelController(IRepository<Hotel> hotelRepo)
        {
            this.hotelRepo = hotelRepo;
        }
        // GET: Hotel
        public ViewResult Index()
        {
            var model = hotelRepo.GetAll();
            return View(model);
        }

        // GET: Hotel/Details/5
        public ViewResult Details(int id)
        {
            var model = hotelRepo.GetById(id);
            return View(model);
        }

        // GET: Hotel/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            hotelRepo.Create(hotel);
            return RedirectToAction("Index");
        }

        // GET: Hotel/Edit/5
        [HttpGet]
        public ViewResult Update(int id)
        {
            Hotel model = hotelRepo.GetById(id);
            return View(model);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
       
        public IActionResult Update(Hotel hotel)
        {
            hotelRepo.Update(hotel);
            return RedirectToAction("Details", "Hotel", new { id = hotel.Id });
        }

        // GET: Hotel/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Hotel model = hotelRepo.GetById(id);
            return View(model);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public IActionResult Delete(Hotel hotel)
        {
            hotelRepo.Delete(hotel);
            return RedirectToAction("Index", "Hotel");
        }
    }
}