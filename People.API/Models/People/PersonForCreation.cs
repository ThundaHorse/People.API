using People.API.StoreData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
  public class PersonForCreation
  {
    [Required(ErrorMessage = "Please provide a first name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please provide a last name")]
    public string LastName { get; set; }

    public int Age { get; set; }
  }
}