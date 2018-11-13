using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace contact_app.Models
{
     [Table("GeoLoc")]
     public class GeoLoc : BaseEntity
     {
         public string Lat { get; set; }
         public string Lng { get; set; }

         [ForeignKey("AddressId")]
         public Int64 AddressId {get;set;}
         public Address Address {get;set;}
     } 
}