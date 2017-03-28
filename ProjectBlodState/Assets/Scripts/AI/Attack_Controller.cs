using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    public int AttackTarget(GameObject origin, GameObject target, float range)
    {
        if(CheckLOS(origin.transform.position, target, range))
        {
            return Random.Range(2, 4);
        }
        return -1;
    }

    bool CheckLOS(Vector3 origin, GameObject target, float range)
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
