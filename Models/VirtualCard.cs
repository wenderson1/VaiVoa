using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VaiVoa.Services;

namespace VaiVoa.Models
{
    public class VirtualCard
    {
        [Key]
        public int Id { get; set; }

        public string CardNumber { get; set; }

        [Required(ErrorMessage = "User Id is Mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid user")]
        public int UserId { get; set; }
        public User User{ get; set; }

        public VirtualCard()
        {
            CardNumber = NumbersVirtualCard.GenerateNumberVirtualCard();
        }
    }
}
