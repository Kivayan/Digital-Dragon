using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour {

    public float speedMove;
    public float stopTime;
    public float moveTime;
    Vector3 tempPose;

    public bool gora;
    public bool dol;

    float timer;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {

        tempPose = transform.position;

        if(gora)
        {
            timer += Time.deltaTime;
            tempPose.y += speedMove * Time.deltaTime;
            if (timer > moveTime)
            {
                tempPose.y = transform.position.y;
                if(timer > stopTime)
                {
                    timer = 0f;
                    gora = false;
                    dol = true;
                }

            }
        }
        if(dol)
        {
            timer += Time.deltaTime;
            tempPose.y -= speedMove * Time.deltaTime;
            if (timer > moveTime)
            {
                tempPose.y = transform.position.y;
                if (timer > stopTime)
                {
                    timer = 0f;
                    dol = false;
                    gora = true;
                }
            }
        }

        transform.position = tempPose;
	}
}
