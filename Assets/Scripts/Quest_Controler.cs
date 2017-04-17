using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Controler : MonoBehaviour {

    public GameObject mum;
    public GameObject Quest_one;
    public GameObject Quest_two;
    bool changeQuest;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        changeQuest = mum.GetComponent<NowaKamera>().firstTime;
        //Debug.Log(changeQuest);
        if(changeQuest)
        {
            Quest_one.SetActive(false);
            Quest_two.SetActive(true);
        }
	}
}
