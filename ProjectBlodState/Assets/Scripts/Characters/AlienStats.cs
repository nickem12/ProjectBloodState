using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public class AlienStats
    {

        public short HP = 6;
        public short ATK = 10;
        public short RANGE = 15;
        public short DEF = 15;
        public short MOVEMENT = 7;
        public bool COVER = false;
    }

    public class TankAlienStats : AlienStats
    {
        public TankAlienStats()
        {
            HP += 1;
            ATK -= 5;
            RANGE -= 7;
            DEF += 5;
            MOVEMENT -= 4;
            COVER = false;
        }
    }

    public class RangedAlienStats : AlienStats
    {

        public RangedAlienStats()
        {
            HP -= 2;
            ATK += 1;
            RANGE += 2;
            DEF -= 5;
            MOVEMENT -= 2;
            COVER = false;
        }

    }

    public class MeleeAlienStats : AlienStats
    {

        public MeleeAlienStats()
        {
            HP += 1;
            ATK -= 1;
            RANGE -= 10;
            DEF -= 2;
            MOVEMENT -= 1;
            COVER = false;
        }

    }

    public class BossAlienStats : AlienStats
    {
        public BossAlienStats()
        {
            HP += 8;
            ATK += 5;
            RANGE += 5;
            DEF += 5;
            MOVEMENT -= 1;
            COVER = false;
        }
          
    }
}
