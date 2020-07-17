using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSalon.Models
{
    public class QuestionBank
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        public string Value { get; set; }
        public int TimeOut { get; set; }
        public string Remark { get; set; }
        public int Flag { get; set; }

        public int Count { get; set; }
    }
}
