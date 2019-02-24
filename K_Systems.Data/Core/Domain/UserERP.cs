using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class UserERP : IdentityUser
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
