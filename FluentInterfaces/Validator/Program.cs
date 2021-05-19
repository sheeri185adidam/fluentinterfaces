using System;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Name = "maniksheeri",
                Age = 36
            };

            var validator = new StudentValidator();
            var result = validator.Validate(student);
            Console.WriteLine($"Student Validator: {result}");
        }
    }
}