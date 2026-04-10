using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        Transform target;
        public float lerpSpeed = 1.0f;
        private Vector3 offset;
        private Vector3 targetPos;
        private void Awake()
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        private void Start()
        {
            if (target == null) return;
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 10);

            offset = transform.position - target.position;
        }
        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
    }
}
