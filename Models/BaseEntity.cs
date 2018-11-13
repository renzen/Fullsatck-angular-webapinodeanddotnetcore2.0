using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public abstract class BaseEntity
{
    private DateTime currentDate;
    public BaseEntity() => currentDate = DateTime.Now;

    [Key]

    public Int64 Id {get;set;}

    public DateTime CreatedAt{get => currentDate; set  =>currentDate = value;}

    public Nullable<DateTime> UpdatedAt{get;set;}
}