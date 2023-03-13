using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//THIS SCRIPT IS FOR THE SWITCH; TRIGGERS LIGHTS ON/OFF
public class LightBehaviour : MonoBehaviour {

    [Header("GameObject Configuration")]
    private bool Triggered;
    public bool LightsAreOn;
    public bool RefreshesReflectionProbe;
   // public bool BrokenSwitch;

    [Header("AudioClips")]
    AudioSource switchSound;
  
    //Obj With Mat Swap in this script is deprecated due to transfer of responsabilities to LightTypeObject, whose light and material management depends on it.
    
    public GameObject[] obj_LightsToBeOn;

    [Header("UI Settings")]
    public GameObject obj_UIBubble;


    [Header("IsManagingMaterials")]
    [Tooltip("This bool should be activated if LightTypeObject is NOT assigned into the light")]
    public bool IsManagingMaterials;
    

    public GameObject[] obj_ObjWithMatSwap;
    public Material mat_LightsOn;
    public Material mat_LightsOff;

    // Use this for initialization
    void Start () {
        


        

       // LightsAreOn = false;
        if (LightsAreOn == false)
        {
            foreach (GameObject _light in obj_LightsToBeOn)
            {
                _light.SetActive(false);
            }
            if (IsManagingMaterials == true)
            {
                foreach (GameObject _obj in obj_ObjWithMatSwap)
                {
                    _obj.GetComponent<MeshRenderer>().material = mat_LightsOff;
                }
            }
            
        }

        if (LightsAreOn == true)
        {
            foreach (GameObject _light in obj_LightsToBeOn)
            {
                _light.SetActive(true);

            }
            if (IsManagingMaterials == true)
            {
                foreach (GameObject _obj in obj_ObjWithMatSwap)
                {
                    _obj.GetComponent<MeshRenderer>().material = mat_LightsOn;
                }
            }
        }

        switchSound = GetComponent<AudioSource>();
        

    }

    void OnTriggerEnter (Collider other)
    {
        
        
            GetComponent<Animator>().SetBool("IsHoover", true);
            Triggered = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        
        
            Triggered = false;
            GetComponent<Animator>().SetBool("IsHoover", false);
        
    }

    void Update()
    {

       
        
        if (Input.GetKeyUp("e") && Triggered == true)
        {
            print("f input ok, light switch");
            LightsAreOn = !LightsAreOn;
            switchSound.Play();
            if (RefreshesReflectionProbe == true)
            {
                GetComponent<RefreshReflection>().Refresh();
            }
            

        }

        if (LightsAreOn == false)
        {
            foreach (GameObject _light in obj_LightsToBeOn)
            {
                _light.SetActive(false);
            }
            if (IsManagingMaterials == true)
            {
                foreach (GameObject _obj in obj_ObjWithMatSwap)
                {
                    _obj.GetComponent<MeshRenderer>().material = mat_LightsOff;
                }
            }


        }

        if (LightsAreOn == true)
        {
            foreach (GameObject _light in obj_LightsToBeOn)
            {
                _light.SetActive(true);
                              
            }
            if (IsManagingMaterials == true)
            {
                foreach (GameObject _obj in obj_ObjWithMatSwap)
                {
                    _obj.GetComponent<MeshRenderer>().material = mat_LightsOn;
                }
            }
        }
        
        
       

    }
   
}
