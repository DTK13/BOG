using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchFlame : MonoBehaviour
{
     public Light2D leftLight, rightLight;
     public float duration = .5f;
     public float lowerLimit = 11f;
     public float upperLimit = 13.06f;
     float intensityLowerLimit = 0.8f;
     float intensityUpperLimit = 1f;
     float shadowIntensityLowerLimit = .0f;
     float shadowIntensityUpperLimit = .707f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        leftLight.pointLightOuterRadius = Mathf.Lerp(lowerLimit, upperLimit, t);
        rightLight.pointLightOuterRadius = Mathf.Lerp(lowerLimit, upperLimit, t);
        leftLight.intensity = Mathf.Lerp(intensityLowerLimit, intensityUpperLimit, t);
        rightLight.intensity = Mathf.Lerp(intensityLowerLimit, intensityUpperLimit, t);
        leftLight.shadowIntensity = Mathf.Lerp(shadowIntensityLowerLimit, shadowIntensityUpperLimit, t);
        rightLight.shadowIntensity = Mathf.Lerp(shadowIntensityLowerLimit, shadowIntensityUpperLimit, t);
        //leftLight.pointLightInnerAngle = Mathf.Lerp(innerAngleLowerLimit, innerAngleUpperLimit, t);
        //rightLight.pointLightInnerAngle = Mathf.Lerp(innerAngleLowerLimit, innerAngleUpperLimit, t);
        //leftLight.color = Color.Lerp(color0, color1, t);
        //rightLight.color = Color.Lerp(color0, color1, t);
    }
}
