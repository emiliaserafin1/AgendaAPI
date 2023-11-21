using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace AgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        public ContactController(IContactService contactService, IUserService userRepository)
        {
            _contactService = contactService;
            _userService = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            return Ok(_contactService.GetAllByUser(userId));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            return Ok(_contactService.GetAllByUser(userId).Where(x => x.Id == id));
        }


        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContact createContactDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            _contactService.Create(createContactDto, userId);
            return Created("Created", createContactDto);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateContact(CreateAndUpdateContact dto, int contactId)
        {
            _contactService.Update(dto, contactId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetById(id);

            if (contact == null)
            {
                return NotFound(); // Devuelve 404 si el contacto no se encuentra
            }

            _contactService.Delete(id);
            return NoContent(); // Devuelve 204 (No Content) para indicar éxito sin contenido
        }


    }
}
