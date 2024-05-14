using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private void Update()
    {
        Vector3 playerInput = new (Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
        float deltaSpeed =  Time.deltaTime * _speed;

        if (_characterController.isGrounded)
        {
            _characterController.Move(playerInput * deltaSpeed + Vector3.down);
        }
        else
        {
            _characterController.Move(Vector3.down * deltaSpeed);
        }
    }
}