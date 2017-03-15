using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover_Detector : MonoBehaviour {

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Cover")
        {
            
        }
    }
}
