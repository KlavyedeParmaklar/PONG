using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuControls : MonoBehaviour {
    public Button playButton;
    public Button exitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Play_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }
}
