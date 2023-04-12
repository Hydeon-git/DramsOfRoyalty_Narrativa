using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterKingRoom : MonoBehaviour
{
    public GameObject openDoorText;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            openDoorText.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("KingRoom");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            openDoorText.SetActive(false);            
        }
    }
}
