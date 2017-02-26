using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Bar : MonoBehaviour {

    public Texture2D actionBar;
    public Texture2D Move;
    public Texture2D Attack;
    public Texture2D Empty;
    public Texture2D Dash;
    public Texture2D Hack;
    public Texture2D Supplies;
    public Texture2D Highlight;
    public Rect barPosition;
    public List<Rect> actionRectList;

    public float actionX;
    public float actionY;
    public float actionWidth;
    public float actionHeight;
    public float actionDistance;

	void Start ()
    {
        while(actionRectList.Count < 3)
        {
            actionRectList.Add(new Rect(0,0,0,0));
        }
    }

	void Update ()
    {
        UpdateActionPos();
    }

    void OnGUI()
    {
        DrawActionBar();
        DrawIcons();
    }

    void DrawIcons()
    {
        GUI.DrawTexture(getScreenRect(actionRectList[0]), Move);
        GUI.DrawTexture(getScreenRect(actionRectList[1]), Attack);
        switch (this.GetComponent<Selected_Cotroller>().Selected_Character)
        {
            case 1:
                GUI.DrawTexture(getScreenRect(actionRectList[2]), Empty);
                break;

            case 2:
                GUI.DrawTexture(getScreenRect(actionRectList[2]), Dash);
                break;

            case 3:
                GUI.DrawTexture(getScreenRect(actionRectList[2]), Hack);
                break;

            case 4:
                GUI.DrawTexture(getScreenRect(actionRectList[2]), Supplies);
                break;
        }
        switch(this.GetComponent<Selected_Cotroller>().Selected_Action)
        {
            case 1:
                GUI.DrawTexture(getScreenRect(actionRectList[0]), Highlight);
                break;

            case 2:
                GUI.DrawTexture(getScreenRect(actionRectList[1]), Highlight);
                break;

            case 3:
                GUI.DrawTexture(getScreenRect(actionRectList[2]), Highlight);
                break;
        }
    }

    void UpdateActionPos()
    {
        for(short count = 0; count < actionRectList.Count; count++)
        {
            actionRectList[count] = new Rect(actionX + count * (actionWidth + actionDistance), actionY, actionWidth, actionHeight);
        }
    }

    void DrawActionBar()
    {
        GUI.DrawTexture(getScreenRect(barPosition), actionBar);
    }

    Rect getScreenRect(Rect in_position)
    {
        return new Rect(Screen.width * in_position.x, Screen.height * in_position.y, Screen.width * in_position.width, Screen.height * in_position.height);
    }
}
