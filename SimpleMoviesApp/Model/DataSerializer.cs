using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp.Model
{
    internal class DataSerializer
    {
        // Method for serializing movie data to a binary file
        public static void BinarySerializer(string filepath, List<Movie> movies)
        {
            using (FileStream filestream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filestream, movies);
            }
        }
        // Method for deserializing binary data back into a list of movies
        public static List<Movie> BinaryDeserializer(string filepath)
        {
            List<Movie> movies = new List<Movie>();
            using (FileStream filestream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (filestream.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(filestream);
                }

            }
            return movies;
        }
    }
}

























/*
 BinarySerializer is a public static method that allows you to serialize data to a binary file

It takes two parameters:%0D%0Afilepath: A string representing the path to the binary file where you want to save the data.
-movies: A list of Movie objects that you want to serialize and save.%0D%0AInside the method:
-It opens a FileStream (filestream) for the specified filepath in write mode (FileAccess.Write).
-It creates a BinaryFormatter (formatter) to perform the serialization.%0D%0A
It uses the Serialize method of the BinaryFormatter to serialize the movies list and save it to the binary file represented by filestream

----------------------------------------------------------------------------------------------------------------------------------
BinaryDeserializer is a public static method for deserializing data from a binary file.
It takes one parameter:
filepath: A string representing the path to the binary file from which you want to load data.
Inside the method:
It creates an empty List<Movie> called movies to hold the deserialized data.
It opens a FileStream (filestream) for the specified filepath in read mode (FileAccess.Read).
It checks if the filestream has data to read (its length is greater than 0).
If data exists, it creates a BinaryFormatter (formatter) to perform the deserialization.
It uses the Deserialize method of the BinaryFormatter to deserialize the data from filestream and assigns it to the movies list.
Finally, it returns the movies list containing the deserialized data.

 */