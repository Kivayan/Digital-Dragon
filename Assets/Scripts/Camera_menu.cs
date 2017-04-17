using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_menu : MonoBehaviour {

    public Transform target;
    Vector3 tempPose;

    public float speedX;
    public float speedY;
    bool dolewej;
    bool doprawej;
    bool dogory;
    bool dodolu;
	// Use this for initialization
	void Start () {

        dolewej = false;
        doprawej = true;
        dogory = true;
        dodolu = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(dodolu);
        Debug.Log(dogory);
        Debug.Log(doprawej);
        Debug.Log(dolewej);
        tempPose = transform.position;
        transform.LookAt(target);

        if(tempPose.x <= 600)
        {
            dolewej = false;
            doprawej = true;
        }
        else if (tempPose.x >= 900)
        {
            dolewej = true;
            doprawej = false;
        }

        if (tempPose.z <= 220)
        {
            dogory = true;
            dodolu = false;
        }
        else if (tempPose.z >= 510)
        {
            dogory = false;
            dodolu = true;
        }
        

        if(doprawej && dogory)
        {
            tempPose.x += speedX;
            tempPose.z += speedY;
        }
        else if (doprawej && dodolu)
        {
            tempPose.x += speedX;
            tempPose.z -= speedY;
        }
        else if( dolewej && dodolu)
        {
            tempPose.x -= speedX;
            tempPose.z -= speedY;
        }
        else if(dolewej && dogory )
        {
            tempPose.x -= speedX;
            tempPose.z += speedY;
        }

        transform.position = tempPose;

		
	}
}
