using Domain.Entities;

namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Organization { get; set; }    

        public int UserId { get; set; }

        public User User { get; set; }
    }
}