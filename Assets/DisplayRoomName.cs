using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayRoomName : MonoBehaviour
{
    [SerializeField]
    private string roomName;
    [SerializeField]
    private TMP_Text tmpText;
    [SerializeField] 
    private GameObject textContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayText());
        }
    }

    IEnumerator DisplayText()
    {
        textContainer.SetActive(true);
        tmpText.text = roomName;
        yield return new WaitForSeconds(3f);
        textContainer.SetActive(false);
    }
}
