using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject MainMenuObject;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButton("Cancel") && !MainMenuObject.activeSelf)
        {
            MainMenuObject.SetActive(true);
            CursorVisible(true);
        }
    }

    public void CursorVisible(bool isVisible)
    {
        Cursor.visible = isVisible;
        if (isVisible) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoLink(string url)
    {
        Application.OpenURL(url);
    }
}
