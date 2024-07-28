using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterManager : MonoBehaviour
{
    public List<Character> characterList = new List<Character>();
    
    public void addItem()
    {
        
    }

    public void addItem(string ItemID)
    {
        Character TempItem = characterList.FirstOrDefault(u => u.Name == ItemID);
    }
}

[System.Serializable]
public class Character
{
    public string Name;
    public string Description;
    public GameObject CharactorObject;
    public Item Drop;
    public int point;
}