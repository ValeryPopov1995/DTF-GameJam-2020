using UnityEngine;

public class StoryVoids : MonoBehaviour
{
    public GameObject Title;

    void SetActiveTitle(int value)
    {
        Title.SetActive(value == 1);
    }

    void PlayStory(AudioClip clip)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
    }
}
