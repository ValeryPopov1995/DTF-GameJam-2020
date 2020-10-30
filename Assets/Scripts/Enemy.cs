using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Damage = 10f, DistanceToShoot = 3f, DistanceToStartAttack = 2f;

    NavMeshAgent agent;
    PlayerHealth hp;
    Animator anim;

    bool desteny = true, killed = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hp = FindObjectOfType<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    public void ShootAnimEvent()
    {
        float dis = Vector3.Distance(transform.position, hp.transform.position);
        if (dis < DistanceToShoot) hp.Damage(Damage);
    }

    private void Update()
    {
        float dis = Vector3.Distance(transform.position, hp.transform.position);
        if (dis < DistanceToStartAttack) anim.SetTrigger("shoot");
        else if (desteny) agent.SetDestination(hp.transform.position);
        else agent.isStopped = true;
    }

    public void Death()
    {
        if (!killed)
        {
            killed = true;

            desteny = false;
            anim.SetTrigger("death");
            StoryVoids.killed++;
            if (StoryVoids.killed == 5)
            {
                FindObjectOfType<PlayerHealth>().SpeachPlay(FindObjectOfType<PlayerHealth>().PobedClip);

                VictoryAnimation.AnimateVictory();

            }
            Destroy(gameObject, 5f);
        }
    }
}
