using System;
using System.Collections;
using System.Collections.Generic;
using ChatGPTWrapper;
using GPT_Wrapper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TMP_Text textResponse;
    [SerializeField] private TMP_InputField _tmpInputField;
    [SerializeField] ChatGPTConversation chat;

    private void Awake()
    {
        chat = GetComponent<ChatGPTConversation>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) SendToChatGPT();
    }

    public void ProcesarRespuesta(string respuesta) {
        textResponse.text = respuesta;
    }

    public void SendToChatGPT()
    {
        chat.SendToChatGPT(_tmpInputField.text);
        _tmpInputField.text = "";
    }
}

