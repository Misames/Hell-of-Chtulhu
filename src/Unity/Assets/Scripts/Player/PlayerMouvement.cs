using UnityEngine;

namespace Player
{
    public class PlayerMouvement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform groundCheck;
        public LayerMask groundMask;
        public float groundDistance = 0.4f;
        public float speed = 12f;
        public float sprintSpeed = 0f;
        public float sprintDuration = 5f;
        public float timeRecoverySprint = 10f;
        public float gravity = -9.81f;
        private Vector3 velocity;
        private bool isGrounded;

        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0) velocity.y = -2f;
            if (Input.GetKey(KeyCode.LeftShift) && sprintDuration > 0)
            {
                sprintSpeed = 12f;
                sprintDuration -= Time.deltaTime;
            }
            else
            {
                sprintSpeed = 0f;
                if (sprintDuration <= 0)
                {
                    if (timeRecoverySprint > 0) timeRecoverySprint -= Time.deltaTime;
                    else
                    {
                        timeRecoverySprint = 5f;
                        sprintDuration = 5f;
                    }
                }
            }

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var move = transform.right * x + transform.forward * z;
            controller.Move(move * ((speed + sprintSpeed) * Time.deltaTime));

            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(3f * -2f * gravity);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
