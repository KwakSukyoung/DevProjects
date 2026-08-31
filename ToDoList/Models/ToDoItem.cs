using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }

        public override string ToString()
        {
            string status;
            if (IsComplete)
            {
                status = "Completed";
            }
            else
            {
                status = "Active";
            }
            return $"{Title} | {DueDate} | {Priority} | {status}";
        }

    }
}
