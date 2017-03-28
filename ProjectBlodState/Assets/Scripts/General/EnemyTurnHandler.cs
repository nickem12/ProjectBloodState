using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnHandler : MonoBehaviour {

    GameObject[] EnemyList;

    private void Start()
    {
        EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void NewTurn()
    {
        for(short counter = 0; counter < EnemyList.Length; counter++)
        {
            EnemyList[counter].GetComponent<EnemyStats>().Moved = false;
            EnemyList[counter].GetComponent<EnemyStats>().Attacked = false;
            EnemyList[counter].GetComponent<EnemyStats>().End = false;
        }
    }

    public bool Perform_Turn()
    {
        short Counter = 0;
        short End_Turn_Counter = 0;
        for (Counter = 0; Counter < EnemyList.Length; Counter++)
        {
            if (EnemyList[Counter].GetComponent<EnemyStats>().End)
            {
                End_Turn_Counter++;
            }
        }
        if (End_Turn_Counter == EnemyList.Length)
        {
            Debug.Log("All enemies haved ended their turn.");
            return true;
        }
        return false;
    }

    public bool CheckEnemy(short EnemyIndex, string Command)
    {
        switch (Command)
        {
            case "Move":
                if (EnemyList[EnemyIndex].GetComponent<EnemyStats>().Moved == true) { return true; }
                break;

            case "Attack":
                if (EnemyList[EnemyIndex].GetComponent<EnemyStats>().Attacked == true) { return true; }
                break;

            case "End":
                if (EnemyList[EnemyIndex].GetComponent<EnemyStats>().End == true) { return true; }
                break;
        }
        return false;
    }

    public void ModifyEnemy(short EnemyIndex, string Command)
    {
        switch (Command)
        {
            case "Move":
                EnemyList[EnemyIndex].GetComponent<EnemyStats>().Moved = true;
                CheckEnd(EnemyIndex);
                break;

            case "Attack":
                EnemyList[EnemyIndex].GetComponent<EnemyStats>().Attacked = true;
                CheckEnd(EnemyIndex);
                break;

            case "End":
                EnemyList[EnemyIndex].GetComponent<EnemyStats>().End = true;
                break;
        }
    }

    void CheckEnd(short EnemyIndex)
    {
        if (EnemyList[EnemyIndex].GetComponent<EnemyStats>().Attacked && EnemyList[EnemyIndex].GetComponent<EnemyStats>().Moved)
        {
            EnemyList[EnemyIndex].GetComponent<EnemyStats>().End = true;
        }
    }

    public GameObject GetEnemy(short EnemyIndex)
    {
        return EnemyList[EnemyIndex];
    }

    public void EndTurn()
    {
        for (short counter = 0; counter < EnemyList.Length; counter++)
        {
            EnemyList[counter].GetComponent<EnemyStats>().End = true;
        }
    }
}
