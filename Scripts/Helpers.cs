using UnityEngine;
using System.Collections;

public class Helpers : MonoBehaviour{
	public GameObject leftCamera;
	public GameObject rightCamera;

	private static Helpers _instance;
	public static Helpers instance {
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<Helpers>();
			}
			return _instance;
		}
	}

	public void ToggleActive (GameObject go) {
		if (go.activeInHierarchy) {
			go.SetActive(false);
		} else {
			go.SetActive(true);
		}
	}

	void ChangeMainCamera() {

		if (Input.mousePosition.x > Screen.width / 2) {
			leftCamera.tag = "Untagged";
			rightCamera.tag = "MainCamera";
		} else {
			leftCamera.tag = "MainCamera";
			rightCamera.tag = "Untagged";
		}

	}

	void FixedUpdate() {
		ChangeMainCamera ();

	}

}
