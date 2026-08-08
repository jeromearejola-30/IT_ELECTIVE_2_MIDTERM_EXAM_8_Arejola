using System;
using System.ComponentModel.DataAnnotations;

namespace ConferenceCheckIn.Models
{
    public class AttendeeVisit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ticket Number is required.")]
        [Display(Name = "Ticket Number")]
        public string TicketNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company or School is required.")]
        [Display(Name = "Company/School")]
        public string Organization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event Name is required.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Display(Name = "Check-In Time")]
        [DataType(DataType.DateTime)]
        public DateTime CheckInTime { get; set; } = DateTime.Now;

        [Display(Name = "Check-Out Time")]
        [DataType(DataType.DateTime)]
        public DateTime? CheckOutTime { get; set; }

        public string Status { get; set; } = "Present";

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }
}