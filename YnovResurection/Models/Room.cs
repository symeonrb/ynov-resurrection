using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnovResurection.Models
{
    internal class Room
    {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Name { get; set; }
        public bool Accessibility { get; set; }
        public int Chairs { get; set; }
        public int Tables { get; set; }
        public bool Projector { get; set; }
        public int WallSockets { get; set; }
        public bool Printers3D { get; set; }
        public bool WhiteBoard { get; set; }
    }
}
