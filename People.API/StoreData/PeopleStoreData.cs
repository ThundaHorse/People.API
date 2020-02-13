using People.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.StoreData
{
  public class PeopleStoreData
  {
    public static PeopleStoreData Current { get; } = new PeopleStoreData();

    public List<Person> Persons { get; set; }

    public PeopleStoreData()
    {
      Persons = new List<Person>()
      {
        new Person()
        {
          Id = 1,
          FirstName = "Haemi",
          LastName = "Choi",
          Age = 26
        },
        new Person()
        {
          Id = 2,
          FirstName = "Abraham",
          LastName = "Kim",
          Age = 26
        },
        new Person()
        {
          Id = 3,
          FirstName = "Isaac",
          LastName = "Kim",
          Age = 25
        }
      };
    }
  }
}