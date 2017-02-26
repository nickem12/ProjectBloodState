using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Bar : MonoBehaviour {

    public Texture2D actionBar;
    public Rect position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnGUI()
    {
        DrawActionBar();
    }

    void DrawActionBar()
    {
        GUI.DrawTexture(new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height), actionBar);
    }
}
