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
        transform.position = Vector3.Lerp(transform.position, in_vec, step);
        if(transform.position == in_vec) { moveCounter++; }
    }

    void Update ()
    {
        switch(state)
        {
            case State.IDLE:

                break;

            case State.MOVING:
                Move(tgs.CellGetPosition(moveList[moveCounter]));
                if (moveCounter == moveList.Count - 1)
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
                        moveList = this.GetComponent<FindPath>().GetPath(transform.position, t_cell);
                        int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(this.transform.position, true));
                        tgs.CellFadeOut(startCell, Color.red, 50);
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
