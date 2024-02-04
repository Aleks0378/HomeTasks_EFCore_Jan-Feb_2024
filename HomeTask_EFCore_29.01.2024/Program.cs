using HomeTask_EFCore_29._01._2024.Data;
using HomeTask_EFCore_29._01._2024.Model;
using Microsoft.EntityFrameworkCore;

/*Реализовать 2 класса: «Пользователь» и «Настройки пользователя». 
 * Организовать между таблицами связь один к одному. 
 * Добавить несколько пользователей и их настройки. */
//Достать пользователя с Id = 2 и его настройки.
//Удалить пользователя с Id 3 (автоматически должен удалится профайл пользователя).

namespace HomeTask_EFCore_29._01._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    List<User> users = new List<User>()
            //    {
            //        new User
            //        {
            //            Name = "Ivan",
            //            Email="ivan@gmail.com",
            //            UserSettings = new UserSettings
            //            {
            //                Country = "Ukraine",
            //                City = "Odessa"
            //            }
            //        },
            //         new User
            //        {
            //            Name = "Alex",
            //            Email="aleks@gmail.com",
            //            UserSettings = new UserSettings
            //            {
            //                Country = "China",
            //                City = "NewYork"
            //            }
            //        }
            //    };

            //    db.Users.AddRange(users);
            //    db.SaveChanges();
            //}

            //Добавить несколько пользователей и их настройки:
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    db.AddRange(
            //        new User
            //        {
            //            Name="Urii",
            //            Email="urii@yahoo.com",
            //            UserSettings=new UserSettings
            //            {
            //                Country="China",
            //                City="City1"
            //            }
            //        },
            //        new User
            //        {
            //            Name = "Graig",
            //            Email = "greig@yahoo.com",
            //            UserSettings = new UserSettings
            //            {
            //                Country = "German",
            //                City = "Berlin"
            //            }
            //        }
            //        );
            //    db.SaveChanges();
            //}

            //Достать пользователя с Id = 2 и его настройки:
            using (ApplicationContext db = new ApplicationContext())
            {
                var currentUser = db.Users.Include(e => e.UserSettings).FirstOrDefault(e => e.Id == 2);
            }

            //Удалить пользователя с Id 3 (автоматически должен удалится профайл пользователя).
            using (ApplicationContext db = new ApplicationContext())
            {
                //var user3 = db.Users.FirstOrDefault(e=>e.Id==3);
                //if (user3 is not null)
                //{
                //    db.Users.Remove(user3);
                //    db.SaveChanges();
                //}
                db.Users.Remove(new User { Id = 3 });
                db.SaveChanges();
            }
        }
    }
}
