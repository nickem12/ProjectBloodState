using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public enum FSM { IDLE, MOVING, ATTACKING}
    public Vector3 TargetPlayer;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    void UpdateTarget()
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
    }
}
