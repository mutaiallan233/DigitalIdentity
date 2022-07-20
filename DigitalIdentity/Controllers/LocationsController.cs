
using Microsoft.AspNetCore.Mvc;
using DigitalIdentity.Data.Entities;
using DigitalIdentity.App.Business.Abstract;

namespace DigitalIdentity.Api.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
       private ILocation _location;


       public LocationsController(ILocation location)
        {
            _location = location;
        }

        [HttpPost("post-location")]
        public IActionResult CreateLocation(Location location)
        {
            _location.CreateLocation(location);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + location.Id, location);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocation(Guid id)
        {
            var location = _location.GetLocation(id);
            if(location == null)
            {
               return NotFound($"location with id {id} was not found");
            }
            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_location.GetAllLocations());
        }

        
        [HttpDelete("delete-location/{id}")]

        public IActionResult DeleteLocation(Guid id)
        {
            var location = _location.GetLocation(id);
            if (location != null)
            {
                _location.DeleteLocation(location);
                return Ok($"location with id: {id} was deleted successfully");
            }
            return NotFound($"location with id: {id} was not found");
        }

       
        
        [HttpPatch("update-location/{id}")]

        public IActionResult UpdateLocation(Guid id, Location location)
        {
            var existingLocation = _location.GetLocation(id);
            if (existingLocation != null)
            {
                location.Id = existingLocation.Id;
                location.Name = location.Name==null?existingLocation.Name:location.Name;
                location.AdministrativeArea = location.AdministrativeArea == null ? existingLocation.AdministrativeArea : location.AdministrativeArea;
               
                _location.UpdateLocation(location);
                return Ok($"Location with id: {id} was updated successfully");
            }
            return NotFound($"Location with id: {id} was not found");
        }
    }
}
