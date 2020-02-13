using People.API.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Models
{
  public class Person
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
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