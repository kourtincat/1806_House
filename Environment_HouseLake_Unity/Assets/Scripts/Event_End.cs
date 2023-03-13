using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_End : MonoBehaviour {

    public GameObject Camera;
    public GameObject Door;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            GetComponent<Animator>().SetTrigger("End");
            Player.SetActive(false);
            Camera.SetActive(true);
        }
    }

    void HideDoor()
    {
        Door.SetActive(false);
    }
}
