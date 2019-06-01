namespace Organizer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events()
        {
            UserEvent = new HashSet<UserEvent>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int OwnerID { get; set; }

        public int Capacity { get; set; }

        public int? NumberOfJoined { get; set; }

        public DateTime EventDate { get; set; }

        public int? CategoryID { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEvent> UserEvent { get; set; }
    }
}
