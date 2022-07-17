namespace DemoQLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMSV")]
    public partial class DMSV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMSV()
        {
            KetQuas = new HashSet<KetQua>();
        }

        [Key]
        [StringLength(3)]
        public string MaSV { get; set; }

        [Required]
        [StringLength(15)]
        public string HoSV { get; set; }

        [Required]
        [StringLength(7)]
        public string TenSV { get; set; }

        [StringLength(7)]
        public string Phai { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(20)]
        public string NoiSinh { get; set; }

        [StringLength(2)]
        public string MaKhoa { get; set; }

        public double? HocBong { get; set; }

        public virtual DMKhoa DMKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
