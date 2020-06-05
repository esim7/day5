using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ddd.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Room { get; set; }
        public string CourseName { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}