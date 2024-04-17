using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector3> MoveAction = delegate { };

    private Input _inputActions;

    public Input Input => _inputActions ??= new Input();

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("Acceleration " + context.ReadValue<Vector3>());
        MoveAction?.Invoke(context.ReadValue<Vector3>());
    }

    void Start()
    {
        Input.Enable();

        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            Debug.Log("<color=black>Accelerometer FOUND </color>");
        }else 
            Debug.Log("Accelerometer not found!");
            
        Input.Gameplay.Move.performed += ctx => OnMove(ctx);
    }
}
