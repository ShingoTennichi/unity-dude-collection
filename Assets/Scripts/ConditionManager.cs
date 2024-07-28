using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class ConditionManager : MonoBehaviour
{
    public List<Condition> conditionList = new List<Condition>();
    public Dictionary<string, Item> ItemData = new Dictionary<string, Item>();

    private void Start()
    {

    }

    public void addCondition(Item item)
    {
        Condition condition = new Condition(item);
        conditionList.Add(condition);
    }

    public void addCondition(string itemName)
    {
        Condition condition = conditionList.FirstOrDefault(u => u.Name == itemName);
        if (condition == null)
        {
            addCondition(itemName);
        }
        else
        {
            condition.Count++;
        }
    }

    public int checkCondition()
    {

        Condition condition = conditionList.Count == 0 ? null: conditionList[0];
        if (condition != null)
        {
            if (condition.Count > 30)
            {
                return 3;
            }
            else if (condition.Count > 20)
            {
                return 2;
            }
            else if (condition.Count > 10)
            {
                return 1;
            }
        }

        return 0;
    }
}


[System.Serializable]
public class Condition
{
    public string Name;
    public int Count;

    public Condition(Item item)
    {
        this.Name = item.Name;
        this.Count = 1;
    }
}
