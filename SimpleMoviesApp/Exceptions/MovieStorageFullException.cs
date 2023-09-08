﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp.Exceptions
{
    internal class MovieStorageFullException:Exception
    {
        public MovieStorageFullException(string msg) : base(msg) { }
    }
}
