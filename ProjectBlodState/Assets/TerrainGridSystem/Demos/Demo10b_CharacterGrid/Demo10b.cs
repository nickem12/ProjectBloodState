using UnityEngine;
using System.Collections;

namespace TGS {
	public class Demo10b : MonoBehaviour {

		TerrainGridSystem tgs;
		GUIStyle labelStyle;
		Rigidbody sphere;

		void Start () {
			tgs = TerrainGridSystem.instance;

			// setup GUI resizer - only for the demo
			GUIResizer.Init (800, 500); 

			// setup GUI styles
			labelStyle = new GUIStyle ();
			labelStyle.alignment = TextAnchor.MiddleLeft;
			labelStyle.normal.textColor = Color.black;

			sphere = GameObject.Find ("Sphere").GetComponent<Rigidbody>();
		}

		void OnGUI () {
			// Do autoresizing of GUI layer
			GUIResizer.AutoResize ();
			GUI.backgroundColor = new Color (0.8f, 0.8f, 1f, 0.5f);
			GUI.Label (new Rect (10, 5, 160, 30), "Move the ball with WASD. Hit G to reposition grid around it.", labelStyle);
			GUI.Label (new Rect (10, 25, 160, 30), "Open the Demo10b.cs script to learn how to assign gridCenter property using code.", labelStyle);
		}

		void Update() {

			// Move ball
			const float strength = 10f;
			if (Input.GetKey(KeyCode.W)) {
				sphere.AddForce(Vector3.forward * strength);
			}
			if (Input.GetKey(KeyCode.S)) {
				sphere.AddForce(Vector3.back * strength);
			}
			if (Input.GetKey(KeyCode.A)) {
				sphere.AddForce(Vector3.left * strength);
			}
			if (Input.GetKey(KeyCode.D)) {
				sphere.AddForce(Vector3.right * strength);
			}

			// Reposition grid
			if (Input.GetKey(KeyCode.G)) {

				// Terrain is centered around 0,0 and is 256x256 in size. We have a "virtual" grid of 256x256 as well. So 1 meter corresponds to 1 cell.
				float sphereTerrainCol = Mathf.FloorToInt(sphere.transform.position.x + 128f);
				float sphereTerrainRow = Mathf.FloorToInt(sphere.transform.position.z + 128f);

				// And grid center is calculated with the formula (25 is the number of rows or columns of the real grid around the sphere)
				// x = (sphereTerrainCol - 256 * 0.5) / 25
				// y = (sphereTerrainRow - 256 * 0.5) / 25
				float x = (sphereTerrainCol - 128) / 25;
				float y = (sphereTerrainRow  - 128) / 25;
				tgs.gridCenter = new Vector2(x, y);
			}

			// Position camera
			Camera.main.transform.position = sphere.transform.position + new Vector3(0,20,-20);
			Camera.main.transform.LookAt(sphere.transform.position);

		}
	

	}

}