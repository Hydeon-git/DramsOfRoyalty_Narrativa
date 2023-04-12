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

    private void Start()
    {
       
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerConversant = _player.GetComponent<PlayerConversant>();
    }
    private void Update()
    {
       
        if (dialogue == null)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && _startedDialogue == false)
        {
            _playerConversant.StartDialogue(this, dialogue);
            _startedDialogue = true;

        }

        
    }

    public string GetName()
    { return conversantName; }
}
