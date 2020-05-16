namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.loaisanpham")]
    public partial class loaisanpham
    {
        [Key]
        [Column(TypeName = "uint")]
        public long maloaisp { get; set; }

        [Required]
        [StringLength(100)]
        public string tenloaisp { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string mota { get; set; }

        [StringLength(255)]
        public string hinhanh { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? updated_at { get; set; }
    }
}
