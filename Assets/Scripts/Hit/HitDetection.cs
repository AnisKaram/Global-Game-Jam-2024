using UnityEngine;
using UnityEngine.Events;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    public bool IsGrounded;

    public static event UnityAction OnCarHitCharacter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            collision.collider.tag = "Untagged";
            OnCarHitCharacter?.Invoke();
            Destroy(collision.gameObject, Random.Range(2.5f, 3.5f));
        }
    }
    
    private void Update()
    {
        if (GameManager.Instance.GameState == GameState.Running)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, _groundMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
                IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
                GameManager.Instance.GameLost();
            }
        }
    }
}