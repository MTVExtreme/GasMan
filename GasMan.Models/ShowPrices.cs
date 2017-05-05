using System;
using System.ComponentModel.DataAnnotations;

namespace GasMan.Models
{
    public class ShowPrices
    {
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }

        public double US_Average { get; set; }

        public double Midwest_Average { get; set; }

        public double Speedway_Average { get; set; }

        public double BP_Average { get; set; }

        public double Shell_Average { get; set; }
    }
}
