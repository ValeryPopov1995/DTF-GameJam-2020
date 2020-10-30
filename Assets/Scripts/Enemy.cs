using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Damage = 10f, DistanceToShoot = 3f, DistanceToStartAttack = 2f;

    NavMeshAgent agent;
    PlayerHealth hp;
    Animator anim;

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
        else agent.SetDestination(hp.transform.position);
    }
}
