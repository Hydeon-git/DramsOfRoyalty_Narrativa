using System;
using System.Collections;
using System.Collections.Generic;
using ChatGPTWrapper;
using GPT_Wrapper;
using UnityEngine;

public class CharacterPromp : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterCreation characterValues;
    private ChatGPTConversation chatGptConversation;
    public string characterPromp;

    private void Awake()
    {
         chatGptConversation = GetComponent<ChatGPTConversation>();
        // characterPromp = "Your goal is to roleplay as a character that I will specify. Your speech should accurately reflect the way the character speaks, " +
        //                  " their tone, and their distinctive mannerisms, and any speech patterns that are unique to the character. " +
        //                  "Respond as if you were the specified character and limit your responses to the knowledge that the character would reasonably possess." +
        //                  " Dont forget to always start the conversation with this greeting: " + characterValues.characterGreet +
        //                  ". Now im going to give information about your character. Integrate it into you acting. \n\n" +
        //                  "You are " + characterValues.characterName +
        //                  " \nYour job in the castle is " + characterValues.characterRole +
        //                  "\nThis is your personality: " + characterValues.characterDescription;
        //
        // _chatGptConversation._initialPrompt = characterPromp;

        characterPromp = "Hola, quiero que interactues conmigo en un roleplay."
                         + "\n Durante la conversación te iré recordando como eres y las cosas que sabes para que no lo olvides. " +
                         "Estos recordatorios irán entre corchetes. Mi dialogo irá acompañando a los recordatorios." +
                         "\n Solo debes responder al dialogo. Un ejemplo de un input que te entrego será:" +
                         "\n [Recordatorio de como es tu personaje]" +
                         "\n Diálogo.\n\n" +

                         "Tu debes responder solo al Diálogo con la siguiente estructura: \n" +
                         "Respuesta" +
                         "\n [Expresión de la cara]" +
                         "\n {Resumen conversacion} Debes escribir también un resumen en pocas palabras de la Respuesta entre {}";
        chatGptConversation._initialPrompt = characterPromp;
    }

    void Start()
    {
        /*character_promp = "You are a" + characterValues.characterRole +
                          " in a castle. Mantén una conversación conmigo. Don't break character. " +
                          "Don't ever mention that you are an AI model. Write in spanish." +
                          " Siempre saludas diciendo: " + characterValues.characterGreet
                          + "Tu nombre es: " + characterValues.name + ". Tú eres así: " +
                          characterValues.characterDescription +
                          ".  Tus motivaciones son: "
                          + characterValues.characterMotivations + ". Tus inseguridades son: " +
                          characterValues.characterInsecurities +
                          ".  Your castle's role: " +
                          characterValues.characterRole + ". Your age is: " +
                          characterValues.characterStateOfLife +
                          ".  You know this things about the life in the castle: " +
                          characterValues.thingsCharacterKnows +
                          ".  You can only share your knowledge about the castle if: " +
                          characterValues.whenCharacterCanInformate +
                          ".  After some talk if the one who talks to you accepts the mission you must say, only in that" +
                          " case an after a small talk, the following: " +
                          characterValues.characterMission +
                          "No menciones la misión que tienes para ofrecer a menos que se te pregunte. ";*/

        
    }
    
}
