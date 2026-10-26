using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Movement tuning (editable in Inspector
    public float speed = 5.0f;
    public float turnSpeed;

    // Input System action exposed in Inspector for binding (WASD ? Arrow Keys)
    public InputAction moveAction;

    //Current input value (x = left/right, y = forward/backward) , kept private for internal use
    public Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read Vector2 input from the MoveAction (x = left/right, y = forward/backward)
        moveInput = moveAction.ReadValue<Vector2>();

        // We'll move the vehicle forward / backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // We'll move the vehicle left / right
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed *moveInput.x);
 
    }
}
