using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ddd.Models;

namespace ddd.ViewModels
{
    public class CreateTeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}