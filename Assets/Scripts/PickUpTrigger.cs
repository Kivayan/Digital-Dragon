using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour {

    public Transform gameControler;

    // Use this for initialization
    void Start () {

        gameControler = GameObject.FindGameObjectWithTag("GameControler").transform;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        gameControler.GetComponent<GameOver>().PickUp();
        Destroy(this.gameObject);
    }
}
