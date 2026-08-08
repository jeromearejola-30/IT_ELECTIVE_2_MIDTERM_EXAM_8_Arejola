using ConferenceCheckIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceCheckIn.Repositories
{
    public class AttendeeVisitRepository : IAttendeeVisitRepository
    {
        private static readonly List<AttendeeVisit> _attendees = new();
        private static int _nextId = 1;

        public IEnumerable<AttendeeVisit> GetAll() => _attendees;

        public AttendeeVisit? GetById(int id) => _attendees.FirstOrDefault(a => a.Id == id);

        public void Add(AttendeeVisit attendee)
        {
            attendee.Id = _nextId++;
            attendee.CheckInTime = DateTime.Now;
            attendee.Status = "Present";
            _attendees.Add(attendee);
        }

        public void Update(AttendeeVisit attendee)
        {
            var existing = GetById(attendee.Id);
            if (existing != null)
            {
                existing.TicketNumber = attendee.TicketNumber;
                existing.FirstName = attendee.FirstName;
                existing.LastName = attendee.LastName;
                existing.Organization = attendee.Organization;
                existing.ContactNumber = attendee.ContactNumber;
                existing.Email = attendee.Email;
                existing.EventName = attendee.EventName;
                existing.Notes = attendee.Notes;
            }
        }

        public void RecordCheckOut(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.CheckOutTime = DateTime.Now;
                existing.Status = "Left Event";
            }
        }

        public IEnumerable<AttendeeVisit> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAll();

            string term = searchTerm.Trim().ToLower();
            return _attendees.Where(a =>
                a.TicketNumber.ToLower().Contains(term) ||
                a.FirstName.ToLower().Contains(term) ||
                a.LastName.ToLower().Contains(term) ||
                a.Organization.ToLower().Contains(term) ||
                a.EventName.ToLower().Contains(term));
        }
    }
}