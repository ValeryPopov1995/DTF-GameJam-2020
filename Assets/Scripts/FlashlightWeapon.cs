using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightWeapon : MonoBehaviour
{
    public float DeathAngle = 15, Distance = 3f;

    private void Update()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, Distance);
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>() != null)
            {
                Vector3 target = enemy.transform.position - Camera.main.transform.position;
                float angle = Vector3.Angle(target, Camera.main.transform.forward);
                if (angle < DeathAngle) enemy.GetComponent<Enemy>().Death();
            }
        }
    }
}
