using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquid : MonoBehaviour
{
    public GameObject squidObj;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // squidObj = Resources.Load<GameObject>("Enemy/Squid/Squid");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3f)
        {
            Instantiate(squidObj, GetRandomPoint(16f), Quaternion.identity);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    Vector3 GetRandomPoint(float r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float x = r * Mathf.Cos(angle);
        float y = r * Mathf.Sin(angle);
        return new Vector3(x, y, 0f) + GameObject.FindWithTag("Player").transform.position;
    }
}
