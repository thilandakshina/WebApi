using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.MyServicesPortal.Domain
{
    public class Companies : BaseEntity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(70)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Code { get; set; }
    }
}
