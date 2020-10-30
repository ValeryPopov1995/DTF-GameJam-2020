using UnityEngine;
using UnityEngine.UI;

public class StoryVoids : MonoBehaviour
{
    public Text TaskText;
    public InteractableObject[] Nets, Garbage;
    public GameObject TVEnterTrigger, TVWeatherNews, Groza;
    public InteractableObject Korzina, Fonarik;

    public static int NetFounded = 0, GarbageFounded = 0, WindowClosed = 0, killed = 0;
    [Space]
    public AudioClip net;
    public AudioClip fonarikClip, garbageSpeach;

    AudioSource so;

    private void Start()
    {
        so = GetComponent<AudioSource>();
    }

    public void AddFoundedNet()
    {
        NetFounded++;
        TaskText.text = "Еще осталась где-то паутина!";
        Debug.Log(NetFounded + " nets founded");
        eff(net);

        if (NetFounded == Nets.Length) // start garbage
        {
            foreach (var item in Garbage) item.isActive = true;
            TaskText.text = "пора собрать все вещи, которые воляются по квартире";

            var speach = FindObjectOfType<PlayerMovenment>().GetComponent<AudioSource>();
            speach.clip = garbageSpeach;
            speach.Play();

            if (TVEnterTrigger != null) TVEnterTrigger.SetActive(true);
            FindObjectOfType<SunBaheviour>().SunAngle = 50;
        }
    }

    public void AddFoundedGarnage()
    {
        GarbageFounded++;
        TaskText.text = "Где-то лежит футболка и смотрит на тебя, грязная!";
        Debug.Log(GarbageFounded + " dress founded");

        if (GarbageFounded == Garbage.Length) // next mission - close windows
        {
            TaskText.text = "Сложить все подобранные вещички в корзину";
            Korzina.isActive = true;
            FindObjectOfType<SunBaheviour>().SunAngle = 30;
        }
    }

    public void StartWeatherTask()
    {
        if (TVWeatherNews != null) TVWeatherNews.SetActive(true);
        TaskText.text = "Включи телек, глянь что по погоде. Все равно никуда не пойдешь, Хех";
    }

    public void StartStorm()
    {
        FindObjectOfType<SunBaheviour>().SunAngle = 0;
        if (Groza != null) Groza.SetActive(true);
        Fonarik.isActive = true;
    }

    public void eff(AudioClip clip)
    {
        so.clip = clip;
        so.Play();
    }
}
