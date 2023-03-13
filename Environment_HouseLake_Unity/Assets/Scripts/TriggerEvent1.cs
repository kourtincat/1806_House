using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent1 : MonoBehaviour
{

    public GameObject clock_event;
    public GameObject teapot_event;
    public GameObject upstairs_event;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OkThisTriggerWorks");

        if (other.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Peak");
            Debug.Log("PlayerCollidingWorks");
        }
    }

    void TeapotHeatingEvent()
    {
        teapot_event.GetComponent<AudioSource>().Play();
    }

    void ClockTickTockEvent()
    {
        clock_event.GetComponent<AudioSource>().Play();
    }

    void UpstairsFootStepsEvent()
    {
        upstairs_event.GetComponent<AudioSource>().Play();
    }
}
