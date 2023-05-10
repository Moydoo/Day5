using System;
using System.Collections.Generic;

namespace _03SQLExericise.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
