using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace KasynoGui.Models
{
    public class RuletkaViewModel
    {
        public List<Ruletka> myDataLists { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public decimal MoneyAmount { get; set; }
    }

    public class PlaceBet
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public decimal Price { get; set; }

    }
}