using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator CameraAnimator;

    private void Update()
    {
        float magnitude = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude;
        CameraAnimator.SetFloat("CameraState", magnitude);
    }
}
