namespace VoluntariatModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int EventId { get; set; }

        public int? OfficeId { get; set; }

        public int? SponsorId { get; set; }

        public virtual Office Office { get; set; }

        public virtual Sponsor Sponsor { get; set; }
    }
}
