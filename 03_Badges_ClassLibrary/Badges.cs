﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_ClassLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public string DoorNames { get; set; }

        public Badges() { }
        public Badges(int badgeID, string doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            
        }
    }
}
