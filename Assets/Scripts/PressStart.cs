using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour {


    bool isPaused = true;

    public KeppindaScore score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                score.Resume();
            else
                score.Pause();
            isPaused = !isPaused;
        }
	}
}
