using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turns
{
    public class Player : MonoBehaviour
    {

        public bool End_Turn;
        public bool Used_Abilities;
        public short ID = 0;

        public Player(bool End_Turn_Parameter, short ID_Parameter)
        {
            End_Turn = End_Turn_Parameter;
            ID = ID_Parameter;
            Used_Abilities = false;
        }


    }
}
