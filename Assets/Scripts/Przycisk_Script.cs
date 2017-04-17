using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przycisk_Script : MonoBehaviour {

    Vector3 tempPose;
    public Transform platforma;
    public GameObject fire;
    bool click;
    float timer;

	// Use this for initialization
	void Start () {
        bool click = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempPose = transform.position;
        if (click)
        {
            timer += Time.deltaTime;
            fire.SetActive(true);
            if(timer < 1f)
            {
                tempPose.x += 4f * Time.deltaTime;
                tempPose.y -= 4f * Time.deltaTime;
            }
            else if (timer >= 1f)
            {
                tempPose.x += 0f;
                tempPose.y += 0f;
            }
        }
        transform.position = tempPose;
    }

    public void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            click = true; 
        }
    }
}
