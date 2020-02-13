using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public int OwnerId { get; set; }

    [Required(ErrorMessage = "Please provide a name.")]
    public string Name { get; set; }

    public string Breed { get; set; }
    public int Age { get; set; }
  }
}