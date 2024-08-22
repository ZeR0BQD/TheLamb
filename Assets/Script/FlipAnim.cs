using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipAnim : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    private Vector3 startPos;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (currentPos.x < startPos.x)
        {
            Flip(false);
        }
        else if (currentPos.x > startPos.x)
        {
            Flip(true);
        }
        startPos = currentPos;
    }

    void Flip(bool flip)
    {
        sprite.flipX = flip;
    }
}
