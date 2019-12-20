using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class CheckFever
    {
        static int idCounter = 0;
        public static List<CheckFever> testList = new List<CheckFever>();
        public int Id { get; set; }
        public string Info { get; set; }

        public CheckFever()
        {
            Id = ++idCounter;
        }

        public static string CalculateFever(float temperature)
        {

        
            if(temperature < 20)
            {
            return "Fevertime";
                
            }
            else
            {
                return "Nonono";
            }
        }
        

    }
}
