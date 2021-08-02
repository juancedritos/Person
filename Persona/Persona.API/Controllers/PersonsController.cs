﻿namespace Person.API.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Person.API.FakeDB;
    using Person.API.Models;
    using Person.API.Validators;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Collections.Generic;
    using System.Linq;

    [SwaggerTag("Servicio para el manejo de personas")]
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly PersonsFakeDb _fakeDb;
        private readonly PersonValidator _personValidator;

        public PersonsController(
            PersonsFakeDb fakeDb,
            PersonValidator personValidator)
        {
            _fakeDb = fakeDb;
            _personValidator = personValidator;
        }


        /// <summary>
        /// Metodo que devuelve todas las personas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Se completó la busqueda correctamente y retornó el listado de personas</response>
        /// <response code="500">Se presentó un error interno al consultar las personas</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("/")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_fakeDb.FakePersons);
        }

        [HttpGet("/{personId:int}")]
        public ActionResult<Person> GetById(int personId)
        {
            if (personId <= 0)
            {
                return BadRequest("El Id es un campo obligatorio");
            }

            var person = _fakeDb.FakePersons.Where(p => p.Id == personId).FirstOrDefault();

            if (person == null)
            {
                return NotFound("La persona no existe");
            }

            return Ok(person);
        }

        [HttpDelete("/{personId:int}")]
        public ActionResult Delete(int personId)
        {
            if (personId <= 0)
            {
                return BadRequest("El Id es un campo obligatorio");
            }

            var personExists = _fakeDb.FakePersons.Any(p => p.Id == personId);

            if (!personExists)
            {
                return NotFound("La persona no existe");
            }
            else
            {
                var Persons = _fakeDb.FakePersons.FindIndex(p => p.Id == personId);
                _fakeDb.FakePersons.RemoveAt(Persons);
            }

            return Ok();
        }

        [HttpPut("/{personId:int}")]
        public ActionResult Update(int personId, [FromBody] Person person)
        {
            var validation = _personValidator.Validate(person);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            if (personId <= 0)
            {
                return BadRequest("El Id es un campo obligatorio");
            }

            var productExists = _fakeDb.FakePersons.Any(p => p.Id == personId);

            if (!productExists)
            {
                return NotFound("La persona no existe");
            }
            else
            {
                var Persons = _fakeDb.FakePersons.FindIndex(p => p.Id == personId);
                _fakeDb.FakePersons.ElementAt(Persons).Name = person.Name;
                _fakeDb.FakePersons.ElementAt(Persons).Age = person.Age;
                _fakeDb.FakePersons.ElementAt(Persons).Email = person.Email;
                _fakeDb.FakePersons.ElementAt(Persons).Adress = person.Adress;
                _fakeDb.FakePersons.ElementAt(Persons).Phone = person.Phone;
                _fakeDb.FakePersons.ElementAt(Persons).Mobile = person.Mobile;
                _fakeDb.FakePersons.ElementAt(Persons).State = person.State;
                _fakeDb.FakePersons.ElementAt(Persons).BirthDate = person.BirthDate;
                _fakeDb.FakePersons.ElementAt(Persons).ZipCode = person.ZipCode;
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult<int> Save([FromBody] Person person)
        {
            var validation = _personValidator.Validate(person);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var lastId = _fakeDb.FakePersons.ElementAt(_fakeDb.FakePersons.Count - 1).Id;

            person.Id = ++lastId;

            _fakeDb.FakePersons.Add(person);

            return Ok(_fakeDb.FakePersons.Last().Id);
        }

    }
}
