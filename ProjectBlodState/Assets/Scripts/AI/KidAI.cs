using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAI : MonoBehaviour {

    enum State {IDLE, MOVING, MOVESELECT}
    State state;

	// Use this for initialization
	void Start ()
    {
        state = State.IDLE;
	}
	
    void Move()
    {

    }

    void SetMove()
    {
        this.GetComponent<FindPath>().GetPath(this.transform.position, GetRayCast("Terrain"));
    }

    Vector3 GetRayCast(string input) //returns tag of selected object
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.collider.tag == input)
            {
                return (hit.transform.position);
            }
            else
            {
                return (new Vector3(0,0,0));
            }
        }
        else
        {
            return (new Vector3(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update ()
    {
        switch(state)
        {
            case State.IDLE:

                break;

            case State.MOVING:
                Move();
                break;
        }
	}
}
