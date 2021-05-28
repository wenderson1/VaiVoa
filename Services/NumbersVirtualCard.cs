using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaiVoa.Data;
using VaiVoa.Models;

namespace VaiVoa.Services
{
    public static class NumbersVirtualCard
    {
       static DataContext context;

        public static string GenerateNumberVirtualCard()
        {
            string value;
            var numberVirtualCard="";

            Random randomNumber = new Random();

            for (int i = 0; i <= 3; i++)
            {
                value = (Convert.ToString(randomNumber.Next(1000, 9999)));
                numberVirtualCard += value;
            }            

            return numberVirtualCard;
        }
    }
}
