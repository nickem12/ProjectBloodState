using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    TGS.TerrainGridSystem tgs;

	void Start ()
    {
        tgs = TGS.TerrainGridSystem.instance;
	}

    public List<int> GetPath(Vector3 charPos, int endCell)
    {
        int startCell = tgs.CellGetIndex(tgs.CellGetAtPosition(charPos, true));
        List<int> PathList = tgs.FindPath(startCell, endCell, 0);
        return (PathList);
    }
	
	void Update ()
    {
		
	}
}