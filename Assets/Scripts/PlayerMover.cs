using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _playerInput;
    private float _deltaSpeed;
    private float _lookAngle;

    private void Update()
    {
        _deltaSpeed =  Time.deltaTime * _speed;

        if (_characterController.isGrounded)
        {
            _playerInput = new (Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
            
            _characterController.Move(_playerInput * _deltaSpeed + Vector3.down);
            
            _lookAngle = Mathf.Atan2(_playerInput.x, _playerInput.z) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0, _lookAngle, 0);
        }
        else
        {
            _characterController.Move(Vector3.down * _deltaSpeed);
        }
    }
}