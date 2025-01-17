﻿using System.Collections.Generic;
using System;

public class Condition
{
    public float currentValue;
    public float limitValue;
    public bool isSuccessCondition;

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

    public LevelObjective(string title = "", string description = "")
    {
        this.title = title;
        this.description = description;
        this.conditionList = new Dictionary<string, Condition>();
    }

    public void AddCondition(string name, Condition newObj)
    {
        conditionList.Add(name, newObj);
    }

    public Condition GetCondition(string name)
    {
        return conditionList[name];
    }

    public void RemoveCondition(string name)
    {
        if (conditionList.ContainsKey(name)) conditionList.Remove(name);
    }

    public void UpdateObjective(string name, float value, bool equal = false)
    {
        if (conditionList.ContainsKey(name))
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
}
