
using System;
using System.Collections.Generic;
using UnityEngine;

// condition d'un objectif
public class Condition
{
    // valeur à l'init de la condition
    public float currentValue;

    // valeur à atteindre pour déclancher une action
    public float limitValue;

    // est-ce qu'il s'agit d'une condiont menant à un succes
    // peut être changer le type pour plus de varieté
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
    // titre et description de l'objectif
    public string title;
    public string description;

    // liste de conditions pour reussir ou echouer l'objectif
    public Dictionary<string, Condition> conditionList;

    // fonction a appeler en cas de succes ou d'echec
    // a remplir par la classe qui l'instancie
    public Action SuccessAction;
    public Action FailureAction;

    // init d'un objectif
    public LevelObjective(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.conditionList = new Dictionary<string, Condition>();
    }

    // ajoute la condition à la liste de conditions
    public void AddCondition(string name, Condition newObj)
    {
        Debug.Log(newObj.limitValue);
        conditionList.Add(name, newObj);
    }

    // permet de mettre a jour un objectif en l'incrementant ou en changeant directement la valeur
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
