using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Skill_Move : MonoBehaviour
{
    public float count;

    private Animator animator;
    private BoxCollider2D boxCollider2D;
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
    }

    private void Run()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= count)
        {
            boxCollider2D.enabled = false;
        }
    }
}
