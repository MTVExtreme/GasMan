using System;
using System.ComponentModel.DataAnnotations;

namespace GasMan.Models
{
    public class CreateGas
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double US_Average { get; set; }

        [Required]
        public double Midwest_Average { get; set; }

        public double Speedway_Average { get; set; }

        public double BP_Average { get; set; }

        public double Shell_Average { get; set; }
    }
}
