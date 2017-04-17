using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        Application.LoadLevel(1);
    }
}
