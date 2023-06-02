using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private CharacterController characterController;
    private Animator animator;

    [Header("Character Movement")]
    public Transform cam;
    public float playerSpeed;
    public float playerRotationSmoothTime;
    public CinemachineFreeLook cinemachineFreeLook;

    private float turnSmoothVelocity;

    public bool _canMove = true;

    private void Start()
    {
        cinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();
        Cursor.lockState = CursorLockMode.Locked;

        characterController = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        //para desbloquear el raton y poder contestar.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.Confined;
            cinemachineFreeLook.gameObject.SetActive(false);
            animator.SetBool("isMoving", false);
            _canMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            cinemachineFreeLook.gameObject.SetActive(true);
            _canMove = true;
        }
        if(!_canMove) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        
        

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 gravity = Physics.gravity;
        characterController.Move(gravity * Time.deltaTime);

        // Si no esta trabajando
        if (animator.GetBool("workCleanWeapons") == false)
        {
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
}
