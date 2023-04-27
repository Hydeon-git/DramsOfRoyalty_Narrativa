using System.Collections;
using System.Collections.Generic;
using ChatGPTWrapper;
using GPT_Wrapper;
using TMPro;
using UnityEngine;

namespace ChatGPTWrapper
{
    public class TextResponse : MonoBehaviour
    {
        public TMP_Text _textResponse;
        public TMP_InputField _textInput;
        private ChatGPTConversation _chatGptConversation;
        public string characterReminder;

        // Start is called before the first frame update
        void Start()
        {
            _chatGptConversation = FindObjectOfType<ChatGPTConversation>();
        }

        public void SetText(string response)
        {
            _textResponse.text = response;
            Debug.Log(response);
        }

        public void SendInformation()
        {
            var message = _textInput.text;
            _chatGptConversation.SendToChatGPT(characterReminder + message);
            Debug.Log(message);
        }
    }
}
