using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Cotroller : MonoBehaviour {

    public short Selected_Character = 1;
    public short Selected_Action = 1;

	void Start () {
		
	}

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Tab))
        {
            Selected_Character++;
            if(Selected_Character > 4) { Selected_Character = 1; }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Selected_Action = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Selected_Action = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Selected_Action = 3;
        }

        switch (Selected_Character)
        {
            case 1:
                
                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;
        }
	}
}
