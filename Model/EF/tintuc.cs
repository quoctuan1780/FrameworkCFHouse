namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house-repair.tintuc")]
    public partial class tintuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int matt { get; set; }

        [Required]
        [StringLength(200)]
        public string tieude { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string noidung { get; set; }

        [Required]
        [StringLength(100)]
        public string hinhanh { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime create_at { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime update_at { get; set; }
    }
}
