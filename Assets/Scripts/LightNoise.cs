using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightNoise : MonoBehaviour
{
    public float ConstValue = 1f, SpeedFade = .9f, AddInt = .5f, MinTime = .1f, MaxTime = 1f;
    [Space]
    public ParticleSystem FireParticles;

    Light lamp;

    private void Start()
    {
        lamp = GetComponent<Light>();
        StartCoroutine(Noise());
    }

    private void Update()
    {
        if (ConstValue > .1f)
        {
            var em = FireParticles.emission;
            ConstValue -= Time.deltaTime * SpeedFade;
            em.rateOverTime = ConstValue * 10;
        }
    }

    IEnumerator Noise()
    {
        while(true)
        {
            lamp.intensity = Random.Range(0, AddInt) + ConstValue;
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        }
    }
}
