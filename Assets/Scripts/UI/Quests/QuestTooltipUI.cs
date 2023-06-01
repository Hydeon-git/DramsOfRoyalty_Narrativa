using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestTooltipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Transform objectiveContainer;
    [SerializeField] private GameObject objectivePrefab;
    [SerializeField] private GameObject objectiveIncompletePrefab;
    public void Setup(QuestStatus status)
    {
        Quest quest = status.GetQuest();
        title.text = quest.GetTitle();
        objectiveContainer.DetachChildren();
        foreach (string objective in quest.GetObjectives())
        {
            GameObject prefab = objectiveIncompletePrefab;
            if (status.IsObjectiveComplete(objective))
            {
                prefab = objectivePrefab;
            }
            GameObject objectiveInstance = Instantiate(prefab, objectiveContainer);
            TextMeshProUGUI objectiveText =  objectiveInstance.GetComponentInChildren<TextMeshProUGUI>();
            objectiveText.text = objective;
        }
    }
}
