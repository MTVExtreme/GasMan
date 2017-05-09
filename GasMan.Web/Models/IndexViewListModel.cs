using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GasMan.Web.Models
{
    public class IndexViewListModel
    {
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }

        public double US_Average;
        public double Midwest_Average;
    }
}