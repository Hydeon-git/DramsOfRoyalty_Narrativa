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

    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

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
                _playerMovement.CannotMove();
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
