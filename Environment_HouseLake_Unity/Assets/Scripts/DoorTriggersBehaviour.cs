using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorTriggersBehaviour : MonoBehaviour {

   

    [Header("GameObjects")]
    public GameObject obj_Door;

    public bool CanUnlock;
    public bool UnlockWithWrench;
    public Sprite UI_Bubble_Open;
    public Sprite UI_Bubble_Interact;


    void Start ()
    {
        if (CanUnlock == true)
            GetComponentInChildren<SpriteRenderer>().sprite = UI_Bubble_Interact;
        if (obj_Door.GetComponent<DoorBehaviour>().Locked == false)
            GetComponentInChildren<SpriteRenderer>().sprite = UI_Bubble_Open;

    }
    
    

    void OnTriggerStay (Collider Other)
    {
        if (Other.tag == "PlayerTrigger")
        {
            if (Input.GetKeyUp("e") && obj_Door.GetComponent<DoorBehaviour>().IsOpen == false && obj_Door.GetComponent<DoorBehaviour>().CanUseKnob == true)
            {
                if(UnlockWithWrench == true)
                    obj_Door.GetComponent<Animator>().SetTrigger("UnlockWithWrench");

                else
                {
                    if(CanUnlock == true)
                    {
                        obj_Door.GetComponent<Animator>().SetTrigger("Unlock");
                      //  obj_Door.GetComponent<Animator>().SetBool("IsLocked", false);
                      //  obj_Door.GetComponent<DoorBehaviour>().Locked = false;
                        GetComponentInChildren<SpriteRenderer>().sprite = UI_Bubble_Open;
                    }
                    else
                    {
                        obj_Door.GetComponent<Animator>().SetTrigger("Open");
                        obj_Door.GetComponent<DoorBehaviour>().SoundOpen();
                        Debug.Log("Open");
                        obj_Door.GetComponent<DoorBehaviour>().CanUseKnob = false;
                    }
                    
                }
              

            }

            if (Input.GetKeyDown("e") && obj_Door.GetComponent<DoorBehaviour>().IsOpen == true)
            {
                obj_Door.GetComponent<Animator>().SetTrigger("Close");
                obj_Door.GetComponent<DoorBehaviour>().SoundClose();
                Debug.Log("Closed by press");
                obj_Door.GetComponent<DoorBehaviour>().CanUseKnob = false;

            }

            if (Input.GetKeyUp("e") && obj_Door.GetComponent<DoorBehaviour>().IsOpen == false)
            {
                if (CanUnlock == true)
                {
                    obj_Door.GetComponent<Animator>().SetTrigger("Unlock");
                    obj_Door.GetComponent<DoorBehaviour>().Locked = false;
                }
                if (UnlockWithWrench == true)
                { 
                    obj_Door.GetComponent<Animator>().SetTrigger("UnlockWithWrench");
                    gameObject.SetActive(false);
                 }
            }
            GetComponent<Animator>().SetBool("IsHoover", true);
        }
        
    }

    void OnTriggerExit (Collider Other)
    {
        if (Other.tag == "PlayerTrigger")
        {
            GetComponent<Animator>().SetBool("IsHoover", false);
        }
    }

  
}
