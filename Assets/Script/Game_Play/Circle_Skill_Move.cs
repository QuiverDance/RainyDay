using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Circle_Skill_Move : MonoBehaviour
{
    public float count;

    private Animator animator;
    private CircleCollider2D circleCollider2D;
    void Awake()
    {
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Run();
    }

    private void Run()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= count)
        {
            circleCollider2D.enabled = false;
        }
    }
}
