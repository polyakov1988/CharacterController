using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistance;

    private void FixedUpdate()
    {
        Vector3 direction = (_target.position - _rigidbody.position).normalized;
        
        if (Vector3.Distance(_target.position, _rigidbody.position) > _minDistance)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
        }
    }
}
