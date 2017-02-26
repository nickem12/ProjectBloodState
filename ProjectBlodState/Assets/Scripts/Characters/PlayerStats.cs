using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{

    
    //Monday feb 12, 1 hour 5:30 6:30
    //Wednesday feb 15 1 hour 8:40 9:40 || 10:09
    public class PlayerStats
    {
        public enum ABILITIES { DOUBLE_HEALTH = 0, MOVE_DASH, HACKS, CAN_REVIVE, SUPPLIES };

        public ABILITIES Abilities;
        public short ABILITIY_COUNTER = 0;
        public short HP = 6;
        public short ATK = 10;
        public short RANGE = 15;
        public short DEF = 15;
        public short MOVEMENT = 7;
        public bool COVER = false; 
    }

    public class TankStats : PlayerStats
    {
       
        public TankStats()
        {
            Abilities = ABILITIES.DOUBLE_HEALTH;
            ABILITIY_COUNTER = 1;
            HP *= 2;
            ATK -= 4;
            RANGE -= 5;
            DEF += 4;
            MOVEMENT -= 1;
            COVER = false;
        }
         
    }

    public class ScoutStats : PlayerStats
    {
        
        public ScoutStats()
        {
            Abilities = ABILITIES.MOVE_DASH;
            ABILITIY_COUNTER = 3;
            HP -= 2;
            ATK += 3;
            RANGE += 5;
            DEF -= 4;
            MOVEMENT *= 2;
            COVER = false;
        }

    }

    public class RobotStats : PlayerStats
    {

        public RobotStats()
        {
            Abilities = ABILITIES.HACKS;
            ABILITIY_COUNTER = 1;
            HP += 3;
            ATK -= 5;
            RANGE += 5;
            DEF += 2;
            MOVEMENT += 0;
            COVER = false;
        }

    }

    public class EngineerStats : PlayerStats
    {
        
        public EngineerStats()
        {
            Abilities = ABILITIES.CAN_REVIVE;
            ABILITIY_COUNTER = 1;
            HP += 5;
            ATK -= 7;
            RANGE -= 8;
            DEF += 3;
            MOVEMENT -= 3;
            COVER = false;
        }

    }

    public class GeneralStats : PlayerStats
    { 

        public GeneralStats()
        {
            Abilities = ABILITIES.MOVE_DASH;
            ABILITIY_COUNTER = 4;
            HP += 2;
            ATK += 4;
            RANGE += 5;
            DEF += 1;
            MOVEMENT *= 2;
            COVER = false;
        }

    }

    public class SupportStats : PlayerStats
    {

        // Health and ammo bags are for the support ability to give his/her allies
        short HEALTH_BAGS = 3;
        short AMMO_BAGS = 3;

        public SupportStats()
        {
            Abilities = ABILITIES.SUPPLIES;
            ABILITIY_COUNTER = 6;
            HP += 1;
            ATK -= 7;
            RANGE -= 3;
            DEF += 2;
            MOVEMENT -= 2;
            COVER = false;
        }

    }
}
