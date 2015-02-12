using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VertMover : MonoBehaviour {
	private Vector3 goPosition;
	private Mesh mesh;
	private Vector3[] vertices;
	private List<GameObject> handles = new List<GameObject>();
	public GameObject vertHandle;

	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		goPosition = transform.position;

		// Create handles and lists for each vertex in the mesh
		foreach (Vector3 vertex in vertices) {
			GameObject h = (GameObject)Instantiate (vertHandle, transform.TransformPoint(vertex), Quaternion.identity);

			// Child instantiated handles to mesh and add it to our list
			h.transform.parent = gameObject.transform;
			handles.Add(h);

		}
	}
	
	void Update () {
		// Setting GameObject position as an easier to access variable
		goPosition = transform.position;

		// Update vertices positions based on handle positions
		for(int i = 0; i < vertices.Length; ++i) {
			vertices[i] = handles[i].transform.localPosition;
		}

		// Reassign vertices and redraw mesh
		mesh.vertices = vertices;
		mesh.RecalculateBounds ();

		// Toggle handles with H key
		if (Input.GetKeyDown (KeyCode.H)) {
			foreach (GameObject handle in handles) {
				Helpers.instance.ToggleActive(handle);
			}
		}
	}


}
