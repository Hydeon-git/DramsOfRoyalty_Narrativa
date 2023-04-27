using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "CharacterGenerator/CreateCharacterProfile", order = 1)]
public class CharacterCreation : ScriptableObject
{ 
    
    public string characterName;
    [TextArea(5,5)]
    public string characterDescription;
    public string characterMotivations;
    public string characterGreet;
    public string characterRole;
    [TextArea(5,5)]
    public string thingsCharacterKnows;
    [TextArea(5,5)]
    public string characterMission;

    
    


}
