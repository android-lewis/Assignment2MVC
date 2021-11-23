namespace Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestCentre")]
    public partial class TestCentre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestCentre()
        {
            Appointments = new HashSet<Appointment>();
        }

        public long TestCentreID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Centre Name is Required")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters.")]
        public string CentreName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Centre Operating Times are Required")]
        [RegularExpression(@"^(\w{3})-(\w{3})-(\d{2}).(\d{2})-(\d{2}).(\d{2})+$", ErrorMessage = "Opening times must in the format 'DDD-DDD-00.00-00.00' for example 'Mon-Fri-09.00-17:00'")]
        public string CentreOperatingTimes { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Centre Address is Required")]
        [StringLength(200, ErrorMessage = "Centre Address cannot be longer than 200 characters.")]
        public string CentreAddress { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Centre Contact Number is Required")]
        [StringLength(200, ErrorMessage = "Centre Contact Number cannot be longer than 200 characters.")]
        public string CentreContactNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Centre County is Required")]
        [StringLength(200, ErrorMessage = "Centre County cannot be longer than 200 characters.")]
        public string CentreCounty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
