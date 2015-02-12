using UnityEngine;
using System.Collections;

public class MovieHelper : MonoBehaviour {
	public MovieTexture[] movies;
	private MovieTexture currentMovie;
	// Use this for initialization
	void Start () {
		PlayMovie (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			PlayMovie (0);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			PlayMovie (1);
		}
	}

	void PlayMovie(int index) {
		currentMovie = (MovieTexture)renderer.material.mainTexture;
		if(currentMovie.isPlaying) {
			currentMovie.Stop ();
		}
		renderer.material.mainTexture = movies[index];
		movies[index].Play ();
	}
}
