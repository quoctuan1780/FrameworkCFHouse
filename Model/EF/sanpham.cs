namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.sanpham")]
    public partial class sanpham
    {
        [Key]
        [Column(TypeName = "uint")]
        public long masp { get; set; }

        [StringLength(100)]
        public string tensp { get; set; }

        [Column(TypeName = "uint")]
        public long? maloaisp { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string mota { get; set; }

        public float? gia { get; set; }

        public float? giakm { get; set; }

        [StringLength(255)]
        public string hinhanh { get; set; }

        [StringLength(255)]
        public string dvt { get; set; }

        public sbyte? moi { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? updated_at { get; set; }
    }
}
