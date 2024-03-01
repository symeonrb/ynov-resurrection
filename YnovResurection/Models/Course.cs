using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnovResurection.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Groups { get; set; }
        public int NumStudents { get; set; }
        public bool IsRemote { get; set; }
        public string Teacher { get; set; }
        public string EquipmentNeeds { get; set; }
        public bool AllowSharedRoom { get; set; }
    }

    internal class CourseEvent
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
