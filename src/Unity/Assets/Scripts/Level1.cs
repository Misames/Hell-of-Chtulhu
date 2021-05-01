using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private static List<LevelObjective> listObjective;
    private float levelStartTime;
    private void Awake()
    {
        Debug.Log("init lv1");
        levelStartTime = Time.time;
        listObjective = new List<LevelObjective>();
        LevelObjective newLvlObj = new LevelObjective("Tuer des ennemies", "Tué 5 ennemies avant la fin du temps");
        Condition success1 = new Condition(0, 2, true);
        Condition failure1 = new Condition(0, 30, false);
        Debug.Log("ajout cond");
        newLvlObj.AddCondition("numberKilled", success1);
        newLvlObj.AddCondition("timeLimit", failure1);
        Debug.Log("ajout fonc");
        newLvlObj.SuccessAction = () => Debug.Log("Bravo vous avez réussi");
        newLvlObj.FailureAction = () => Debug.Log("Vous avez échoué");
        Debug.Log("ajout obj");
        listObjective.Add(newLvlObj);
    }

    public static void UpdateKill()
    {
        listObjective[0].UpdateObjective("numberKilled", 1, false);
    }

    private void Update()
    {
        listObjective[0].UpdateObjective("timeLimit", Time.time - levelStartTime, true);
    }
}
