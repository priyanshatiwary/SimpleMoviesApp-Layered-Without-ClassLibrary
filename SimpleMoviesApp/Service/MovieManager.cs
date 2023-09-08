using SimpleMoviesApp.Exceptions;
using SimpleMoviesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp.Service
{
    internal class MovieManager
    {
        // Static fields and properties to manage movie data

        //specifies the path to a file where movie data is serialized.
        public static string filePath = @"D:\Aurionpro\Day 12\SimpleMoviesApp\MovieFile.txt"; 
        public static List<Movie> movies = new List<Movie>();


        public static int GetMovieCount { get { return movies.Count; } }

        // Constructor to initialize movie data from a file
        public MovieManager()
        {
            //it loads existing movie data when the MovieManager object is created.
            movies = DataSerializer.BinaryDeserializer(filePath);//populate list      
        }
        // Method to add a new movie to the collection
        public static void Add(int id, string name, string genre, int year)
        {
            Movie movie = new Movie(id, name, genre, year);
            movies.Add(movie);
            DataSerializer.BinarySerializer(filePath, movies);
        }
        // Method to clear all movies from the collection
        public static void Clear()
        {
            movies.Clear();
            DataSerializer.BinarySerializer(filePath, movies);

        }
        // Method to update in-memory movie data from a file
        public static void ShowMenu()
        {
            //Updates the in-memory movies list by deserializing movie data from the file.
            movies = DataSerializer.BinaryDeserializer(filePath); //populate list
        }
        /*
        public static void Remove(string name)
        {

            Movie movie2 = new Movie(name);
           
            DataSerializer.BinarySerializer(filePath, movies);
           

        }
        */
        // Method to remove a movie by its name
        public static void Remove(string name)
        {
            int numberOfMoviesRemoved = movies.RemoveAll(movie => movie.Name.Equals(name));

            if (numberOfMoviesRemoved > 0)
            {
                DataSerializer.BinarySerializer(filePath, movies); // Update the file
            }
            else
            {
                throw new NoMoviesOfThisNameException("There are no movies of this name in the movie list");
            }
        }

        // Method to filter and display movies by a specific year
        public static void DisplayByYear(int year)
        {
            Movie movie2 = new Movie(year);

        }
    }
}




