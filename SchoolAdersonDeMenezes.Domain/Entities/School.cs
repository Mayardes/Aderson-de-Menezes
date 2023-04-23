using SchoolAdersonDeMenezes.Domain.Enums;
using SchoolAdersonDeMenezes.Domain.Events;
using SchoolAdersonDeMenezes.Domain.ValueObjects;

namespace SchoolAdersonDeMenezes.Domain.Entities
{
    /// <summary>
    /// Object responsible for modeling School.
    /// </summary>
    public class School : AggregateRoot
    {
        public string Name { get; private set;}
        public TypePublicEducation TypePublicEducation { get; private set;}
        public Address Address { get; private set;}
        public List<Student> Students { get; private set;}
        public DateTime CreateAt { get; private set;}
        public StatusCreatedSchool Status { get; private set;}

        public School(string name, TypePublicEducation typePublicEducation, Address address, List<Student> students)
        {
            Id = Guid.NewGuid();
            Name = name;
            TypePublicEducation = typePublicEducation;
            Address = address;
            Students = students;
            CreateAt = DateTime.UtcNow;
            foreach (var student in students)
            {
                AddEvent(new StudentCreated(student.Id, student.FullName, student.Email, student.Parents));
            }
        }

        public void SetAsCompleted() => Status = StatusCreatedSchool.Completed;
        public void SetAsRejected() => Status = StatusCreatedSchool.Rejected;

    }
}
