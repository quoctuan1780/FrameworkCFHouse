namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.donhang")]
    public partial class donhang
    {
        [Key]
        [Column(TypeName = "uint")]
        public long madh { get; set; }

        public int? makh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydat { get; set; }

        public float? tongtien { get; set; }

        [StringLength(200)]
        public string httt { get; set; }

        [StringLength(500)]
        public string ghichu { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? updated_at { get; set; }

        public int tttt { get; set; }
    }
}
