using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAction : MonoBehaviour
{
    public bool DestroyAfterEnabled = true;
    public int Timer = 20;
    [Space]
    public bool SetDisabledAfterStart = false;

    private void Start()
    {
        if (SetDisabledAfterStart) gameObject.SetActive(false);
        if (DestroyAfterEnabled) Destroy(gameObject, Timer);
    }
}
