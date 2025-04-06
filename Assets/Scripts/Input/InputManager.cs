using UnityEngine;

/// <summary>
/// One instance of the InputManager
/// </summary>
public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private Controls _controlsAction;

    private Handling _handling;

    public static InputManager Instance
    {
        get { return _instance; }
    }

    public Handling Handling
    {
        get { return _handling; }
        set { _handling = value; }
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
        float leftRightValue = 0;
        switch (_handling)
        {
            case Handling.AD:
                leftRightValue = _controlsAction.Gameplay.AD.ReadValue<float>();
                break;
            case Handling.QE:
                leftRightValue = _controlsAction.Gameplay.QE.ReadValue<float>();
                break;
            case Handling.ZC:
                leftRightValue = _controlsAction.Gameplay.ZC.ReadValue<float>();
                break;
            case Handling.OneThree:
                leftRightValue = _controlsAction.Gameplay._13.ReadValue<float>();
                break;
            default:
                leftRightValue = 0;
                break;
        }
        return leftRightValue;
    }
}