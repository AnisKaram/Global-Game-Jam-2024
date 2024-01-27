using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private Transform _lookAtTargetPosition;

    [SerializeField] private float cameraSmoothing;

    public Transform CameraPosition
    {
        get { return _cameraPosition; }
        set { _cameraPosition = value; }
    }

    public Transform LookAtTargetPosition
    {
        get { return _lookAtTargetPosition; }
        set { _lookAtTargetPosition = value; }
    }

    private void Start()
    {
        transform.position = _cameraPosition.position;
        transform.LookAt(_lookAtTargetPosition);
    }

    private void FixedUpdate()
    {
        UpdateMainCamera();
    }

    private void UpdateMainCamera()
    {
        transform.position = Vector3.Lerp(transform.position, _cameraPosition.position, Time.deltaTime * cameraSmoothing);
        transform.LookAt(_lookAtTargetPosition);
    }
}
