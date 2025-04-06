using UnityEngine;

[ExecuteInEditMode]
public class SuspensionController : MonoBehaviour
{
    [Range(0.1f, 20f)]
    [Tooltip("This is the natural frequency of the car suspension springs. Describes the bounciness of the Suspension")]
    [SerializeField] private float suspNaturalFrequency = 10f;

    [Range(0f, 3f)]
    [Tooltip("This is the damping ratio of the suspension springs. Describes how fast the spring returns back after a bounce. ")]
    [SerializeField] private float suspDampingRatio = 0.8f;

    [Range(-1f, 1f)]
    [Tooltip("The distance along the Y axis the suspension forces application point is offset below the center of mass")]
    [SerializeField] private float suspForcehShift = 0.03f;

    [Tooltip("Adjust the length of the suspension springs according to the natural frequency and damping ratio. When off, can cause unrealistic suspension bounce.")]
    [SerializeField] private bool setSuspensionDistance = true;

    private Rigidbody _carRigidbody;
    private WheelCollider[] _wheelColliders;

    private void Awake()
    {
        _carRigidbody = GetComponent<Rigidbody>();
        _wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    private void Update()
    {
        Suspension();
    }

    private void Suspension()
    {
        // Work out the stiffness and damper parameters based on the better spring model.
        foreach (WheelCollider wheelCollider in _wheelColliders)
        {
            JointSpring spring = wheelCollider.suspensionSpring;

            float sqrtWcSprungMass = Mathf.Sqrt(wheelCollider.sprungMass);
            spring.spring = sqrtWcSprungMass * suspNaturalFrequency * sqrtWcSprungMass * suspNaturalFrequency;
            spring.damper = 2f * suspDampingRatio * Mathf.Sqrt(spring.spring * wheelCollider.sprungMass);

            wheelCollider.suspensionSpring = spring;

            Vector3 wheelRelativeBody = transform.InverseTransformPoint(wheelCollider.transform.position);
            float distance = _carRigidbody.centerOfMass.y - wheelRelativeBody.y + wheelCollider.radius;

            wheelCollider.forceAppPointDistance = distance - suspForcehShift;

            // Make sure the spring force at maximum droop is exactly zero
            if (spring.targetPosition > 0 && setSuspensionDistance)
                wheelCollider.suspensionDistance = wheelCollider.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
        }
    }
}
