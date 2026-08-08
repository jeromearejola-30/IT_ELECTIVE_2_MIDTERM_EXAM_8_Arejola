using ConferenceCheckIn.Models;
using ConferenceCheckIn.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceCheckIn.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private readonly IAttendeeVisitRepository _attendeeRepository;

        public AttendeeController(IAttendeeVisitRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public IActionResult Index(string searchString)
        {
            ViewBag.SearchString = searchString;
            var attendees = _attendeeRepository.Search(searchString);
            return View(attendees);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AttendeeVisit attendee)
        {
            if (ModelState.IsValid)
            {
                _attendeeRepository.Add(attendee);
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var attendee = _attendeeRepository.GetById(id);
            if (attendee == null) return NotFound();
            return View(attendee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AttendeeVisit attendee)
        {
            if (ModelState.IsValid)
            {
                _attendeeRepository.Update(attendee);
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var attendee = _attendeeRepository.GetById(id);
            if (attendee == null) return NotFound();
            return View(attendee);
        }

        [HttpGet]
        public IActionResult Checkout(int id)
        {
            var attendee = _attendeeRepository.GetById(id);
            if (attendee == null) return NotFound();
            return View(attendee);
        }

        [HttpPost]
        [ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmCheckout(int id)
        {
            _attendeeRepository.RecordCheckOut(id);
            return RedirectToAction(nameof(Index));
        }
    }
}