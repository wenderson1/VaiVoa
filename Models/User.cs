using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaiVoa.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(15, ErrorMessage = "Name need to have between 2 and 15 characters")]
        [MinLength(2, ErrorMessage = "Name need to have between 2 and 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name is mandatory")]
        [MaxLength(15, ErrorMessage = "Last Name need to have between 2 and 15 characters")]
        [MinLength(2, ErrorMessage = "Last Name need to have between 2 and 15 characters")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is mandatory")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public User() { }

    }
}