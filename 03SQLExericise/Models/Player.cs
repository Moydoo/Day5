using System;
using System.Collections.Generic;

namespace _03SQLExericise.Models;

public partial class Player
{
    public int Id { get; set; }

    public int? CoachId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Country { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public decimal? Number { get; set; }
}
