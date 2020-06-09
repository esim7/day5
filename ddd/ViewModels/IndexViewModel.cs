using System.Collections.Generic;
using ddd.Models;

namespace ddd.ViewModels
{
    public class IndexViewModel
    { // Index.cshtml
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        // _CreatePartial.cshtml
        public CreateTeacherViewModel CreateTeacherViewModel { get; set; }
    }
}