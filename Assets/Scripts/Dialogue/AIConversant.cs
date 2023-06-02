using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using UnityEditor;

public class AIConversant : MonoBehaviour
{
    [SerializeField] Dialogue dialogue = null;
    [SerializeField] string conversantName;
    private GameObject _player;
    bool _startedDialogue = false;
    private PlayerConversant _playerConversant;
    [SerializeField] private bool inRangeConversant = false;
    [SerializeField] private GameObject pressToTalk;
    private AgentMovement _agentMovement;

    private void Start()
    {
       
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerConversant = _player.GetComponent<PlayerConversant>();
        _agentMovement = GetComponent<AgentMovement>();
    }
    private void Update()
    {
       
        if (dialogue == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F) && _startedDialogue == false && inRangeConversant)
        {
            _playerConversant.StartDialogue(this, dialogue);
            _startedDialogue = true;
            

        }

        
    }


    public string GetName()
    { return conversantName; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            inRangeConversant = true;
            pressToTalk.SetActive(true);
            if(_agentMovement!=null)
                _agentMovement.StopToTalk();
        }
        
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            inRangeConversant = false;
            pressToTalk.SetActive(false);
            if(_agentMovement!=null)
                _agentMovement.StartWalking();
        }
    }
}
