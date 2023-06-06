using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanWeapons : MonoBehaviour
{
    [SerializeField] private GameObject workCleanWeaponsText;
    [SerializeField] private Animator animatorPlayer;
    private QuestCompletion _questCompletion;
    private QuestList _questList;
    private bool hasCleanIt = false;
    private void Start()
    {
        _questCompletion = GetComponent<QuestCompletion>();
        _questList = FindObjectOfType<QuestList>();
    }


    private void Update()
    {
        if (animatorPlayer.GetBool("workCleanWeapons") == true)
        {
            StartCoroutine(WaitUntilWorkFinishes());            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        workCleanWeaponsText.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            if (Input.GetKeyDown(KeyCode.F) && hasCleanIt == false)
            {
                hasCleanIt = true;
                animatorPlayer.SetBool("workCleanWeapons", true);
                workCleanWeaponsText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            workCleanWeaponsText.SetActive(false);
        }
    }

    IEnumerator WaitUntilWorkFinishes()
    {
        yield return new WaitForSeconds(3f);
        animatorPlayer.SetBool("workCleanWeapons", false);

        if (_questList.HasQuest(_questCompletion.quest))
        {
            _questCompletion.CompleteObjective();
            StartCoroutine(WaitToLoadScene());
        }
        
    }

    IEnumerator WaitToLoadScene()
    {
        yield return new WaitForSeconds(3f);        
        SceneManager.LoadScene("KingRoomBuena");

    }
}
