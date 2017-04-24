using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_script : MonoBehaviour {

    public GameObject player;
    public float x_pos;
    public float y_pos;
    public float z_pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = new Vector3(x_pos, y_pos ,z_pos);
    }

}
