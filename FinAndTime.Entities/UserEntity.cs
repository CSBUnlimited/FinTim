using System;
namespace FinAndTime.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double StartingAmount { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime RegisteredDateTime { get; set; }
        public DateTime LastCheckDateTime { get; set; }
    }
}
