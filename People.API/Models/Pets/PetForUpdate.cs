﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models.Pets
{
  public class PetForUpdate
  {
    [Required(ErrorMessage = "Please provide a name.")]
    public string Name { get; set; }

    public int OwnerId { get; set; }

    public string Breed { get; set; }

    [Required(ErrorMessage = "Please provide an age.")]
    public int Age { get; set; }
  }
}