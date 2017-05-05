using System;
using System.ComponentModel.DataAnnotations;

namespace GasMan.Data
{
    public class RetailPrice
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double US_Average { get; set; }

        public string Year { get; set; }

        [Required]
        public double Midwest_Average { get; set; }

        public double Speedway_Average { get; set; }

        public double BP_Average { get; set; }

        public double Shell_Average { get; set; }

    }
}
