using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public bool CantTurnAround = false;
    public Transform LookRay;
    [Space]
    public bool DisableAfterTriggering = true;
    public GameObject[] DisableObjs, ActivateObjs, AnimateObjects; // animator must have

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovenment>() != null && TurnAround())
        {
            if (DisableObjs.Length > 0) foreach (var obj in DisableObjs) obj.SetActive(false);

            if (ActivateObjs.Length > 0) foreach (var obj in ActivateObjs) obj.SetActive(true);

            if (ActivateObjs.Length > 0) foreach (var obj in AnimateObjects) obj.GetComponentInChildren<Animator>().SetTrigger("event"); // for windows

            if (DisableAfterTriggering) gameObject.SetActive(false);
        }
    }

    bool TurnAround()
    {
        if (!CantTurnAround) return true;
        else
        {
            Transform cam = Camera.main.transform;
            // 40 degree
            float angle = Vector3.Angle(LookRay.forward, cam.forward);
            Debug.Log(angle);
            if (angle < 40f) return true;
            else return false;
        }
    }
}
