using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    int AttackTarget(GameObject origin, GameObject target, float offset, float range)
    {
        if(CheckLOS(origin.transform.position, target, offset, range))
        {
            if(ComputeHit(origin.transform.position, target.transform.position))
            {
                return Random.Range(2, 4);
            }
        }
        return -1;
    }

    bool ComputeHit(Vector3 origin, Vector3 target)
    {
        int max = 100;
        int min = 0;
        float dist = Vector3.Distance(origin, target);

        min = (int)dist / 4;
        int random = Random.Range(min, max);
        if(random > 50)
        {
            return true;
        }
        return false;
    }

    bool CheckLOS(Vector3 origin, GameObject target, float offset, float range)
    {
        RaycastHit hit;
        Ray ray = new Ray(origin, target.transform.position - origin);
  
        if (Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.tag == target.tag) { return true; }
        }
        return false;
    }
}
