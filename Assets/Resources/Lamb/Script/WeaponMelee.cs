using System;
using System.Collections;
using UnityEngine;

public class weaponMelee : MonoBehaviour
{
    public GameObject weaponPrefab;
    GameObject weapon;
    Player player;
    public float radius = 2.5f; // Bán kính của cung tròn
    public float speed; // Tốc độ di chuyển dọc theo cung

    private float currentAngle; // Góc hiện tại 
    private float startAngle = Mathf.PI / 2; // Góc bắt đầu 
    private float endAngle = 3 * Mathf.PI / 2; // Góc kết thúc 
    public float direc; //Hướng vũ khí
    private bool movingToPoint = true, isAttack = false; // Cờ để xác định hướng di chuyển

    void Start()
    {
        player = GetComponent<Player>();
        weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        weapon.transform.SetParent(transform);
        currentAngle = startAngle;
    }

    void Update()
    {
        // Di chuyển đối tượng dọc theo cung tròn
        if (movingToPoint && isAttack)
        {
            currentAngle = Mathf.Lerp(currentAngle, endAngle, Time.deltaTime * speed);
            if (Mathf.Abs(currentAngle - endAngle) < 0.1f)
            {
                movingToPoint = false;
                isAttack = false;
            }
        }
        else if (!movingToPoint && isAttack)
        {
            currentAngle = Mathf.Lerp(currentAngle, startAngle, Time.deltaTime * speed);
            if (Mathf.Abs(currentAngle - startAngle) < 0.1f)
            {
                movingToPoint = true;
                isAttack = false;
            }
        }

        // Tính toán vị trí mới trên cung di chuyển
        direc = player.move.x > 0 ? -1 : 1; // xác định hướng của weapon dựa vào hướng player
        Vector3 offset = new Vector3(Mathf.Cos(currentAngle) * direc, Mathf.Sin(currentAngle), 0) * radius;
        weapon.transform.position = transform.position + offset; // Cập nhật vị trí của đối tượng

        // Tính toán góc quay 
        Vector3 direction = transform.position - weapon.transform.position;
        float rotate = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0, 0, rotate);
    }

    public void attackMelee()
    {
        if (isAttack == false) isAttack = true;
    }
}