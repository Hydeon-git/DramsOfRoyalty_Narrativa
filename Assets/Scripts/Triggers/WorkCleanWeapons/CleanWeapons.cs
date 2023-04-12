using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanWeapons : MonoBehaviour
{
    [SerializeField] private GameObject workCleanWeaponsText;
    [SerializeField] private Animator animatorPlayer;

    private void Update()
    {
        if (animatorPlayer.GetBool("workCleanWeapons") == true)
        {
            StartCoroutine(WaitUntilWorkFinishes());            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        workCleanWeaponsText.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {            
            if (Input.GetKey(KeyCode.F))
            {
                animatorPlayer.SetBool("workCleanWeapons", true);
                workCleanWeaponsText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            workCleanWeaponsText.SetActive(false);
        }
    }

    IEnumerator WaitUntilWorkFinishes()
    {
        yield return new WaitForSeconds(3f);
        animatorPlayer.SetBool("workCleanWeapons", false);
    }
}
