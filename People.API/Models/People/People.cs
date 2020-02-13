using People.API.StoreData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
  public class Person
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Please provide a first name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please provide a last name")]
    public string LastName { get; set; }

    public int Age { get; set; }

    public int NumberOfPets
    {
      get
      {
        var pets = PetStoreData.Current.Pets.FindAll(p => p.OwnerId == Id);
        return pets.Count;
      }
    }

    public IEnumerable<Pet> Pets
    {
      get
      {
        var ownerPets = PetStoreData.Current.Pets.Where(p => p.OwnerId == Id);
        return ownerPets;
      }
    }
  }
}