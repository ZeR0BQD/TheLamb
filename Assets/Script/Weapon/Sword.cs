using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Transform player;
    public float damage, speedRotate;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.RotateAround(player.position, Vector3.back, speedRotate * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Enemy"))
        {
            collision2D.gameObject.GetComponent<Heal>().curretHeal -= damage;
        }
    }
}
