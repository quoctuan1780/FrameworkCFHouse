namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coffee-house.cthd")]
    public partial class cthd
    {
        [Key]
        [Column(Order = 0, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long mahd { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long masp { get; set; }

        public int soluong { get; set; }

        public double gia { get; set; }

        public virtual sanpham sanpham { get; set; }
    }
}
