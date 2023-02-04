using System;
using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Utils;

namespace CinemaApp.Services.Contracts
{
    internal class HallManager : ICrudService<Hall>, IPrintService
    {
        public void Add(Hall hall)
        {
            DataContext.Halls.Add(hall);
            Console.WriteLine("Added");
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Halls.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Hall Get(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return null;
            }

            return DataContext.Halls[index];
        }

        public List<Hall> GetAll()
        {
            return DataContext.Halls;
        }

        public void Print()
        {
            foreach (var item in DataContext.Halls)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Hall newHall)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found!");

                return;
            }

            DataContext.Halls[index] = newHall;
            Console.WriteLine($"\nHall changed!\n");
        }
    }
}

