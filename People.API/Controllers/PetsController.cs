using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public IActionResult GetPet(int id)
    {
      var petToFind = PetStoreData.Current.Pets.FirstOrDefault(p => p.Id == id);
      if (petToFind == null)
      {
        return NotFound();
      }
      return Ok(petToFind);
    }
  }
}