using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform lookAtTargetPosition;

    [SerializeField] private float cameraSmoothing = 16f;

    private void Start()
    {
        transform.position = cameraPosition.position;
        transform.LookAt(lookAtTargetPosition);
    }

    private void FixedUpdate()
    {
        UpdateMainCamera();
    }

    private void UpdateMainCamera()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPosition.position, Time.deltaTime * cameraSmoothing);
        transform.LookAt(lookAtTargetPosition);
    }
}
