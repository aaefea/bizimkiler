using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject cutcontrol;
    public GameObject player;
    public GameObject canvas;
    
    bool a = false;
    bool b = false;
    bool work = true;
    int value = 0;
    //public GameObject Gate;

    void Update()
    {
        // Debug.Log(value);
        // Debug.Log(a);
        // Debug.Log(b);

        if (a && b && value == 0 && work)
        {
            StartCoroutine(Cutscene());
        }
    }

    IEnumerator Cutscene()
    {
        work = false;
        cutcontrol.SetActive(true);
        player.SetActive(false);
        canvas.SetActive(false);
        yield return new WaitForSeconds(26f);
        cutcontrol.SetActive(false);
        player.SetActive(true);
        canvas.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "a")
        {
            a = true;
        }
        if (other.gameObject.tag == "b")
        {
            b = true;
        }
        if (other.gameObject.tag == "c")
        {
            value = value + 1;
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "a")
        {
            a = false;
        }
        if (other.gameObject.tag == "b")
        {
            b = false;
        }
        if (other.gameObject.tag == "c")
        {
            value = value - 1;
        }
    }


        

    /*      private void OnTriggerStay(Collider other)
          {
              if (other.gameObject.tag == "a")
              {
                  Debug.Log("staying");
              }
          }
    */
}