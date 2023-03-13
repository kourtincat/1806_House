using UnityEngine;
using System.Collections;

public class RefreshReflection : MonoBehaviour
{
    public ReflectionProbe ProbeTarget;
    RenderTexture targetTexture;

    // Use this for initialization
    

    // Update is called once per frame
    public void Refresh()
    {
        ProbeTarget.RenderProbe(targetTexture = null);

    }
   

    
}
