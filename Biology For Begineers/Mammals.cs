using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biology_For_Begineers
{
    public class Mammals
    {
        public string Question;
        public List<string> Choices;
        public int CorrectAns;
        public Mammals(string questions, List<string> choices, int correctAns)
        {
            Question = questions;
            Choices = choices;
            CorrectAns = correctAns;
        }
    }
}
