
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float lerpSpeed = 1.0f;
    private Transform _target;
    private Vector3 _cachePosition;

    [Tooltip("Khoảng cách từ camera đến target theo trục Z")]
    [SerializeField] private float _offsetZ;

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (_target == null) return;

        _cachePosition = _target.position;
        _cachePosition.z -= _offsetZ;

        transform.position = Vector3.Lerp(transform.position, _cachePosition, lerpSpeed * Time.deltaTime);
    }
}

