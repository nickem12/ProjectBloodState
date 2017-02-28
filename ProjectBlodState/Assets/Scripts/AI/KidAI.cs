using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAI : MonoBehaviour {

    TGS.TerrainGridSystem tgs;

    enum State {IDLE, MOVING, MOVESELECT}
    State state;

    List<int> moveList;
    short moveCounter = 0;

	void Start ()
    {
        state = State.MOVESELECT;
        tgs = TGS.TerrainGridSystem.instance;
    }
	
    void Move(Vector3 in_vec)
    {
        float step = 5 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, in_vec, step);
        if(transform.position == in_vec) { moveCounter++; }
    }

    void Update ()
    {
        switch(state)
        {
            case State.IDLE:

                break;

            case State.MOVING:
                if (moveCounter < moveList.Count)
                { 
                    Move(tgs.CellGetPosition(moveList[moveCounter]));
                }
                else
                {
                    moveCounter = 0;
                    state = State.MOVESELECT;
                }
                break;

            case State.MOVESELECT:
                if(Input.GetMouseButtonUp(0))                   //gets path when left mouse is released and over terrain
                {
                    int t_cell = tgs.cellHighlightedIndex;
                    tgs.CellFadeOut(t_cell, Color.red, 50);
                    if (t_cell != -1)                           //checks if we selected a cell
                    {
                        int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(transform.position, true));
                        moveList = tgs.FindPath(startCell, t_cell, 0);
                        //for (int counter = 0; counter < moveList.Count; counter++)
                        //{
                            //tgs.CellFadeOut(moveList[counter], Color.green, 50f);
                        //}
                        for (int counter = 0; counter < moveList.Count; counter++)
                        {
                            Vector3 t_vec = tgs.CellGetPosition(moveList[counter]);
                            TGS.Cell cell = tgs.CellGetAtPosition(t_vec);
                            int index = tgs.CellGetIndex(cell);
                            tgs.CellFadeOut(index, Color.green, 50f);
                        }
                        moveCounter = 0;
                        state = State.MOVING;
                    }
                    else
                    {
                        Debug.Log("NULL_CELL");
                    }
                }
                break;
        }
	}
}
