using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Armoire : MonoBehaviour {


    public GameObject EndTrigger;
    [Tooltip("Needs an Audiosource component Attached")]
    public bool DoesTriggerSound;
    public GameObject Light;
   




    // Use this for initialization
    void Start ()
    {


        
	}
	
	// Update is called once per frame
	void Update ()
    {
		



	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            Light.SetActive(true);
            EndTrigger.SetActive(true);
            EndTrigger.GetComponent<Animator>().SetTrigger("Triggered");

            if (DoesTriggerSound == true)
            {
                EndTrigger.GetComponent<AudioSource>().Play();
            }
        }
    }


}
