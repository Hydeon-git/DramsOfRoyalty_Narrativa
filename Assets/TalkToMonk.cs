using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkToMonk : MonoBehaviour
{
    [SerializeField]
    private GameObject text_talk;
    [SerializeField]
    private GameObject gptChat; 
    [SerializeField]
    private TMP_Text textIA;
    private void OnTriggerEnter(Collider other)
    {
        text_talk.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {            
            if (Input.GetKey(KeyCode.F))
            {
                gptChat.SetActive(true);
                text_talk.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text_talk.SetActive(false);
            gptChat.SetActive(false);
        }
    }

    public void CloseChat()
    {
        gptChat.SetActive(false);
        textIA.text = "";
    }
}
