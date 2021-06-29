using System;
namespace _29062021.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
    }
}