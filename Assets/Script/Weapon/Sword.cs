using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Player player;
    public float damage;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        float angle = Mathf.Atan2(player.move.y, player.move.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = player.transform.position - new Vector3(0f, 0.6f, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Enemy"))
        {
            collision2D.gameObject.GetComponent<Heal>().curretHeal -= damage;
        }
    }
}
