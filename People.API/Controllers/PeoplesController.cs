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

    [HttpGet("{id}", Name = "GetPerson")]
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
      return CreatedAtRoute("GetPerson", new { id = personToAdd.Id }, personToAdd);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] PersonForUpdate person)
    {
      var personToUpdate = PeopleStoreData.Current.Persons.FirstOrDefault(p => p.Id == id);

      if (personToUpdate == null)
      {
        return NotFound();
      }

      if (person.FirstName != null)
      {
        personToUpdate.FirstName = person.FirstName;
      } else
      {
        personToUpdate.FirstName = personToUpdate.FirstName;
      }

      if (person.LastName != null)
      {
        personToUpdate.LastName = person.LastName;
      } else
      {
        personToUpdate.LastName = personToUpdate.LastName;
      }

      if (person.Age != personToUpdate.Age)
      {
        personToUpdate.Age = person.Age;
      } else
      {
        personToUpdate.Age = personToUpdate.Age;
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
      var personToDelete = PeopleStoreData.Current.Persons.FirstOrDefault(p => p.Id == id);

      if (personToDelete == null)
      {
        return NotFound();
      }

      PeopleStoreData.Current.Persons.Remove(personToDelete);
      return NoContent();
    }
  }
}