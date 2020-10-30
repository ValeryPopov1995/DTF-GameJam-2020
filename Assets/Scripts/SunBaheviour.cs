using UnityEngine;

public class SunBaheviour : MonoBehaviour
{
    public int SunAngle = 70;

    Light lig;

    private void Start()
    {
        lig = GetComponent<Light>();
    }

    private void Update()
    {
        if (transform.localEulerAngles.x > SunAngle)
        {
            transform.Rotate(transform.right, -1 * Time.deltaTime);
            lig.intensity = transform.localEulerAngles.x / 70 * .5f; // .5f max
        }
    }
}
