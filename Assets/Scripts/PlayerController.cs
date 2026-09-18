using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float currentSpeed;
    public float wolkSpeed;
    public float sprintSpeed;

    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private CinemachineCamera _CinemachineCamera;

    private Vector2 _move;
    private void Start()
    {
        currentSpeed = wolkSpeed;
    }
    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }
    private void Update()
    {
        Vector3 move = GetForward() * _move.y + GetRight() * _move.x;
        _CharacterController.Move(move * Time.deltaTime * currentSpeed);
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
        if(val.Get<float>() > 0.5f)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = wolkSpeed;
        }
    }
}
