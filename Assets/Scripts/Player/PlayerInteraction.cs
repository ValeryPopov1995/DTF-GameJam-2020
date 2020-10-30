using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool Interacteble = true;
    public float MaxInteractDistance = 3f;
    public GameObject cursor;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        cursor.SetActive(false);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxInteractDistance))
        {
            InteractableObject obj = hit.transform.GetComponent<InteractableObject>();

            // cursor image

            // click obj
            if (obj != null && obj.isActive)
            {
                cursor.SetActive(true);

                if (Interacteble && Input.GetMouseButtonDown(0)  && !Cursor.visible) obj.Interact();
            }
        }
    }
}
