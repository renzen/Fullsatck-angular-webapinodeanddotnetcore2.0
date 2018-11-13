using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//using contact_app.Models;

namespace  contact_app.Models
{
    [Table("Users")]
    public class Users : BaseEntity
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public virtual UserDetails UserDetails {get; set;} 
    }     
}
