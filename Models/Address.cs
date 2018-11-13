using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace contact_app.Models
{
    [Table("Address")]
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public virtual GeoLoc GeoLoc {get;set;}

        [ForeignKey("UserDetailsId")]
        public Int64 UserDetailsId {get;set;}
        public UserDetails UserDetails {get;set;}
    }
}