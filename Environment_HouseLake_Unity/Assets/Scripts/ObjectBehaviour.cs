using UnityEngine;
using System.Collections;

public class ObjectBehaviour : MonoBehaviour
{
    
    

    [Header("Object Configuration")]
   
    public GameObject obj_DoorTrigger;
    public GameObject obj_Pick;
    public GameObject obj_Pick_Trigger;

    bool PickerTrigger;
    public bool ObjectPicked;
    // Use this for initialization
    void Start()
    {
        obj_DoorTrigger.GetComponentInChildren<SpriteRenderer>().sprite = obj_DoorTrigger.GetComponent<DoorTriggersBehaviour>().UI_Bubble_Interact;
    }

    // Update is called once per frame
    void Update()
    {
        
    if (PickerTrigger == true && Input.GetKeyDown("e"))
        {
            obj_Pick.SetActive(false);
            ObjectPicked = true;
            obj_DoorTrigger.GetComponent<DoorTriggersBehaviour>().UnlockWithWrench = true;
            obj_Pick_Trigger.SetActive(false);
            



        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ToPickUp")
        {
            obj_Pick_Trigger.GetComponent<Animator>().SetBool("IsHoover", true);
            PickerTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ToPickUp")
        {
            obj_Pick_Trigger.GetComponent<Animator>().SetBool("IsHoover", false);
            PickerTrigger = false;
        }
    }



}
