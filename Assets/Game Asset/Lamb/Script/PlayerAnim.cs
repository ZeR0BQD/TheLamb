using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        animator.SetFloat("Speed", playerMovement.move.magnitude);
    }
}
