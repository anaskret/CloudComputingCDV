using Lab1_Aleksander_Naskret.DataAccess;
using Lab1_Aleksander_Naskret.Dtos;
using Lab1_Aleksander_Naskret.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_Aleksander_Naskret.Controllers
{
    public class PeopleController: Controller
    {
        private readonly AzureDbContext azureDbContext;

        public PeopleController(AzureDbContext azureDbContext)
        {
            this.azureDbContext = azureDbContext;
        }

        [HttpGet("api/people/")]
        public IActionResult GetAll()
        {
            try
            {
                var peopleList = azureDbContext.People.ToList();
                return Ok(peopleList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("api/people/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var person = GetPerson(id);

                return Ok(person);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("api/people")]
        public IActionResult Create([FromBody] PersonDto personDto)
        {
            try
            {
                var convertedPerson = ConvertToPerson(personDto);

                azureDbContext.Add(convertedPerson);
                azureDbContext.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("api/people/{id}")]
        public IActionResult Update([FromBody] PersonDto personDto, [FromRoute] int id)
        {
            try
            {
                var convertedPerson = ConvertToPerson(personDto);
                convertedPerson.PersonId = id;

                azureDbContext.People.Update(convertedPerson);
                azureDbContext.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("api/people/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var person = GetPerson(id);
                azureDbContext.People.Remove(person);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private Person GetPerson(int id)
        {
            return azureDbContext.People.FirstOrDefault(x => x.PersonId == id);
        }

        private static Person ConvertToPerson(PersonDto personDto) => new Person()
        {
            FirstName = personDto.FirstName,
            LastName = personDto.LastName
        };
    }
}
