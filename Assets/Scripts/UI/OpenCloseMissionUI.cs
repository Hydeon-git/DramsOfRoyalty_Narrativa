using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMissionUI : MonoBehaviour
{
    public GameObject questUI;

    void Start()
    {
        questUI.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !questUI.activeSelf)
        {
            questUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.J) && questUI.activeSelf)
        {
            questUI.SetActive(false);
        }
    }
}
