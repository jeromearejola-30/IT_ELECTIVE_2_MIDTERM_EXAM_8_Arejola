using ConferenceCheckIn.Models;
using System.Collections.Generic;

namespace ConferenceCheckIn.Repositories
{
    public interface IAttendeeVisitRepository
    {
        IEnumerable<AttendeeVisit> GetAll();
        AttendeeVisit? GetById(int id);
        void Add(AttendeeVisit attendee);
        void Update(AttendeeVisit attendee);
        void RecordCheckOut(int id);
        IEnumerable<AttendeeVisit> Search(string searchTerm);
    }
}