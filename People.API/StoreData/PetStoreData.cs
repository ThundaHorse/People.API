using People.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.StoreData
{
  public class PetStoreData
  {
    public static PetStoreData Current { get; } = new PetStoreData();

    public List<Pet> Pets { get; set; }

    public PetStoreData()
    {
      Pets = new List<Pet>()
      {
        new Pet()
        {
          Id = 1,
          OwnerId = 1,
          Name = "Stella",
          Breed = "Cat",
          Age = 4
        },
         new Pet()
        {
          Id = 2,
          OwnerId = 1,
          Name = "Nala",
          Breed = "Cat",
          Age = 4
        },
          new Pet()
        {
          Id = 3,
          OwnerId = 2,
          Name = "Cayde",
          Breed = "Cat",
          Age = 2
        }
      };
    }
  }
}