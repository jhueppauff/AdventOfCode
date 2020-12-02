using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2
{
    public class PasswordProperty
    {
        public int MinimumLength { get; set; }

        public int MaximumLength { get; set; }

        public char Character { get; set; }

        public string Password { get; set; }
    }
}
