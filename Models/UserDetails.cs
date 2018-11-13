using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace contact_app.Models
{
    [Table("UserDetails")]
        public class UserDetails : BaseEntity
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public DateTime Birth { get; set; }
            public string Phone { get; set; }
            public virtual Address Address {get;set;}
            public string Website { get; set; }

            [ForeignKey("UsersId")]
            public Int64 UsersId {get;set;}
            public Users Users {get;set;}
        } 
}

