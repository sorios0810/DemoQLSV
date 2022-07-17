namespace DemoQLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KetQua")]
    public partial class KetQua
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string MaSV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string MaMH { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte LanThi { get; set; }

        public decimal? Diem { get; set; }

        public virtual DMMH DMMH { get; set; }

        public virtual DMSV DMSV { get; set; }
    }
}
