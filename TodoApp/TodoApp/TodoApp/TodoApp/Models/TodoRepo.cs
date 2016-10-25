using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public interface TodoRepo
    {
        void Add(Todoitem item);
        IEnumerable<Todoitem> GetAll();
        Todoitem Find(string key);
        Todoitem Remove(string key);
        void Update(Todoitem item);

    }
}