using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public short actionCounter = 0;
    public bool Moved = false;
    public bool Attacked = false;
    public bool Ability = false;
    public bool EndTurn = false;
    public short Health;

    void Start()
    {
        Health = 20;
    }

    void Update()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
