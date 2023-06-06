using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMissionCompleted : MonoBehaviour
{
    private QuestCompletion _questCompletion;
    private QuestList _questList;

    private void Start()
    {
        _questCompletion = GetComponent<QuestCompletion>();
        _questList = FindObjectOfType<QuestList>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _questList.HasQuest(_questCompletion.quest))
        {
            _questCompletion.CompleteObjective();
        }
    }
}
