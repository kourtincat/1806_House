using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlareBehaviour : MonoBehaviour {
    

    public float Intense;
    public float Mid;
    public float Low;
    private float Zero;

	// Use this for initialization
	void Start () {

        Zero = 0;

	}
	
	// Update is called once per frame
	void Update () {

        //Intense Set Up
        if (GetComponentInParent<Light>().range > 1.1)
        {
            GetComponent<LensFlare>().brightness = Intense;
        }
        else
        {
            //Mid Set Up
            if (GetComponentInParent<Light>().range > 0.9 && GetComponentInParent<Light>().range < 1.1)
            {
                GetComponent<LensFlare>().brightness = Mid;
            }
            else
            {
                //Low Set Up
                if (GetComponentInParent<Light>().range < 0.9 && GetComponentInParent<Light>().range > 0.4)
                {
                    GetComponent<LensFlare>().brightness = Low;
                }
                else
                {
                    //Zero Set Up
                    if (GetComponentInParent<Light>().range < 0.4)
                    {
                        GetComponent<LensFlare>().brightness = Zero;
                        
                    }
                }
            }
        }                          

	}
}
