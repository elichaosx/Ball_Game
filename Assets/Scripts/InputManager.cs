using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public event Action<bool> OnTapEvent;
    public event Action<Vector2> OnContinousEvent;

    private bool _isTouching = false;

    private void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

    }


    //CLICKER
    public void OnTap(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isTouching = true;
            OnTapEvent?.Invoke(true);
            Debug.Log("Touch started");
        }
        else if (context.canceled)
        {
            _isTouching = false;
            OnTapEvent?.Invoke(false);
            Debug.Log("Touch ended");
        }
    }

    //MANTENER DEDO
    public void OnContinous(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        Debug.Log($"Touch position: {value}");
        OnContinousEvent?.Invoke(value);
    }
}
