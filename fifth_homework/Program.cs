using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fifth task!");

            using(var db = new UsersContext()) 
            {
                Course sharpCourse = new Course() {
                    Name = "Advanced C# course"
                };

                Student st1 = new Student() {
                    Name = "George"
                };

                sharpCourse.Students = new List<Student>() {st1};

                db.AddRange(sharpCourse, st1);

                db.SaveChanges();
            }

            //one to many
            using(var db = new UsersContext()) 
            {
                Manufacturer toyota = new Manufacturer() { Name = "Toyota" };
                Manufacturer ford = new Manufacturer() { Name = "Ford" };

                Car supra = new Car() {Model="Supra", CarManufacturer = toyota};
                Car camry3_5 = new Car() {Model="Camry 3.5", CarManufacturer = toyota};
                Car mustang = new Car() {Model = "Mustang"};
                Car raptor = new Car() {Model = "RAptor F-150", CarManufacturer = ford};

                try {
                    db.AddRange(supra, camry3_5, mustang, raptor);
                    db.SaveChanges();
                } catch (DbUpdateException ext) {
                    Console.WriteLine($"Can't upate db reason: {ext.InnerException}");
                }
            }

            using (var db = new UsersContext()) 
            {
                var cars = db.Cars;
                foreach(var car in cars.Where(x => x.CarManufacturer.Name == "Toyota").OrderBy(x => x.Model).Select(x => x.Model).ToList()) {
                    Console.WriteLine($"Toyota car: {car}");
                }
            }
        }
    }
}
