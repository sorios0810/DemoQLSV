namespace DemoQLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMKhoa")]
    public partial class DMKhoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKhoa()
        {
            DMSVs = new HashSet<DMSV>();
        }

        [Key]
        [StringLength(2)]
        public string MaKhoa { get; set; }

        [Required]
        [StringLength(30)]
        public string TenKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMSV> DMSVs { get; set; }
    }
}
