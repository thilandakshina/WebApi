using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CC.MyServicesPortal.Domain
{
    public class UserAccounts : BaseEntity
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
    }
}
