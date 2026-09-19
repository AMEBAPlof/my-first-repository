using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float currentSpeed;
    public float wolkSpeed;
    public float sprintSpeed;

    [Header("Gravity & Jump")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundedStickForce = -2f;
    [SerializeField] private float jumpHeight = 1.5f;

    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private CinemachineCamera _CinemachineCamera;

    private Vector2 _move;
    private float _verticalVelocity;

    private void Start()
    {
        currentSpeed = wolkSpeed;
    }

    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }

    private void OnJump(InputValue val)
    {
        if (val.isPressed && _CharacterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Update()
    {
        // Горизонтальное движение
        Vector3 move = GetForward() * _move.y + GetRight() * _move.x;
        Vector3 horizontal = move * currentSpeed;

        // Гравитация
        if (_CharacterController.isGrounded && _verticalVelocity < 0f)
        {
            _verticalVelocity = groundedStickForce;
        }
        _verticalVelocity += gravity * Time.deltaTime;

        // Один вызов Move для всего движения
        Vector3 velocity = horizontal + Vector3.up * _verticalVelocity;
        _CharacterController.Move(velocity * Time.deltaTime);
    }

    private Vector3 GetForward()
    {
        Vector3 forward = _CinemachineCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetRight()
    {
        Vector3 right = _CinemachineCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void OnSprint(InputValue val)
    {
        currentSpeed = val.Get<float>() > 0.5f ? sprintSpeed : wolkSpeed;
    }
     
}