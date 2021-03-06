namespace Validator
{
    public class Student
    {
        public string Name { get; set; }
        public long Age { get; set; }
    }
    
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleBuilder.IsNotNull()
                .IsNotNull(s => s.Name)
                .IsEqualTo(s => s.Age, 26);
        }
    }
}