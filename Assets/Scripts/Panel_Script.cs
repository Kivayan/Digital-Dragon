using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Script : MonoBehaviour
{
    public Image tutorial;
    private bool Enter;

    // Use this for initialization
    private void Start()
    {
        Enter = false;

     tutorial.GetComponent<Image>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Enter = true;
        Debug.Log("kupa");
        tutorial.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Enter = false;
        tutorial.enabled = false;
    }
}