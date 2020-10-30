using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator CameraAnimator;
    public GameObject Poleno;

    private void Update()
    {
        float magnitude = new Vector2(0, Input.GetAxis("Vertical")).magnitude;
        if (Cursor.visible) magnitude = 0;
        CameraAnimator.SetFloat("CameraState", magnitude);
    }

    public void GetPoleno(bool get)
    {
        Poleno.SetActive(get);
    }
}
