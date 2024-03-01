using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using YnovResurection.Models;

namespace YnovResurection.ViewModels
{
    internal class RoomManager
    {
        public readonly List<Room> Rooms =
            new List<Room>
            {
                new Room
                {
                    Building = "YnovNantes",
                    Name = "101",
                    Accessibility = true,
                    Chairs = 30,
                    Tables = 15,
                    Projector = true,
                    WallSockets = 20,
                },
                new Room
                {
                    Building = "YnovNantes",
                    Name = "102",
                    Accessibility = true,
                    Chairs = 35,
                    Tables = 16,
                    Projector = true,
                    WallSockets = 20,
                },
                new Room
                {
                    Building = "YnovNantes",
                    Name = "103",
                    Accessibility = true,
                    Chairs = 35,
                    Tables = 10,
                    Projector = true,
                    WallSockets = 20,
                },
                new Room
                {
                    Building = "YnovNantes",
                    Name = "104",
                    Accessibility = true,
                    Chairs = 60,
                    Tables = 30,
                    Projector = true,
                    WallSockets = 40,
                },
            };

        public readonly List<Course> Courses = new List<Course>
        {
            new Course
            {
                Name = "Intégration de merde",
                NumStudents = 30,
                Groups = "M1-DevLogMobIot",
                IsRemote = false,
                AllowSharedRoom = false,
            },
            new Course
            {
                Name = "Comment faires des applications jolies ?",
                NumStudents = 50,
                Groups = "M1-DevLogMobIot, M2-DevLogMobIot",
                IsRemote = false,
                EquipmentNeeds = "WallSockets",
                AllowSharedRoom = false,
            },
            new Course
            {
                Name = "Comment faires des applications moches ?",
                NumStudents = 10,
                Groups = "B3-Dev",
                IsRemote = false,
                EquipmentNeeds = "WallSockets",
                AllowSharedRoom = false,
            },
            new Course
            {
                Name = "Le télétravail",
                NumStudents = 60,
                Groups = "B3-Dev, M1-DevLogMobIot, M2-DevLogMobIot",
                IsRemote = true,
                AllowSharedRoom = false,
            },
            new Course
            {
                Name = "Ydays",
                NumStudents = 10,
                Groups = "All To Gather",
                IsRemote = false,
                EquipmentNeeds = "WallSockets",
                AllowSharedRoom = true,
            },
            new Course
            {
                Name = "Ydays",
                NumStudents = 9,
                Groups = "Super Duper Powder",
                IsRemote = false,
                EquipmentNeeds = "WallSockets",
                AllowSharedRoom = true,
            },
        };

        public Course GetCourseWithMostStudents()
        {
            if (Courses == null || Courses.Count == 0)
            {
                return null;
            }

            var courseWithMostStudents = Courses.OrderByDescending(l => l.NumStudents).FirstOrDefault();
            return courseWithMostStudents;
        }
    }
}