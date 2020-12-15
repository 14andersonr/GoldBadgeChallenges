using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Repos
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _badgeDirectory = new Dictionary<int, Badge>();
        int Count;

        // Create
        public void AddBadgeToDict(Badge badge)
        {
            Count++;
            _badgeDirectory.Add(Count,badge); //Fields have underscores. Properties don't
        }

        // Read
        public Dictionary<int,Badge> GetBadgeList()
        {
            return _badgeDirectory;
        }

        // Update
        public bool UpdateExistingBadge(int dictKey, Badge newID)
        {
            //Find
            Badge oldID = GetBadgeByDictionaryKey(dictKey);

            //Update
            if (oldID != null)
            {
                oldID.BadgeID = newID.BadgeID;
                oldID.DoorNames = newID.DoorNames;

                return true;
            }
            else
            {
                return false;
            }
        }

      //  Delete
        public bool RemoveBadgeFromDict(int dictKey)
        {   Badge badge = GetBadgeByDictionaryKey(dictKey);

            if (badge == null)
            {
                return false;
            }

            int initialCount = _badgeDirectory.Count;

            foreach (var item in _badgeDirectory)
            {
                if (item.Key==dictKey)
                {
                    _badgeDirectory.Remove(badge.BadgeID);
                }
            }

            if (initialCount > _badgeDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper (Get Badge by ID)
        public Badge GetBadgeByDictionaryKey(int dictKey)
        {
            foreach (var pair in _badgeDirectory)
            {
                if (pair.Key == dictKey)
                {
                    return pair.Value;
                }
            }

            return null;
        }
    }
}
