using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    public List<GameObject> PlayerList = new List<GameObject>();

    public void NewTurn()
    {
        for(short counter = 0; counter < PlayerList.Count; counter++)
        {
            PlayerList[counter].GetComponent<PlayerStats>().EndTurn = false;
            PlayerList[counter].GetComponent<PlayerStats>().Attacked = false;
            PlayerList[counter].GetComponent<PlayerStats>().Moved = false;
            PlayerList[counter].GetComponent<PlayerStats>().Ability = false;
            PlayerList[counter].GetComponent<PlayerStats>().actionCounter = 0;
        }
    }

    public bool Perform_Turn()
    {
        short Counter = 0;
        short End_Turn_Counter = 0;
        for (Counter = 0; Counter < PlayerList.Count; Counter++)
        {
            if (PlayerList[Counter].GetComponent<PlayerStats>().EndTurn)
            {
                End_Turn_Counter++;
            }
        }
        if (End_Turn_Counter == PlayerList.Count)
        {
            Debug.Log("All characters haved ended their turn.");
            return true;
        }
        return false;
    }

    public bool CheckCharacter(short CharIndex, string Command)
    {
        CharIndex--;
        switch(Command)
        {
            case "Move":
                if (PlayerList[CharIndex].GetComponent<PlayerStats>().Moved == true) { return true; }
                break;

            case "Attack":
                if (PlayerList[CharIndex].GetComponent<PlayerStats>().Attacked == true) { return true; }
                break;

            case "Ability":
                if (PlayerList[CharIndex].GetComponent<PlayerStats>().Ability == true) { return true; }
                break;

            case "End":
                if (PlayerList[CharIndex].GetComponent<PlayerStats>().EndTurn == true) { return true; }
                break;
        }
        return false;
    }

    public void ModifyCharacter(short CharIndex, string Command)
    {
        CharIndex--;
        switch(Command)
        {
            case "Move":
                PlayerList[CharIndex].GetComponent<PlayerStats>().Moved = true;
                PlayerList[CharIndex].GetComponent<PlayerStats>().actionCounter++;
                CheckEnd(CharIndex);
                break;

            case "Attack":
                PlayerList[CharIndex].GetComponent<PlayerStats>().Attacked = true;
                PlayerList[CharIndex].GetComponent<PlayerStats>().actionCounter++;
                CheckEnd(CharIndex);
                break;

            case "Ability":
                PlayerList[CharIndex].GetComponent<PlayerStats>().Ability = true;
                PlayerList[CharIndex].GetComponent<PlayerStats>().actionCounter++;
                CheckEnd(CharIndex);
                break;
        }
    }

    void CheckEnd(short CharIndex)
    {
        if (PlayerList[CharIndex].GetComponent<PlayerStats>().actionCounter >= 2)
        {
            PlayerList[CharIndex].GetComponent<PlayerStats>().EndTurn = true;
        }
    }

    public GameObject GetCharacter(short CharIndex)
    {
        return PlayerList[CharIndex - 1];
    }

    public void EndTurn()
    {
        for(short counter = 0; counter < PlayerList.Count; counter++)
        {
            PlayerList[counter].GetComponent<PlayerStats>().EndTurn = true;
        }
    }

    ~TurnHandler()
    {
        PlayerList.Clear();
    }

}