using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SummonGate : MonoBehaviour
{

    [SerializeField] private float summonDuration;
    private float duration;
    private ConditionManager conditionManager;
    private InventoryManager inventoryManager;
    private Character character;
    private List<Character> characterList;


    private void Awake()
    {
        //character = GameObject.Find("MaskDude");
        conditionManager = FindAnyObjectByType<ConditionManager>();
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        CharacterManager characterManager = FindAnyObjectByType<CharacterManager>();
        characterList = characterManager.characterList;
        duration = 0f;
    }

    private void Update()
    {
        duration += Time.deltaTime;
        if (duration > summonDuration)
        {
            Summon();
        }
    }

    public void Summon()
    {
        character = characterList[conditionManager.checkCondition()];
        Item dropItem = character.Drop;
        inventoryManager.addItem(dropItem, dropItem.Count);
        character.CharactorObject.SetActive(true);
        Instantiate(character.CharactorObject);
        duration = 0f;
    }
}


