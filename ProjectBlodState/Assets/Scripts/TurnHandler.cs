using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turns
{
    class TurnHandler : MonoBehaviour
    {

        List<Player> PlayerList = new List<Player>();
        bool All_Turns_Complete = false;

        public void Make_Players(short Number_Of_Players)
        {
            short Counter = 0;

            for (Counter = 1; Counter < Number_Of_Players + 1; ++Counter)
            {
                Player player = new Player(false, Counter);

                PlayerList.Add(player);
            }
        }

        public void Perform_Turn(short Character_Select)
        {

            short Counter = 0;
            short End_Turn_Counter = 0;
            for (Counter = 0; Counter < PlayerList.Count; Counter++)
            {
                if (PlayerList[Counter].End_Turn)
                {
                    End_Turn_Counter++;
                }
            }
            if (End_Turn_Counter == PlayerList.Count)
            {
                Debug.Log("All characters haved ended their turn.");
                All_Turns_Complete = true;
                return;
            }

            string InputString;

            InputString = Console.ReadLine();

            short InputShort;

            InputShort = short.Parse(InputString);

            ModifyCharacter(Character_Select, InputShort);
        }

        short SwitchCharacter(short CharacterIndexReturn)
        {
            
            if(CharacterIndexReturn > PlayerList.Count - 1)
            {
                CharacterIndexReturn = 0;
            }

            if(PlayerList[CharacterIndexReturn].End_Turn)
            {
                Debug.Log("This Character has already ended their turn");
                CharacterIndexReturn++;
            }

            if (CharacterIndexReturn > PlayerList.Count - 1)
            {
                CharacterIndexReturn = 0;
                SwitchCharacter(CharacterIndexReturn);
            }

            return CharacterIndexReturn;
        }

        void PrintCharacterSelect()
        {
            short Counter = 0;
            
            for(Counter = 0; Counter < PlayerList.Count; Counter++)
            {
                Debug.Log("Press " + (Counter + 1) + " for character " + (Counter + 1));
            }
        }

        void ModifyCharacter(short Character_ID, short Input)
        {

            short HoldValue;

            switch(Input)
            {

                case 1:
                    PlayerList[Character_ID].Used_Abilities = true;
                    PlayerList[Character_ID].End_Turn = true;
                    Debug.Log("Character: " + PlayerList[Character_ID].ID + " used their abilities");
                    Debug.Log("Character: " + PlayerList[Character_ID].ID + " ended their turn");
                    Debug.Log("");
                    Debug.Log("");

                    Character_ID++;

                    HoldValue = SwitchCharacter(Character_ID);

                    Perform_Turn(HoldValue);
                    break;

                case 2:
                    PlayerList[Character_ID].End_Turn = true;
                    Debug.Log("Character: " + PlayerList[Character_ID].ID + " ended their turn");
                    Debug.Log("");
                    Debug.Log("");

                    Character_ID++;

                    HoldValue = SwitchCharacter(Character_ID);

                    Perform_Turn(HoldValue);
                    break;

                case 3:
                    Debug.Log("");
                    Debug.Log("Please choose what character you wish to select");
                    PrintCharacterSelect();

                    string InputString;

                    InputString = Console.ReadLine();

                    short InputShort = short.Parse(InputString);

                    InputShort -= 1;

                    HoldValue = SwitchCharacter(InputShort);

                    Perform_Turn(HoldValue);

                    break;

                default:
                    Debug.Log();
                    Debug.Log("Invalid Input");

                    HoldValue = SwitchCharacter(Character_ID);
                    Perform_Turn(HoldValue);
                    break;
            }

           

        }

        ~TurnHandler()
        {
            PlayerList.Clear();
        }

    }
}
     

