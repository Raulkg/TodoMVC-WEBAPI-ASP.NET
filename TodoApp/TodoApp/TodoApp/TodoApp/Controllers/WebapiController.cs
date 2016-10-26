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









        public IEnumerable<MyDBModel> GetAll()
        {

            List<MyDBModel> mytodoitems = new List<MyDBModel>();
            using (todoDBEntities1 db = new todoDBEntities1())
            {

                mytodoitems = db.MyDBModels.OrderBy(a => a.Key).ToList();
            }
            return mytodoitems;
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

        [HttpPost]
        public IHttpActionResult Create([FromBody] MyDBModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            using (todoDBEntities1 db = new todoDBEntities1())
            {

               db.MyDBModels.Add(item);
               try
               {
                   db.SaveChanges();
               }

               catch (Exception ec)
               {
                   Console.WriteLine(ec.Message);
               }

            }


            return Ok(item);
        }

         [HttpPost]
        public IHttpActionResult UpdateItem(int id ,MyDBModel details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             

           
             
             using (todoDBEntities1 db = new todoDBEntities1())
            {

                db.Entry(details).State = System.Data.EntityState.Modified;
             


                try
                {
                    db.SaveChanges();
                }

                catch (Exception ec)
                {
                    Console.WriteLine(ec.Message);
                }



            }

             return Ok(details);
        }


         [HttpDelete]
         public IHttpActionResult DeleteItem(int id)
         {
             if (!ModelState.IsValid || id ==null)
             {
                 return BadRequest(ModelState);
             }




             using (todoDBEntities1 db = new todoDBEntities1())
             {

                 MyDBModel tmp = db.MyDBModels.Find(id);
                 db.MyDBModels.Remove(tmp);



                 try
                 {
                     db.SaveChanges();
                 }

                 catch (Exception ec)
                 {
                     Console.WriteLine(ec.Message);
                 }



             }

             return Ok();
         }














    }
}