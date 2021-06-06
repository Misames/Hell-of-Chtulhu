using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Class unique specifique a la premiere map
// une map est composé de plusieurs level
public class Map1 : MonoBehaviour
{
    // liste des objectifs
    // un objectif = un level pour le moment
    private static List<LevelObjective> listLevelObjective;

    // variables utiles a la map
    private float levelStartTime;
    private void Awake()
    {
        // init les variables
        listLevelObjective = new List<LevelObjective>();
        levelStartTime = Time.time;
        // pour test on ajoute les différents niveau ici
        // peut être rajouter un systeme ou des fonctions pour mieux inserer
        InitFirstLevel();

    }

    // cree les conditions du premier niveau
    private void InitFirstLevel()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective newLvlObj = new LevelObjective("Tuer des ennemies", "Tué 5 ennemies avant la fin du temps");
        // cree les conditions
        Condition successNbKill = new Condition(0, 2, true);
        Condition failureTimeLimit = new Condition(0, 30, false);
        // on ajoute les conditions au LevelObjectif
        //Debug.Log("ajout cond");
        newLvlObj.AddCondition("numberKilled", successNbKill);
        newLvlObj.AddCondition("timeLimit", failureTimeLimit);
        // fonction a realiser en cas de reussite
        newLvlObj.SuccessAction = () =>
        {
            Debug.Log("Bravo vous avez réussi");
            // Lance le prochain level
            // clear précédent objectif?
        };

        // fonction a realiser en cas d'echec
        newLvlObj.FailureAction = () =>
        {
            Debug.Log("Vous avez échoué");
            // game over
            // retour checkpoint?
        };

        Debug.Log("ajout obj");
        // on rajoute l'objectif
        listLevelObjective.Add(newLvlObj);
    }

    // une fonction pour update les conditions
    public static void UpdateKill()
    {
        listLevelObjective[0].UpdateObjective("numberKilled", 1, false);
    }

    // les conditions a update constament
    private void Update()
    {
        listLevelObjective[0].UpdateObjective("timeLimit", Time.time - levelStartTime, true);
    }
}
