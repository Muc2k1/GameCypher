using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OlympusClimper
{
    public class OCEvent //Will change to call ref later
    {
        public static Action<Node /*Step*/> ON_PLAYER_UPDATE_POSITION;
        public static Action<Node /*Step*/> ON_PLAYER_LATE_UPDATE_POSITION;
        public static Action<float /*Height*/> ON_START_MOVE_DOWN; //asdfm askdfnasjkdfnjkasdfnf
        public static Action ON_MOVE_DOWN_FINISH;
    }
}