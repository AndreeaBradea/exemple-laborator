﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
    public record StatusPlata
    {

        public int Value { get; }

        public StatusPlata(int value)
        {
                Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
