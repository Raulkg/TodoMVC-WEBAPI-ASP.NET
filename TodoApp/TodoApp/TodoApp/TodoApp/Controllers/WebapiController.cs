using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoApp.Models;


namespace TodoApp.Controllers


{

    
    public class WebapiController : ApiController
    {
        Todoitem[] Todoitems = new Todoitem[] 
        { 
            new Todoitem { Key= "1", Name = "Tomato Soup", IsComplete = false }, 
            new Todoitem { Key= "2", Name = "Yo-yo", IsComplete =true}, 
            new Todoitem {Key ="3", Name = "Hammer", IsComplete = false} ,
              new Todoitem {Key ="4", Name = "eat", IsComplete = false} 
        };

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