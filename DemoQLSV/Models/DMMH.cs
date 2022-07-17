namespace DemoQLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMMH")]
    public partial class DMMH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMMH()
        {
            KetQuas = new HashSet<KetQua>();
        }

        [Key]
        [StringLength(2)]
        public string MaMH { get; set; }

        [Required]
        [StringLength(25)]
        public string TenMH { get; set; }

        public byte? SoTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
