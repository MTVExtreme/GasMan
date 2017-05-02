using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMan.Data
{
    class RetailPrice
    {
        [Key]
        public int ID { get; set; }

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
