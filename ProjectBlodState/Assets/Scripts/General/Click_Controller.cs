using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Controller : MonoBehaviour {

    private static Camera mainCam;

	// Use this for initialization
	void Start ()
    {
        mainCam = FindObjectOfType<Camera>();
    }
	
    string GetSelected() //returns tag of selected object
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            return hit.collider.tag;
        }
        return "NULL";
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string selected = GetSelected();
            Debug.Log(selected);
        }
	}
}
