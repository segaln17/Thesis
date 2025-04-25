using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class belltoll : MonoBehaviour
{
    public AudioSource ambientSFX;
    public AudioClip bellToll;
    public Color originalFog;
    public Color dinnerFog;
    public Color demonFog;

    [YarnCommand ("dinnerTime")]
    public void dinnerTimeChange()
    {
        ambientSFX.PlayOneShot(bellToll);
        RenderSettings.fogColor = dinnerFog;
    }

    [YarnCommand("demonTime")]
    public void demonFogChange()
    {
        ambientSFX.PlayOneShot(bellToll);
        RenderSettings.fogColor = demonFog;
    }

    [YarnCommand("resetFog")]
    public void resetFog()
    {
        ambientSFX.PlayOneShot(bellToll);
        RenderSettings.fogColor = originalFog;
    }
}
