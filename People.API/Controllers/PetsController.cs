using Microsoft.AspNetCore.Mvc;
using People.API.Models;
using People.API.Models.Pets;
using People.API.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.API.Controllers
{
  [ApiController]
  [Route("api/pets")]
  public class PetsController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetPets()
    {
      return Ok(PetStoreData.Current.Pets);
    }

    [HttpGet("{id}", Name = "GetPet")]
    public IActionResult GetPet(int id)
    {
      var petToFind = PetStoreData.Current.Pets.FirstOrDefault(p => p.Id == id);
      if (petToFind == null)
      {
        return NotFound();
      }
      return Ok(petToFind);
    }

    [HttpPost]
    public IActionResult CreatePet([FromBody] PetForCreation pet)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var lastId = PetStoreData.Current.Pets.Max(p => p.Id);
      var petToAdd = new Pet()
      {
        Id = ++lastId,
        OwnerId = pet.OwnerId,
        Name = pet.Name,
        Breed = pet.Breed,
        Age = pet.Age
      };

      PetStoreData.Current.Pets.Add(petToAdd);
      return CreatedAtRoute("GetPet", new { id = petToAdd.Id }, petToAdd);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePet(int id, [FromBody] PetForUpdate pet)
    {
      var petToUpdate = PetStoreData.Current.Pets.FirstOrDefault(p => p.Id == id);

      if (petToUpdate == null)
      {
        return NotFound();
      }

      if (pet.OwnerId != petToUpdate.OwnerId)
      {
        petToUpdate.OwnerId = pet.OwnerId;
      }
      if (pet.Name != null)
      {
        petToUpdate.Name = pet.Name;
      }
      if (pet.Breed != null)
      {
        petToUpdate.Breed = pet.Breed;
      }
      if (pet.Age != petToUpdate.Age)
      {
        petToUpdate.Age = pet.Age;
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePet(int id)
    {
      var petToDelete = PetStoreData.Current.Pets.FirstOrDefault(p => p.Id == id);

      if (petToDelete == null)
      {
        return NotFound();
      }

      PetStoreData.Current.Pets.Remove(petToDelete);
      return NoContent();
    }
  }
}