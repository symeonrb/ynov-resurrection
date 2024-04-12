﻿using System.ComponentModel.DataAnnotations;

namespace YnovResurrection.Models;

public class Building : IModel
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public School School { get; set; }

    public ICollection<Room> Rooms { get; set; }

    public override String ToString() => Address;
}
