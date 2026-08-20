using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public enum Priority {Low, Medium, High}
    }


}
