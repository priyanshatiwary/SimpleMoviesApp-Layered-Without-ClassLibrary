using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp.Exceptions
{
    internal class NoMoviesOfThisNameException:Exception
    {
        public NoMoviesOfThisNameException(string msg) : base(msg) { }
    }
}


























/*
 
Namespace: The class is defined within the SimpleMoviesApp.Exceptions namespace, which is likely used to organize exception-related code.

Class Name: The class is named NoMoviesOfThisNameException, which suggests that it's an exception specifically designed for 
cases where no movies with a particular name can be found.

Base Class: This custom exception class inherits from the Exception class provided by the .NET Framework. 
Inheritance from Exception makes it possible to use this custom exception in a similar way to built-in exceptions.

Constructor: The class defines a constructor:
public NoMoviesOfThisNameException(string msg) : base(msg) { }


This constructor takes a single parameter msg, which is a string message describing the exception.
Inside the constructor, it calls the base class constructor (base(msg)) with the provided message. 
This sets the error message for the exception.
In summary, the NoMoviesOfThisNameException class is a custom exception used to handle situations where there are no movies with a
specific name. It allows you to throw and catch this exception in your code when needed, providing a descriptive message to help 
diagnose the issue when it occurs.
 */