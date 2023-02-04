using System;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Utils;
using static System.Collections.Specialized.BitVector32;

namespace CinemaApp.Services.Contracts
{
    internal class FilmManager : ICrudService<Film>, IPrintService
    {
        public void Add(Film film)
        {
            DataContext.Films.Add(film);
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Films.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Film Get(int id)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return null;
            }

            return DataContext.Films[index];
        }

        public List<Film> GetAll()
        {
            return DataContext.Films;
        }

        public void Print()
        {

            foreach (var item in DataContext.Films)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Film newFilm)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Films[index] = newFilm;
            Console.WriteLine($"\nFilm changed!\n");
        }
    }
}

