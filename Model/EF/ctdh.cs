namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.ctdh")]
    public partial class ctdh
    {
        [Key]
        [Column(TypeName = "uint")]
        public long ma_ctdh { get; set; }

        public int madh { get; set; }

        public int masp { get; set; }

        public int soluong { get; set; }

        public double gia { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime updated_at { get; set; }
    }
}
