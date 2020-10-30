using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public bool isActive = true;
    public Mode ChooseMode;
    public bool DisableAfter = false; // object will not interact
    public bool PlayAudio = true; // if one audio clip in audio source
    public enum Mode {animation, disable, activateRainTask, switchMode, net, startNetTask, garbage, none, polenya, kamin, korzina, fonarik}
    [Space]
    [Tooltip("for interaction (switch for example)")]
    public GameObject Object;
    [Space]
    public float WaitForSpeach = 0f;
    public AudioClip PlayerSpeach;
    public AudioClip[] AudioArray; // one by one

    StoryVoids story;

    private void Start()
    {
        story = FindObjectOfType<StoryVoids>();
    }

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

            case Mode.net:
                story.AddFoundedNet();
                gameObject.SetActive(false);
                break;

            case Mode.startNetTask:
                story.TaskText.text = "проверил? молодец. а теперь стоит собрать везде пыль";
                foreach (var item in story.Nets) item.isActive = true;
                Object.SetActive(false);
                isActive = false;
                break;

            case Mode.garbage:
                story.AddFoundedGarnage();
                gameObject.SetActive(false);
                break;

            case Mode.polenya:
                FindObjectOfType<CameraAnimation>().Poleno.SetActive(true);
                break;

            case Mode.kamin:
                var pol = FindObjectOfType<CameraAnimation>().Poleno;
                var fire = FindObjectOfType<LightNoise>();
                if (pol.activeSelf)
                {
                    fire.ConstValue++;
                    fire.ConstValue = Mathf.Clamp(fire.ConstValue, 0, 2.5f);
                    pol.SetActive(false);
                }
                break;

            case Mode.korzina:
                story.StartWeatherTask();
                Object.SetActive(true);
                isActive = false;
                break;

            case Mode.activateRainTask:
                Object.SetActive(true);
                break;

            case Mode.fonarik:
                Object.SetActive(true);
                gameObject.SetActive(false);
                break;

            default:
                break;
        }

        AudioSource source = GetComponent<AudioSource>();
        if (source != null && PlayAudio) source.Play();
        else if (source != null && AudioArray.Length != 0) StartCoroutine(PlayAudioArray());
        if (DisableAfter) this.enabled = false;

        if (PlayerSpeach != null) StartCoroutine(PlaySpeach(WaitForSpeach));
    }

    IEnumerator PlayAudioArray()
    {
        isActive = false;
        var source = GetComponent<AudioSource>();
        for (int i = 0; i < AudioArray.Length; i++)
        {
            source.clip = AudioArray[i];
            source.Play();
            yield return new WaitForSeconds(AudioArray[i].length);
        }
    }
    IEnumerator PlaySpeach(float delay)
    {
        yield return new WaitForSeconds(delay);
        var speach = FindObjectOfType<PlayerMovenment>().GetComponent<AudioSource>();
        speach.clip = PlayerSpeach;
        speach.Play();
    }

    void WindowAnimationEvent()
    {
        StoryVoids.WindowClosed++;
        if (StoryVoids.WindowClosed == 5) story.StartStorm();
    }
}
