using UnityEngine;

public class CarController : MonoBehaviour
{
    #region Fields
    [SerializeField, Tooltip("Maximum Steering Angle of the Wheels")]
    private static float _maxSteeringAngle = 50f;

    [SerializeField, Tooltip("Maximum Torque applied to the Driving Wheels (only)")]
    private static float _maxWheelTorque = 3500f;

    [SerializeField, Tooltip("Drag and Drop Wheel Shape")]
    private GameObject _wheelShape;

    [SerializeField, Tooltip("Vehicle's Speed when the engine can use different amount of sub-steps")]
    private float _criticalMaxEngineSpeed = 10f;

    [SerializeField, Tooltip("Sub-Steps when the Engine Speed is above Critical")]
    private int _criticalStepsAbove = 8;

    [SerializeField, Tooltip("Sub-Steps when the Engine Speed is below Critical")]
    private int _criticalStepsBelow = 5;

    [SerializeField, Tooltip("Drive Type of the Vehicle: AWD, FWD, RWD")]
    private DriveType _drivingType;

    private float _angle;
    private float _torque;
    private WheelCollider[] _wheelColliders;
    #endregion

    public float Torque
    {
        get { return _torque; }
        set { _torque = value; }
    }

    #region Unity Methods
    private void Awake()
    {
        // Get all WheelColliders as Children of the Parent car
        _wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    private void Start()
    {
        int wc_size = _wheelColliders.Length;

        for (int i = 0; i < wc_size; i++)
        {
            // Create wheel shape if the shape is null
            // Will check on each wheel index
            // Also, will give the transform of the parent 

            var thisWheel = _wheelColliders[i];
            if (thisWheel != null)
            {
                var createdWheel = Instantiate(_wheelShape);
                createdWheel.transform.parent = thisWheel.transform;
            }
        }
    }

    private void Update()
    {
        HandleAngleInput();
        HandleTorqueInput();

        // Updating the rotation of the wheels
        _wheelColliders[0].ConfigureVehicleSubsteps(_criticalMaxEngineSpeed, _criticalStepsBelow, _criticalStepsAbove);

        foreach (WheelCollider thisWheel in _wheelColliders)
        {
            if (thisWheel.transform.localPosition.z < 0)
            {
                thisWheel.steerAngle = _angle;
            }

            if (thisWheel.transform.localPosition.z >= 0 && _drivingType != DriveType.RearWheelDrive)
            {
                thisWheel.motorTorque = _torque;
            }

            if (thisWheel.transform.localPosition.z < 0 && _drivingType != DriveType.FrontWheelDrive)
            {
                thisWheel.motorTorque = _torque;
            }

            if (_wheelShape)
            {
                Vector3 pos;
                Quaternion quat;

                thisWheel.GetWorldPose(out pos, out quat);

                Transform wheelShapeTransform = thisWheel.transform.GetChild(0);

                if (thisWheel.CompareTag("Wheel_BackLeft") || thisWheel.CompareTag("Wheel_FrontLeft"))
                {
                    wheelShapeTransform.rotation = quat * Quaternion.Euler(0, 180, 0);
                    wheelShapeTransform.position = pos;
                }
                else
                {
                    wheelShapeTransform.position = pos;
                    wheelShapeTransform.rotation = quat;
                }
            }
        }
    }
    #endregion

    #region Private Methods
    private void HandleTorqueInput()
    {
        _torque = -1f * _maxWheelTorque;
    }

    private void HandleAngleInput()
    {
        float angle = InputManager.Instance.GetPlayerMovement();
        _angle = angle * _maxSteeringAngle;
    }
    #endregion
}