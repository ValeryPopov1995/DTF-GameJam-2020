using UnityEngine;

public class StormBaheviour : MonoBehaviour
{
    AudioSource s;

    private void Start()
    {
        s = GetComponent<AudioSource>();
    }
    void GrozaSoundEffectPlay()
    {
        s.Play();
    }
}
