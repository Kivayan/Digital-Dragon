using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NowaKamera : MonoBehaviour {

    public Animator anim;
    public Animator playerAnim;

    public GameObject player;
    public GameObject camera;
    public GameObject talkPanel;
    public Transform detale;
    public bool firstTime;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponentInParent<Animator>();
        playerAnim = FindObjectOfType<CharacterController>().gameObject.GetComponentInChildren<Animator>();
        camera.SetActive(false);
        firstTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(firstTime);
        if(Input.GetKeyDown(KeyCode.F))
        {
            talk();
        }
    }
    public void talk()
    {
        if (detale.gameObject.activeInHierarchy == false)
        {
            anim.SetBool("IsTalking", true);
            playerAnim.SetInteger("MovementPhase", 0);
            Debug.Log("talkin");
            detale.gameObject.SetActive(true);
            camera.SetActive(true);
            talkPanel.SetActive(false);
            player.GetComponent<DragonController>().enabled = false;
        }
        else
        {
            anim.SetBool("IsTalking", false);
            {
                firstTime = true;
            }
            detale.gameObject.SetActive(false);
            camera.SetActive(false);
            talkPanel.SetActive(true);
            player.GetComponent<DragonController>().enabled = true;

        }
    }
}


