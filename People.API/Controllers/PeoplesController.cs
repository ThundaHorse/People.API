using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using People.API.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Controllers
{
  [ApiController]
  [Route("api/people")]
  public class PeoplesController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetPeople()
    {
      return Ok(PeopleStoreData.Current.Persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetPerson(int id)
    {
      var list = PeopleStoreData.Current.Persons.FirstOrDefault(p => p.Id == id);

      if (list == null)
      {
        return NotFound();
      }

      return Ok(list);
    }

    [HttpGet("{personId}/pets")]
    public IActionResult GetPersonsPets(int personId)
    {
      var personToReturn = PeopleStoreData.Current.Persons.FirstOrDefault(p => p.Id == personId);
      if (personToReturn == null)
      {
        return NotFound();
      }

      var petList = PetStoreData.Current.Pets.FindAll(o => o.OwnerId == personToReturn.Id);

      if (petList == null)
      {
        return NotFound();
      }
      return Ok(petList);
    }

    [HttpPost]
    public IActionResult CreatePerson(int personId, [FromBody] PersonForCreation person)
    {
      var lastId = PeopleStoreData.Current.Persons.Max(p => p.Id);
      var personToAdd = new Person()
      {
        Id = ++lastId,
        FirstName = person.FirstName,
        LastName = person.LastName,
        Age = person.Age
      };

      PeopleStoreData.Current.Persons.Add(personToAdd);
      return CreatedAtRoute("GetPeople", new { id = personToAdd.Id }, personToAdd);
    }
  }
}