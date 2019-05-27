namespace Organizer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserEvent")]
    public partial class UserEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int EventID { get; set; }

        public virtual Events Events { get; set; }

        public virtual Users Users { get; set; }
    }
}
