using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public short health = 10;

    public bool Attacked = false;
    public bool Moved = false;
    public bool End = false;

    private void Update()
    {
        if(health <= 0)
        {
           Destroy(this.gameObject);
        }
    }
}
