using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public GameObject DeathText;
    public float Health = 1, RegenSpeed = 1f;

    public AudioClip PobedClip, GdeFonarik;

    void Update()
    {
        if (Health < 100 && Health > 0)
        {
            Health += RegenSpeed * Time.deltaTime;
            anim.SetFloat("Blend", Health);
        }
    }

    public void Damage(float damage)
    {
        Health -= damage;
        Debug.Log(Health);
        if (Health < 0) StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        DeathText.SetActive(true);
        GetComponent<PlayerMovenment>().enabled = false;
        GetComponent<PlayerInteraction>().enabled = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    public void SpeachPlay(AudioClip clip) // у меня уже голова не варит. так конечно не должно быть.
    {
        var s = GetComponent<AudioSource>();
        s.clip = clip;
        s.Play();
    }
}
