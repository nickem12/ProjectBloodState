using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    public LayerMask PMask;
    public LayerMask EMask;

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
        Ray ray = new Ray(new Vector3(origin.x, origin.y + 1, origin.z), target.transform.position - origin);
        Debug.DrawRay(new Vector3(origin.x, origin.y + 1, origin.z), target.transform.position - origin, Color.green, 20, false);

        switch(target.tag)
        {
            case "Enemy":
                if (Physics.Raycast(ray, out hit, range, EMask))
                {
                    if (hit.collider.tag == target.tag) { return true; }
                }
                break;

            case "Player":
                if (Physics.Raycast(ray, out hit, range, PMask))
                {
                    if (hit.collider.tag == target.tag) { return true; }
                }
                break;
        }
        
        return false;
    }
}
