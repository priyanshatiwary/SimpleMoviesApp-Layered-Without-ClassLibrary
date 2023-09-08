using SimpleMoviesApp.Controller;
using SimpleMoviesApp.Exceptions;
using SimpleMoviesApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SimpleMoviesApp
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Create an instance of the MovieController class to start managing movies
            new MovieController();

        }
    }
}






































/*
{

   internal class Program
   {
       static Movie[] movies = new Movie[5];
       static int movieCount = 0;

       static void Main(string[] args)
       {


           int choice;
           do
           {

               ShowMenu();
               choice = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine();

               switch (choice)
               {
                   case 1:
                       DisplayMovies();
                       break;
                   case 2:
                       AddMovie();
                       break;
                   case 3:
                       ClearMovies();
                       break;
                   case 4:
                       MovieExit();
                       break;
                   default:
                       Console.WriteLine("Please enter a valid option number from menu.");
                       break;
               }

           } while (choice != 4);

       }

       static void DisplayMovies()
       {
           if (movieCount == 0)
           {
               Console.WriteLine("No movies found.");
           }
           else
           {
               Console.WriteLine("==============Movies=============");
               foreach (var movie in movies)
               {
                   if (movie != null)
                   {
                       Console.WriteLine($"Id: {movie.Id}\n+" +
                           $"Name: {movie.Name}\n" +
                           $"Genre: {movie.Genre}\n" +
                           $"Year: {movie.Year}");
                   }
               }
           }
       }

       static void AddMovie()
       {
           if (movieCount >= 4)
           {
               Console.WriteLine("Cannot add more movies. Movie storage is full.");
               return;
           }



           Console.Write("Enter Movie Id: ");
           int id = Convert.ToInt32(Console.ReadLine());

           Console.Write("Enter Movie Name: ");
           string name = Console.ReadLine();

           Console.Write("Enter Movie Genre: ");
           string genre = Console.ReadLine();

           Console.Write("Enter Movie Year: ");
           int year = Convert.ToInt32(Console.ReadLine());

           Movie movie = new Movie(id, name, genre, year);
           movies[movieCount] = movie;
           movieCount++;

           Console.WriteLine("Movie has been added successfully.");
       }

       static void ClearMovies()
       {
           if (movieCount == 0)
           {
               Console.WriteLine("There are no movies to clear.");
           }
           else
           {
               Array.Clear(movies, 0, movieCount);//Array.Clear(Array array, int index, int length);
               /*
                array: It is an array whose elements need to be cleared.
                index: It is the starting index of the range of elements to clear.
                length: It is the number of elements to clear.
                */
/*            movieCount = 0;                                                    ///////////////////////////////////////
               Console.WriteLine("All movies have been cleared.");
           }
       }
       static void MovieExit()
       { 
           Environment.Exit(0);
       }
       static void ShowMenu()
       {
           Console.WriteLine($"Movie Store Status: {movieCount} / {movies.Length}");
           Console.WriteLine("=============Menu===================");
           Console.WriteLine("1. Display movies");
           Console.WriteLine("2. Add movie");
           Console.WriteLine("3. Clear all movies");
           Console.WriteLine("4. Exit");
           Console.Write("Enter your choice from 1 to 4: ");

       }     

   }
}
///////////////////////////////////////////////////////////////////////////////
*/