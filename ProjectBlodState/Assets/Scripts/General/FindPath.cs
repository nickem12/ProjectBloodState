using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    TGS.TerrainGridSystem tgs;

	// Use this for initialization
	void Start ()
    {
        tgs = TGS.TerrainGridSystem.instance;
	}

    public List<int> GetPath(Vector3 charPos, int endCell)
    {
        int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(charPos, true));

        List<int> PathList = tgs.FindPath(startCell, endCell, 0);
        for(int counter = 0; counter < PathList.Count; counter++)
        {
            tgs.CellFadeOut(PathList[counter], Color.green, 50f);
        }
        return (PathList);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
