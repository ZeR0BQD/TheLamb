using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    SpriteRenderer SR_Ghost;
    void Start()
    {
        SR_Ghost = GetComponent<SpriteRenderer>();
        SR_Ghost.sprite = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sprite;
        SR_Ghost.sortingOrder = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().sortingOrder;
    }
    void Update()
    {
        if(SR_Ghost.color.a  <=  0.01f) Destroy(this.gameObject);
    }
}
