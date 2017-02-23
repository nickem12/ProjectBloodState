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

    public List<int> GetPath(Vector3 charPos, Vector3 targetPos)
    {
        int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(charPos));
        int endCell = tgs.CellGetIndex(tgs.CellGetAtPosition(targetPos));

        List<int> PathList = tgs.FindPath(startCell, endCell, 0);
        return (PathList);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
