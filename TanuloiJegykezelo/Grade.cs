using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanuloiJegykezelo
{
    internal class Grade
    {
        public string Subject { get; set; }
        public int Value { get; set; }

        public Grade(string subject, int value)
        {
            Subject = subject;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Subject}: {Value}";
        }
    }
}
