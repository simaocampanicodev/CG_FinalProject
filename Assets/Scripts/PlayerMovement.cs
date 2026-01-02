using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 5f;

  private Rigidbody rb;
  private Vector3 input;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    input = transform.right * h + transform.forward * v;
  }

  private void FixedUpdate()
  {
    Vector3 velocity = new Vector3(
        input.x * moveSpeed,
        rb.linearVelocity.y,
        input.z * moveSpeed
    );

    rb.linearVelocity = velocity;
  }
}
