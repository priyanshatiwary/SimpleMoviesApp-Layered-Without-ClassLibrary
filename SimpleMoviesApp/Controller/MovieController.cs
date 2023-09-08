using SimpleMoviesApp.Exceptions;
using SimpleMoviesApp.Model;
using SimpleMoviesApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleMoviesApp.Controller
{
    internal class MovieController
    {
        // Constructor for MovieController
        public MovieController()
        {
            MainMenu();    

        }
        // Main menu for user interaction
        private static void MainMenu()
        {
            int choice;
            do
            {

                ShowMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                // Handle user choices using a switch statement
                switch (choice)
                {
                    case 1:
                        DisplayMovies();
                        break;
                    case 2:
                        DisplayByYear();

                        break;
                    case 3:
                        AddMovie();

                        break;
                    case 4:
                        RemoveMovie();

                        break;
                    case 5:
                        ClearMovies();

                        break;
                    case 6:
                        MovieExit();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option number from menu.");
                        //throw new WrongChoiceChosenException("Please enter a valid option number from menu.");            
                        break;
                }

            } while (choice != 6);
        }

        // Method to display the list of movies
        static void DisplayMovies()
        {
            if (MovieManager.GetMovieCount == 0)
            {
                //Console.WriteLine("No movies found.");
                //Console.WriteLine("---------------------------------------------");

                throw new NoMoviesFoundException("No movies found."
                    + "-----------------------------------------------");


            }
            else
            {
                Console.WriteLine("==============Movies=============");
                foreach (var movie in MovieManager.movies)
                {
                    if (movie != null)
                    {
                        Console.WriteLine($"Id: {movie.Id}\n" +
                            $"Name: {movie.Name}\n" +
                            $"Genre: {movie.Genre}\n" +
                            $"Year: {movie.Year}");
                    }
                    Console.WriteLine();
                }
            }
        }
        // Method to add a movie
        static void AddMovie()
        {


            if (MovieManager.GetMovieCount >= 5)
            {

                //Console.WriteLine("Cannot add more movies. Movie storage is full.");
                throw new MovieStorageFullException("Cannot add more movies. Movie storage is full.");
                //return;            
            }
            Console.Write("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Movie Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter Movie Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

           // Movie movie = new Movie(id, name, genre, year);
           // movies.Add(movie);
            
            // DataSerializer.BinarySerializer(filePath, movies);
            MovieManager.Add(id, name, genre, year);
            Console.WriteLine("Movie has been added successfully.");
            Console.WriteLine("---------------------------------------------");
        }

        // Method to clear all movies
        static void ClearMovies()
        {
            if (MovieManager.GetMovieCount == 0)
            {
                // Console.WriteLine("There are no movies to clear.");
                //Console.WriteLine("---------------------------------------------");

                throw new NoMoviesToClearException("There are no movies to clear."
                    + "---------------------------------------------");
            }
            else
            {
                // movies.Clear();
                MovieManager.Clear();
                Console.WriteLine("All movies have been cleared.");
                Console.WriteLine("---------------------------------------------");
                //DataSerializer.BinarySerializer(filePath, movies);
            }
        }
        // Method to exit the program
        static void MovieExit()
        {
            Environment.Exit(0);
        }
        // Method to display the main menu
        static void ShowMenu()
        {
            MovieManager.ShowMenu();
            Console.WriteLine($"Movie Store Status: {MovieManager.GetMovieCount} / 5"); //max 5 movies
            Console.WriteLine("=============Menu===================");
            Console.WriteLine("1. Display movies");
            Console.WriteLine("2. Display Movies by Year");
            Console.WriteLine("3. Add movie");
            Console.WriteLine("4. Remove Movie (by name)");
            Console.WriteLine("5. Clear all movies");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice from 1 to 6: ");
            Console.WriteLine();

        }
        /*
        static void RemoveMovie()
        {
            
            //MovieManager.Remove();
            Console.Write("Enter the name of the movie to remove: ");
            string movieName = Console.ReadLine();
            MovieManager.Remove(movieName);
            //bool isMovieRemoved = movies.RemoveAll(movie => movie.Name.Equals(movieName)) > 0;
            bool isMovieRemoved = MovieManager.movies.RemoveAll(movie => movie.Name.Equals(movieName)) > 0;
            if (isMovieRemoved == true)
            {
                Console.WriteLine($"The movie '{movieName}' has been removed");
            }
            else
            {
                throw new NoMoviesOfThisNameException("There are no movies of this name in the movie list"
                    + "---------------------------------------------");
                // Console.WriteLine("There are no movies of this name in the movie list");
            }
*/
        /*           static void RemoveMovie()
                   {
                       Console.Write("Enter the name of the movie to remove: ");
                       string movieName = Console.ReadLine();

                       try
                       {
                           MovieManager.Remove(movieName);
                           Console.WriteLine($"The movie '{movieName}' has been removed");
                       }
                       catch (NoMoviesOfThisNameException ex)
                       {
                           Console.WriteLine(ex.Message);
                       }
                   }
        */
        // Method to remove a movie by name
        static void RemoveMovie()
        {
            Console.Write("Enter the name of the movie to remove: ");
            string movieName = Console.ReadLine();

            MovieManager.Remove(movieName);
            Console.WriteLine($"The movie '{movieName}' has been removed");
            MovieManager.ShowMenu(); // Update the in-memory list and status
        }


        // Method to display movies by a specific year
        static void DisplayByYear()
        {      
            Console.Write("Enter the year to display movies: ");
            int year = Convert.ToInt32(Console.ReadLine());
            MovieManager.DisplayByYear(year);
            List<Movie> moviesByYear = MovieManager.movies.Where(movie => movie.Year == year).ToList();
            if (moviesByYear.Count == 0)
            {
                throw new NoMoviesFoundForThisYearException($"No movies found for the year {year}."
                    + "---------------------------------------------");
                // Console.WriteLine($"No movies found for the year {year}.");
            }
            else
            {
                Console.WriteLine($"============== Movies from {year} ==============");
                foreach (var movie in moviesByYear)
                {
                    Console.WriteLine($"Id: {movie.Id}\n" +
                        $"Name: {movie.Name}\n" +
                        $"Genre: {movie.Genre}\n" +
                        $"Year: {movie.Year}");
                }
            }

        }
    }
}

   

