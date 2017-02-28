using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public enum FSM { IDLE, MOVING, ATTACKING}
    public FSM state;
    public Vector3 TargetPlayer;
    bool turn;
    float aggroDistance = 50;
    float attackRange = 20;

	void Start ()
    {
        state = FSM.IDLE;
	}
	
	void Update ()
    {
		if(turn)
        {
            float dist = UpdateTarget();
            switch (state)
            {
                case FSM.IDLE:
                    if (dist < aggroDistance)
                    {
                        state = FSM.ATTACKING;
                    }
                    else
                    {
                        turn = false;
                    }
                    break;

                case FSM.ATTACKING:
                    if(dist < attackRange)
                    {
                        //attack
                        turn = false;
                    }
                    else
                    {
                        PlanMove();
                        state = FSM.MOVING;
                    }
                    break;

                case FSM.MOVING:
                    if (Move())
                    {
                        turn = false;
                    }
                    break;
            }
        }
	}

    bool Move()
    {
        return true;
    }

    void PlanMove()
    {

    }

    float UpdateTarget()
    {
        float dist = 0;
        float t_dist = 0;
        short count = 0;
        GameObject[] TargetList = GameObject.FindGameObjectsWithTag("Player");

        if(TargetPlayer != null)
        {
            dist = Vector3.Distance(transform.position, TargetPlayer);
        }
        else
        {
            dist = Vector3.Distance(transform.position, TargetList[0].transform.position);
        }

        for(; count < TargetList.Length; count++)
        {
            t_dist = Vector3.Distance(TargetPlayer, TargetList[count].transform.position);
            if(t_dist < dist)
            {
                dist = t_dist;
                TargetPlayer = TargetList[count].transform.position;
            }
        }
        return dist;
    }
}
