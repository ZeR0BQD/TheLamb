using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rig2D;
    void Start()
    {
        animator = GetComponent<Animator>();
        rig2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        animator.SetFloat("Speed", rig2D.velocity.magnitude);
    }
}
