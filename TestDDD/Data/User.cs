using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestDDD.Data
{
    public class User : BaseEntity
    {  
        public string Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
