using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_ClassLibrary
{
    public class BadgesRepo
    {
        public Dictionary<int, Badges> _badgeLog = new Dictionary<int, Badges>();
        public void CreateNewBadge(int badgeID, Badges badge)
        {
            _badgeLog.Add(badgeID, badge);
        }
        public Dictionary<int, Badges> ListBadges()
        {
            return _badgeLog;
        }
        public bool UpdateDoorsOnBadge(int badgeID, Badges newBadgeAccess)
        {
            Badges oldBadgeAccess = SearchBadgeID(int BadgeID)
         if (oldBadgeID != null)
          { 
            oldBadgeAccess.BadgeID = newBadgeAccess.BadgeID;
            oldBadgeAccess.DoorNames = newBadgeAccess.DoorNames;
            return true;
          }
         else
          {
                return false;
            }
        }
        public void SearchBadgeID(int badgeID, Badges badges)
        {
            if (badges.BadgeID == badgeID)
            {
                return badges;
            }
            else
            {
                return null;
            }
        }
    }
}




        
