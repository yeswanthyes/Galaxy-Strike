using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float Clampx = 10f;
    [SerializeField] private float Clampy = 10f;
    [SerializeField] private float ControlRollFactor = 5f;
    [SerializeField] private float RotateSpeed = 5f;
    [SerializeField] private float ControlPitchFactor = 10f;
    Vector2 moveInput;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerMovement();
        Rotation();
    }

    private void PlayerMovement()
    {
        float moveX = moveInput.x * moveSpeed * Time.deltaTime;
        float moveY = moveInput.y * moveSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(
            Mathf.Clamp(moveX + transform.localPosition.x, -Clampx, Clampx),
            Mathf.Clamp(moveY + transform.localPosition.y, -Clampy, Clampy),
            0f
        );
    }
void Rotation()
    {
        float pitch = -ControlPitchFactor * moveInput.y;
        float roll = -ControlRollFactor * moveInput.x;  
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, RotateSpeed * Time.deltaTime);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
