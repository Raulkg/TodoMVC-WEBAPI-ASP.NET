using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Tododriver : TodoRepo
        
    {

  private static ConcurrentDictionary<string, Todoitem> _todos =
              new ConcurrentDictionary<string, Todoitem>();

        public Tododriver()
        {
            Add(new Todoitem { Name = "Item1" });
        }

        public IEnumerable<Todoitem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(Todoitem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public Todoitem Find(string key)
        {
            Todoitem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public Todoitem Remove(string key)
        {
            Todoitem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(Todoitem item)
        {
            _todos[item.Key] = item;
        }
    }
}