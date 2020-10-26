using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Mode ChooseMode;
    public enum Mode {animation, disable, switchMode}
    public GameObject Object;

    public void Interact()
    {
        switch (ChooseMode)
        {
            case Mode.animation:
                GetComponent<Animator>().SetTrigger("interaction");
                break;
            case Mode.disable:
                Object.SetActive(false);
                break;
            case Mode.switchMode:
                Object.SetActive(!Object.activeSelf);
                break;
            default:
                break;
        }

        AudioSource source = GetComponent<AudioSource>();
        if (source != null) source.Play();
    }
}
