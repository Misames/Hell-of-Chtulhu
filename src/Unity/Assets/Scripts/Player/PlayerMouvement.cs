using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float sprintSpeed = 24f;
    public float sprintDuration = 5f;
    public float timeRecoverySprint = 5f;
    public float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Check si on est au sol et que le gameobjet ne soit pas en chute libre
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintDuration > 0)
        {
            speed = sprintSpeed;
            sprintDuration -= Time.deltaTime;
        }
        else
        {
            speed = 12f;
            if (sprintDuration <= 0)
            {
                if (timeRecoverySprint > 0)
                {
                    timeRecoverySprint -= Time.deltaTime;
                }
                else
                {
                    timeRecoverySprint = 5f;
                    sprintDuration = 5f;
                }
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Check si on est bien en contact le sol et qu'on appuis sur la touche de saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(3f * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
