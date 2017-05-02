using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Transform player;
    public Transform score;

    public float soldierNumer;
    public float maxSoldier;
    public Text soldierText;
    public Canvas overScreen;

    public float pickUpNumber;
    public float pickUpMax;
    public Text pickUpText;

    float next_map_timer;
    bool next_map;
    public float timer;
    public Text timerText;
    bool timerStop;
	// Use this for initialization
	void Start ()
    {
        next_map = false;
        next_map_timer = 0f;
        bool timeStop = false;
        //timerText = GetComponent<Text>();
        timerText = GameObject.Find("Text_Time").GetComponent<Text>();
        soldierText = GameObject.Find("Text_Soldier").GetComponent<Text>();
        pickUpText = GameObject.Find("Text_PickUp").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0f;
        soldierNumer = 0f;
        pickUpNumber = 0f;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(soldierNumer);

        //Obsługa Timeru
        if(!timerStop)
        timer += Time.deltaTime;

        string minutes = ((int)timer / 60).ToString();
        string secounds = (timer % 60).ToString("f2");

        timerText.text = minutes + ":" + secounds;

        soldierText.text = "" + soldierNumer + " / " + maxSoldier;

        pickUpText.text = pickUpNumber + " / " + pickUpMax;
		
        if(next_map)
        {
            next_map_timer += Time.deltaTime;
        }

        if (next_map_timer > 10)
        {
            Application.LoadLevel(0);
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            EndGame();
        }
	}

    public void EndGame()
    {
        player.GetComponent<CharacterController>().enabled = false;
        //player.GetComponent<DragonController>().TriggerDanceAnimation();
        timerStop = true;
        overScreen.enabled = true;

    }
    
    public void MenDown(int soldier)
    {
        soldierNumer = soldierNumer + soldier;
    }

    public void PickUp()
    {
        pickUpNumber++;
    }


    
}
