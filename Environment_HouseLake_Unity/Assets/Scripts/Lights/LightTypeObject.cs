using UnityEngine;
using System.Collections;




public class LightTypeObject : MonoBehaviour
{
    
    public ReflectionProbe ReflectionProbeTarget;
    RenderTexture targetTexture;


    [Header("LightIntensityFixer")]
    public Light[] AffectedLights;


    [Header("Light Type (Only One Selected)")]
          
    public bool Normal;
    public bool Blink1;
    public bool Blink2;
    public bool Broken;
    
   /* [Header("Flare Manager")]

    public Flare activeFlare;
    public Flare noneFlare;
    public Light lightTarget;
    */
    [Header("Sound Manager")]

    
    public AudioSource normalSound;
    public AudioSource normalSoundflicker;
    public AudioSource blink1Sound;
    public AudioSource blink2Sound;
    public AudioSource brokenSound;


    [Header("Mat Manager")]
    public GameObject obj_Light;

    public Material mat_LightsOn;
    public Material mat_LightsOff;

          
    void Start()
    {
                      
       

    }
    // Update is called once per frame
    void Update()
    {
        if (AffectedLights.Length > 0)
        {
            foreach (Light _light in AffectedLights)
            {
                if (_light.GetComponent<Light>().range < 0.12)
                {
                    _light.GetComponent<Light>().intensity = 0;
                }
                else
                {
                    _light.GetComponent<Light>().intensity = 1;
                }
            }
        }

        




        if (gameObject.activeInHierarchy)
        {
            if (Blink1 == true)
            {
                GetComponent<Animator>().SetTrigger("Blink1");
            }
            else
            {
                if (Blink2 == true)
                {
                    GetComponent<Animator>().SetTrigger("Blink2");
                }
                else
                {
                    if (Broken == true)
                    {
                        GetComponent<Animator>().SetTrigger("Broken");
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Normal");
                    }
                }
            }







        }
        else
        {
            normalSound.Stop();
            normalSoundflicker.Stop();
        }
    }

    void LightLitOn()
    {
        obj_Light.GetComponent<MeshRenderer>().material = mat_LightsOn;
        ReflectionProbeTarget.RenderProbe(targetTexture = null);
        //lightTarget.GetComponent<Light>().flare = activeFlare;

        if (Blink2 == true)
        {
            normalSoundflicker.Play();
        }
        else
        {
            normalSound.Play();
        }

        if (Random.Range (0, 1) <= 0.5)
        {
            blink1Sound.Play();
        }
        else
        {
            blink2Sound.Play();
        }
    }

    void LightLitOff()
    {
        obj_Light.GetComponent<MeshRenderer>().material = mat_LightsOff;
        ReflectionProbeTarget.RenderProbe(targetTexture = null);

        normalSound.Stop();
        normalSoundflicker.Stop();

      //  lightTarget.GetComponent<Light>().flare = noneFlare;

        if (Blink1 || Blink2)
        {
            if (Random.Range(0, 1) <= 0.5)
            {
                blink1Sound.Play();
            }
            else
            {
                blink2Sound.Play();
            }
        }
        else
        {
            brokenSound.Play();
        }
    }
}

