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
        public void CreateNewBadge(int badgeid, Badges badge)
        {
            _badgeLog.Add(badgeid, badge);
        }
        public Dictionary<int, Badges> ListAllBadges()
        {
            return _badgeLog;
        }
        public bool UpdateBadgeAccess(int badgeID, Badges newDoorAccess)
        {
            Badges oldAccess = SearchBadgeID(badgeID);
            if(oldAccess != null)
            {
                oldAccess.BadgeID = newDoorAccess.BadgeID;
                oldAccess.DoorNames = newDoorAccess.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDoorFromBadge(int badgeID)
        {
            Badges badge = SearchBadgeID(badgeID);
            if(badge == null)
            {
                return false;
            }
            int initialCount = _badgeLog.Count();
            if(initialCount > _badgeLog.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
        public Badges SearchBadgeID(int iD)
        { 
           if(_badgeLog.TryGetValue(iD, out Badges badgeResult))
            {
                return badgeResult;
            }
            else
            {
                return null;
            }
            }
        }
 }





        
