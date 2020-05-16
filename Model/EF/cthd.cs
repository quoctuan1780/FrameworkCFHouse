namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.cthd")]
    public partial class cthd
    {
        [Key]
        [Column(TypeName = "uint")]
        public long ma_cthd { get; set; }

        public int mahd { get; set; }

        public int masp { get; set; }

        public int soluong { get; set; }

        public double gia { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime updated_at { get; set; }
    }
}
