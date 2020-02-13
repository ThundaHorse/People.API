using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
  public class PersonForUpdate
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }
  }
}