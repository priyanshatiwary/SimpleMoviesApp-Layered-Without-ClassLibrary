using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp.Exceptions
{
    internal class NoMoviesFoundException: Exception
    {
        public NoMoviesFoundException(string msg) : base(msg) { }
    }
}
