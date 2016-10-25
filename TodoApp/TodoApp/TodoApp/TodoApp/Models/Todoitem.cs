using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Todoitem
    {

        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}