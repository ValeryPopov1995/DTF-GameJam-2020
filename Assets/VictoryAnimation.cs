using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAnimation : MonoBehaviour
{
    static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void AnimateVictory()
    {
        anim.SetTrigger("victory");
    }
}
