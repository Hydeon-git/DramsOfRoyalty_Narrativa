using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnfadarCompleted : MonoBehaviour
{
    private QuestCompletion _questCompletion;
    private QuestList _questList;

    private void Start()
    {
        _questCompletion = GetComponent<QuestCompletion>();
        _questList = FindObjectOfType<QuestList>();
    }
    public void CallCoroutineLoadScene()
    {
        SceneManager.LoadScene("KingRoomMalo");
        //StartCoroutine(SceneBadKing());
    }

    private IEnumerator SceneBadKing()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("KingRoomMalo");
    }
}
