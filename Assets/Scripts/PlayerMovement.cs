using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 5f;
  [SerializeField] private float gravity = -9.81f;

  private CharacterController controller;
  private Vector3 velocity;
  private Vector3 input;

  private void Awake()
  {
    controller = GetComponent<CharacterController>();
  }

  private void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    input = transform.right * h + transform.forward * v;
  }

  private void FixedUpdate()
  {
    controller.Move(input * moveSpeed * Time.fixedDeltaTime);

    velocity.y += gravity * Time.fixedDeltaTime;
    controller.Move(velocity * Time.fixedDeltaTime);
  }
}
