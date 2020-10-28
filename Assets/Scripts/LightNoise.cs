using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightNoise : MonoBehaviour
{
    public float MinInt = .5f, MaxInt = 1.5f, MinTime = .1f, MaxTime = 1f;

    Light lamp;

    private void Start()
    {
        lamp = GetComponent<Light>();
        StartCoroutine(Noise());
    }

    IEnumerator Noise()
    {
        while(true)
        {
            lamp.intensity = Random.Range(MinInt, MaxInt);
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }
    }
}
