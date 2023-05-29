using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicEnd : MonoBehaviour
{
    [SerializeField] GameObject ThirdPersonCamera;    

    
    private void Update()
    {
        if (gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition == 7)
        {
            ThirdPersonCamera.GetComponent<CinemachineFreeLook>().m_Priority = 10;
            gameObject.GetComponent<CinemachineVirtualCamera>().m_Priority = 9;

            StartCoroutine(WaitChangePathPos());
            
        }
    }
    IEnumerator WaitChangePathPos()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 0;
    }
}
