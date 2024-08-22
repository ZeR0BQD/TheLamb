using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgEffect : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    void Start (){
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Using(){
        StartCoroutine(FlashColor());
    }
    IEnumerator FlashColor()
    {
        for (int i = 0; i < 3; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
