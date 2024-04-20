using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector3> InputMoveDirectionChanged = delegate { };

    private Input _inputActions;

    public Input Input => _inputActions ??= new Input();

    public void Enable()
    {
        Input.Enable();
    
        SetUpAccelerator();

        Input.Gameplay.Move.performed += ctx => OnMove(ctx);
        Input.Gameplay.KeyMove.performed += ctx => OnKeyMove(ctx);
        Input.Gameplay.Act.performed += ctx => OnAct(ctx);
    }

    public void Disable()
    {
        Input.Gameplay.Move.performed -= ctx => OnMove(ctx);
        Input.Gameplay.KeyMove.performed -= ctx => OnKeyMove(ctx);
        Input.Gameplay.Act.performed -= ctx => OnAct(ctx);

        Input.Disable();
    }

    private void SetUpAccelerator()
    {
        if (Accelerometer.current != null)
        {
            InputSystem.EnableDevice(Accelerometer.current);
            Debug.Log("<color=black>Accelerometer FOUND </color>");
        }else 
            Debug.Log("Accelerometer not found!");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        InputMoveDirectionChanged?.Invoke(context.ReadValue<Vector3>());
    }

    private void OnAct(InputAction.CallbackContext context)
    {
        SetUpAccelerator();
    }

    private void OnKeyMove(InputAction.CallbackContext context)
    {
        InputMoveDirectionChanged?.Invoke(context.ReadValue<Vector3>());
    }
}
