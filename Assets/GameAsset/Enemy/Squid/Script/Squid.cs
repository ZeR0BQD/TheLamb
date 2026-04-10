using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Squid : MonoBehaviour
{
    public Animator animator;
    Heal heal;
    TakeDmgEffect takeDmgEffect;
    public bool isAttack, attackState = false;
    public Transform playerTransform;
    //attackState để bắt đầu hoạt ảnh tấn công, isAttack dùng để control hoạt cảnh (dừng hoạt ảnh tại frame nhất định)
    public float speed, distanceAttackTarget;
    void Start()
    {
        heal = GetComponent<Heal>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        takeDmgEffect = GetComponent<TakeDmgEffect>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (heal.curretHeal <= 0) Destroy(gameObject);
        if (heal.curretHeal < heal.checkHeal)
        {
            takeDmgEffect.Using();
            heal.updateHeal();
        }

        //Animator
        animator.SetBool("attackState", attackState);
    }

    public void setAttack(int a)
    {
        isAttack = a == 1 ? true : false;
    }
}
