using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User:AuditEntity
    {
       public string? FirstName { get; set; }

        public string? LastName{ get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public DateTime DOB { get; set; }

        public string? EmailAddress { get; set; }



    }
}
 