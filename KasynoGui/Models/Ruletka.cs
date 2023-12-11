using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasynoGui.Models
{
    public class Ruletka
    {
        public int Id { get; set; }
        public string GameString { get; set; }

        public int number { get; set; }

        public DateTime date { get; set; }
    }
    public class RuletkaView
    {
        public string GameString { get; set; }

        public int number { get; set; }

        public string date { get; set; }
    }

    public class RuletkaPersonsWon
    {
        public int Id { get; set; }
        public int IdGry { get; set; }

        public int PersonId { get; set; }
    }

    public class RuletkaBets
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public decimal price { get; set; }

        public int? number { get; set; }

        public int IdZakldu { get; set; }
    }

    public class RuletkaZakłady
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int multipier { get; set; }
    }
}