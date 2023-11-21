using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 0.0f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 1f;

    private Light spotlight;
    private float targetIntensity;

    void Start()
    {
        spotlight = GetComponent<Light>();
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float currentIntensity = spotlight.intensity;
            float newIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * flickerSpeed);
            spotlight.intensity = newIntensity;

            if (Mathf.Approximately(currentIntensity, newIntensity))
            {
                targetIntensity = Random.Range(minIntensity, maxIntensity);
            }

            yield return null;
        }
    }
}
