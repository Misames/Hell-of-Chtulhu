using System.Collections.Generic;
using System;
using UnityEngine;

public class Condition
{
    public float currentValue;
    public float limitValue;
    public bool isSuccessCondition;

    // init d'une condition
    public Condition(float initialV, float limitV, bool isSuccess)
    {
        currentValue = initialV;
        limitValue = limitV;
        isSuccessCondition = isSuccess;
    }
}

// Classe permettant de créer des objectifs pour un level
public class LevelObjective
{
    public string title;
    public string description;
    public Dictionary<string, Condition> conditionList;
    public Action SuccessAction;
    public Action FailureAction;

    public LevelObjective(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.conditionList = new Dictionary<string, Condition>();
    }

    public void AddCondition(string name, Condition newObj)
    {
        Debug.Log(newObj.limitValue);
        conditionList.Add(name, newObj);
    }

    public void UpdateObjective(string name, float value, bool equal = false)
    {
        Condition cond = conditionList[name];
        if (equal) cond.currentValue = value;
        else cond.currentValue += value;
        if (cond.currentValue >= cond.limitValue)
        {
            if (cond.isSuccessCondition) SuccessAction();
            else FailureAction();
        }
    }
}
