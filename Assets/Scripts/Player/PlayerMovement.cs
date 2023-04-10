using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private CharacterController characterController;
    private Animator animator;

    [Header("Character Movement")]
    public Transform cam;
    public float playerSpeed;
    public float playerRotationSmoothTime;

    private float turnSmoothVelocity;   

    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 gravity = Physics.gravity;
        characterController.Move(gravity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            // This gets the angle in deg needed to know where the player has to rotate
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // We process the target angle into the var angle in order to get a smoothed rotation of the player
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, playerRotationSmoothTime);
            // We equal transform.rotation in a quaternion.euler, passing into the y position the smoothed angle.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            animator.SetBool("isMoving", true);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }   
}
