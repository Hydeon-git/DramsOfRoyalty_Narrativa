using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMissionCompleted : MonoBehaviour
{
    private QuestCompletion _questCompletion;

    private void Start()
    {
        _questCompletion = GetComponent<QuestCompletion>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _questCompletion.CompleteObjective();
        }
    }
}
