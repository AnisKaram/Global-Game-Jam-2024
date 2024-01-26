using UnityEngine;

/// <summary>
/// One instance of the InputManager
/// </summary>
public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private Controls _controlsAction;

    public static InputManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _controlsAction = new Controls();
    }

    private void OnEnable()
    {
        _controlsAction.Enable();
    }

    private void OnDisable()
    {
        _controlsAction.Disable();
    }

    public float GetPlayerMovement()
    {
        return _controlsAction.FirstBinding.AD.ReadValue<float>();
    }
}