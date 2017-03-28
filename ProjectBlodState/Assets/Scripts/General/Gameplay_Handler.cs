using System.Collections;
using System.Collections.Generic;
using TGS;
using UnityEngine;

public class Gameplay_Handler : MonoBehaviour {

    GameObject Select;
    GameObject Cam;
    public enum GameState { PLAYER, ENEMY }
    public enum MoveState { MOVING, MOVESELECT }
    MoveState MState;
    GameState GState;
    public short SelectChar;

    TerrainGridSystem tgs;
    short moveCounter = 0;
    List<int> moveList;

    public short PlayerRange;

    void Start ()
    {
        Select = GameObject.Find("GUI");
        Cam = GameObject.Find("Cam_obj");
        GState = GameState.PLAYER;
        MState = MoveState.MOVESELECT;
        tgs = TerrainGridSystem.instance;
        PlayerRange = 50;
    }
	
	void Update ()
    {
        switch(GState)
        {
            case GameState.PLAYER:
                SelectChar = Select.GetComponent<Selected_Cotroller>().Selected_Character;
                UpdateActions(Select.GetComponent<Selected_Cotroller>().Selected_Action);
                if(GetComponent<TurnHandler>().Perform_Turn())
                {
                    GState = GameState.ENEMY;
                }
                break;

            case GameState.ENEMY:

                break;
        }
	}

    void UpdateActions(short input)
    {
        switch(input)
        {
            case 1:
                if (!GetComponent<TurnHandler>().CheckCharacter(SelectChar, "Move") && !GetComponent<TurnHandler>().CheckCharacter(SelectChar, "End"))
                {
                    switch(MState)
                    {
                        case MoveState.MOVESELECT:
                            if (Input.GetMouseButtonUp(0))
                            {   //gets path when left mouse is released and over terrain
                                GetPath(GetComponent<TurnHandler>().GetCharacter(SelectChar));
                            }
                            break;

                        case MoveState.MOVING:
                            if (moveCounter < moveList.Count)
                            {   //moves character
                                Move(tgs.CellGetPosition(moveList[moveCounter]), GetComponent<TurnHandler>().GetCharacter(SelectChar));
                            }
                            else
                            {
                                moveCounter = 0;
                                MState = MoveState.MOVESELECT;
                                GetComponent<TurnHandler>().ModifyCharacter(SelectChar, "Move");
                            }
                            break;
                    }
                }
                break;

            case 2:
                if (!GetComponent<TurnHandler>().CheckCharacter(SelectChar, "Attack") && !GetComponent<TurnHandler>().CheckCharacter(SelectChar, "End"))
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, 100.0f))
                        {
                            if(hit.collider.tag == "Enemy")
                            {
                                int damage = GetComponent<Attack_Controller>().AttackTarget(GetComponent<TurnHandler>().GetCharacter(SelectChar), hit.collider.gameObject, PlayerRange);
                                if (damage > 0)
                                {
                                    hit.collider.gameObject.GetComponent<EnemyStats>().health -= (short)damage;
                                    GetComponent<TurnHandler>().ModifyCharacter(SelectChar, "Attack");
                                }
                            }
                        }
                    }
                }
                break;

            case 3:
                if (!GetComponent<TurnHandler>().CheckCharacter(SelectChar, "Ability") && !GetComponent<TurnHandler>().CheckCharacter(SelectChar, "End"))
                {

                }
                break;
        }
    }

    void GetPath(GameObject MoveChar)
    {
        int t_cell = tgs.cellHighlightedIndex;
        tgs.CellFadeOut(t_cell, Color.red, 50);
        if (t_cell != -1)
        {   //checks if we selected a cell
            int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(MoveChar.transform.position, true));
            moveList = tgs.FindPath(startCell, t_cell, 0);
            if (moveList == null) return;
            for (int counter = 0; counter < moveList.Count; counter++)
            {
                tgs.CellFadeOut(moveList[counter], Color.green, 5f);
            }
            moveCounter = 0;
            MState = MoveState.MOVING;
        }
        else
        {
            Debug.Log("NULL_CELL");
        }
    }

    void Move(Vector3 in_vec, GameObject MoveChar)
    {
        float speed = moveList.Count * 5f;
        float step = speed * Time.deltaTime;

        // target position must account the sphere height since the cellGetPosition will return the center of the cell which is at floor.
        //in_vec.y += transform.localScale.y * 0.5f;
        MoveChar.transform.position = Vector3.MoveTowards(MoveChar.transform.position, in_vec, step);

        // Check if character has reached next cell (we use a small threshold to avoid floating point comparison; also we check only xz plane since the character y position could be adjusted or limited
        // by the slope of the terrain).
        float dist = Vector2.Distance(new Vector2(MoveChar.transform.position.x, MoveChar.transform.position.z), new Vector2(in_vec.x, in_vec.z));
        if (dist <= 0.1f)
        {
            moveCounter++;
        }
    }
}
