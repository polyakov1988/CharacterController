using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistance;

    private Vector3 _direction;

    private void FixedUpdate()
    {
        _direction = (_target.position - _rigidbody.position).normalized;
        
        if (Vector3.Distance(_target.position, _rigidbody.position) > _minDistance)
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
        }
        
        _rigidbody.MoveRotation(Quaternion.Euler(
            _rigidbody.rotation.x, 
            Quaternion.LookRotation(_direction).eulerAngles.y, 
            _rigidbody.rotation.z));
    }
}