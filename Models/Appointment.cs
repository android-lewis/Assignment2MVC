using System.Web.Mvc;

namespace Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        public long AppointmentID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(200, ErrorMessage = "Patient Name cannot be longer than 200 characters.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Contact Number is Required")]
        [StringLength(13, ErrorMessage = "Patient Contact Number cannot be longer than 13 characters.")]
        [RegularExpression(@"^(\+44\s?\d{10})", 
            ErrorMessage = "Contact Numbers must in the format '+440000000000' for example '+447812344321'")]
        public string PatientContactNo { get; set; }

        [StringLength(200, ErrorMessage = "Patient Address cannot be longer than 200 characters.")]
        public string PatientAddress { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Appointment Date is Required")]
        public DateTime? AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment Time is Required")]
        public TimeSpan? AppointmentTime { get; set; }

        public long? TestCentreID { get; set; }

        public virtual TestCentre TestCentre { get; set; }

        public IEnumerable<SelectListItem> TestCentres { get; set; }

    }
}
