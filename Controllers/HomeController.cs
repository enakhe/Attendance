﻿#nullable disable

using Attendance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Attendance.Areas.Identity.Data;
using Attendance.Data;
using System.Linq;

namespace Attendance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AttendanceContext _db;

        public HomeController(ILogger<HomeController> logger, AttendanceContext db)
        {
            _logger = logger;
            _db = db;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            List<SignIn> allAttendees = await _db.SignIn.Include(attendee => attendee.Student).ToListAsync();
            ViewData["attendees"] = allAttendees;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username)
        {
            var user = _db.Users.Where(user => user.UserName == username).FirstOrDefault();
            List<SignIn> allAttendees = await _db.SignIn.Include(attendee => attendee.Student).ToListAsync();
            ViewData["attendees"] = allAttendees;
            if (user == null)
            {
                StatusMessage = "Error, unable to find addmission number";
                ViewData["message"] = StatusMessage;
                return View("Index");
            }

            if (ModelState.IsValid)
            {
                SignIn signIn = new()
                {
                    StudentId = user.Id
                };

                if (signIn.TimeIn < DateTime.Parse("10:00 AM"))
                {
                    StatusMessage = "Error, you are late. Cannot receive query";
                    ViewData["message"] = StatusMessage;
                    return View("Index");
                }

                ValueTask<EntityEntry<SignIn>> result = _db.SignIn.AddAsync(signIn);

                if (result.IsCompletedSuccessfully)
                {
                    _ = await _db.SaveChangesAsync();
                    StatusMessage = "Successfully signed in";
                    ViewData["message"] = StatusMessage;
                    return View("Index");
                }
            }
            else
            {
                StatusMessage = "Error, something unexpected happened";
                ViewData["message"] = StatusMessage;
                return View("Index");
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            SignIn attendance = _db.SignIn.Where(attd => attd.Id == id).FirstOrDefault();
            List<SignIn> allAttendees = await _db.SignIn.Include(attendee => attendee.Student).ToListAsync();
            ViewData["attendees"] = allAttendees;
            if (attendance == null)
            {
                StatusMessage = "Error, unable to find attendance number";
                ViewData["message"] = StatusMessage;
                return View("Index");
            }
            attendance.IsSignOut = true;
            attendance.TimeOut = DateTime.Now;
            _db.Entry(attendance).State = EntityState.Modified;
            _ = await _db.SaveChangesAsync();
            StatusMessage = "Successfully signed out";
            ViewData["message"] = StatusMessage;
            return View("Index");
        }
    }
}