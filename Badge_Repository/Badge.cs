using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class Badge
    {
        public Badge() { }
        public Badge(List<String> doorId)
        {
            DoorId = doorId;
        }

        public int BadgeId { get; set; }
        public List<String> DoorId { get; set; }
    }
}
