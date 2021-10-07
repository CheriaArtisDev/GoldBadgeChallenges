using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
    {
        // researched Dictionary https://www.tutorialsteacher.com/csharp/csharp-dictionary

        protected readonly Dictionary<int, Badge> _badgesRepo = new Dictionary<int, Badge>();
        public bool CreateNewBadge(Badge badge)
        {
            int startingCount = _badgesRepo.Count;
            _badgesRepo.Add(badge.BadgeId, badge);

            bool wasAdded = (_badgesRepo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Dictionary<int, Badge> DisplayAllBadges()
        {
            return _badgesRepo;
        }

        public Badge FindBadgeById(int badgeId)
        {
            foreach(var badgeInfo in _badgesRepo)
            {
                if(badgeInfo.Key == badgeId)
                {
                    return badgeInfo.Value;
                }
            }
            return null;
        }

        public bool UpdateBadgeInfo(int existingBadgeId, Badge newBadge)
        {
            Badge oldId = FindBadgeById(existingBadgeId);
            if(oldId != null)
            {
                oldId.BadgeId = newBadge.BadgeId;
                oldId.DoorId = newBadge.DoorId;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDoor(int badgeId, string doorId)
        {
            Badge badgeInfo = FindBadgeById(badgeId);
            int startingCount = badgeInfo.DoorId.Count;
            badgeInfo.DoorId.Add(doorId);
            bool wasAdded = (badgeInfo.DoorId.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool RemoveDoorFromBadge(int badgeId, string doorId)
        {
            Badge badgeInfo = FindBadgeById(badgeId);
            bool result = badgeInfo.DoorId.Remove(doorId);
            return result;
        }

        public bool RemoveDoorById(int badgeId)
        {
            bool wasRemoved = _badgesRepo.Remove(badgeId);
            return wasRemoved;
        }     
    }
}
