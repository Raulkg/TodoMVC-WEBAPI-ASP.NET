﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Net.Http;

using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class ValuesController : ApiController
    {


        Todoitem[] Todoitems = new Todoitem[] 
        { 
            new Todoitem { Key= "1", Name = "Tomato Soup", IsComplete = false }, 
            new Todoitem { Key= "2", Name = "Yo-yo", IsComplete =true}, 
            new Todoitem {Key ="3", Name = "Hammer", IsComplete = false} 
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    

        public IEnumerable<Todoitem> GetAll()
        {
            return Todoitems;
        }
        public IHttpActionResult GetByID(String id)
        {
            var todoitem = Todoitems.FirstOrDefault((p) => p.Key == id);
            if (todoitem == null)
            {
                return NotFound();
            }
            return Ok(todoitem);
        }



    }
}
