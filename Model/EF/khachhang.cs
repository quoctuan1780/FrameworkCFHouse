namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.khachhang")]
    public partial class khachhang
    {
        [Key]
        [Column(TypeName = "uint")]
        public long makh { get; set; }

        [Required]
        [StringLength(100)]
        public string hoten { get; set; }

        [Required]
        [StringLength(10)]
        public string gioitinh { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string diachi { get; set; }

        [Required]
        [StringLength(20)]
        public string sodt { get; set; }

        [StringLength(200)]
        public string ghichu { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime updated_at { get; set; }

        public int? matk { get; set; }
    }
}
