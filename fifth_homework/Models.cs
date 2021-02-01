using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project {
    // many-to-many
    public class Student { 
        public int Id {get; set;}
        public string Name { get; set;}
        public int Age { get; set; }
        public int Grade { get; set; }
        public List<Course> Courses { get; set; }
    }


    public class Course {
        public int Id {get; set;}
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }

    // one-to-many
    public class Car {
        public int Id {get; set;}
        [Required]
        public string Model {get; set;}
        [Required]
        public Manufacturer CarManufacturer { get; set;}
    }

    public class Manufacturer {
        public int Id { get; set; }
        [Required]
        public string Name { get; set;}
    }
}