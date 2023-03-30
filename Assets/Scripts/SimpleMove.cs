using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimpleMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private CinemachineFreeLook freeLookCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        freeLookCam = FindObjectOfType<CinemachineFreeLook>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Obtenemos la orientaci�n de la c�mara en el eje Y
            float camYRotation = freeLookCam.transform.rotation.eulerAngles.y;
            // Convertimos la orientaci�n de la c�mara a una rotaci�n en quaterniones
            Quaternion camRotation = Quaternion.Euler(0f, camYRotation, 0f);
            // Rotamos la direcci�n del personaje en funci�n de la orientaci�n de la c�mara
            direction = camRotation * direction;
            // Rotamos el personaje para que mire en la direcci�n de la c�mara
            transform.rotation = Quaternion.Lerp(transform.rotation, camRotation, rotationSpeed * Time.deltaTime);
        }

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
}
