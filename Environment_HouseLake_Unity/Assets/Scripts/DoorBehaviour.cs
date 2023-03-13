using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

    public bool Locked;
  
    public bool IsOpen;
    public bool CanUseKnob;

    //AudioSourceSetUp
    AudioSource doorSound;

    public GameObject LockGood;
    public GameObject LockBad;
    public GameObject PS_break;
    
    [Header("GameObjects")]
    public GameObject obj_UIEvent1;
    public GameObject obj_UIEvent2;

    [Header("Sounds")]
    public AudioClip aud_Open;
    public AudioClip aud_Closed;
    public AudioClip aud_Locked;

    [Header("Technical")]
    public Animator animator;
    public AnimatorStateInfo animatorInfo;
    //[Header("Objecs")]   
    //public GameObject Collider1;
    //public GameObject Collider2;



    // Use this for initialization
    void Start() {

        IsOpen = false;

        if (Locked == true)

        {
            GetComponent<Animator>().SetBool("IsLocked", true);
            
        }
        else
        {
            GetComponent<Animator>().SetBool("IsLocked", false);
        }
        doorSound = GetComponent<AudioSource>();
     }


    void Update()
    {
        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorInfo.IsTag("Opened"))
        {
            IsOpen = true;
            
        }
        else
            IsOpen = false;

        animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorInfo.IsTag("Unlock"))
        {
            Locked = false;
            GetComponent<Animator>().SetBool("IsLocked", false);
            obj_UIEvent1.GetComponent<DoorTriggersBehaviour>().CanUnlock = false;
            obj_UIEvent2.GetComponent<DoorTriggersBehaviour>().CanUnlock = false;
            LockGood.SetActive(true);
            LockBad.SetActive(false);

        }
        

        if (animatorInfo.IsTag("Idle") || animatorInfo.IsTag("Opened"))
        {
            CanUseKnob = true;
            
        }
        else
            CanUseKnob = false;

    }

    void OnTriggerExit (Collider other)
    {

        if (other.tag == "Player")
        {

            GetComponent<Animator>().SetTrigger("Close");
            Debug.Log("Closed by trigger");
            IsOpen = false;
            SoundClose();
            
        }

    }

    void FadeOut()
    {
        obj_UIEvent1.GetComponent<Animator>().SetBool("IsHoover", false);
        obj_UIEvent2.GetComponent<Animator>().SetBool("IsHoover", false);
    }

    void CanUseKnobSwitcher()
    {
        CanUseKnob = !CanUseKnob;
    }



    public void SoundOpen()
    {
        if (Locked == true)
        {
            doorSound.clip = aud_Locked;
            doorSound.Play();
        }
        else
        {
            doorSound.clip = aud_Open;
            doorSound.Play();
        }
            
    }
   public void SoundClose()
    {
        doorSound.clip = aud_Closed;
        doorSound.Play();
    }

    void InvokeParticle()
    {
        PS_break.SetActive(true);
    }
}
