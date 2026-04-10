using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float maxHeal;
    public float curretHeal;
    [HideInInspector] public float checkHeal;
    void Start()
    {
        curretHeal = maxHeal;
        checkHeal = maxHeal;
    }

    public void updateHeal()
    {
        checkHeal = curretHeal;
    }
}
