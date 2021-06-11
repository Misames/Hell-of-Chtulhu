using System.Collections.Generic;
using UnityEngine;

// Class unique specifique a la premiere map
// une map est composé de plusieurs level
public class Map : MonoBehaviour
{
    // liste des objectifs
    // un objectif = un level pour le moment
    private static List<LevelObjective> listLevelObjective;
    public GameManager gameManager;
    // variables utiles a la map
    private float levelStartTime;

    private void Awake()
    {
        // init les variables
        listLevelObjective = new List<LevelObjective>();
        levelStartTime = Time.time;
        // pour test on ajoute les différents niveau ici
        // peut être rajouter un systeme ou des fonctions pour mieux inserer
        InitLevel();

    }

    // cree les conditions du premier niveau
    private void InitLevel()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective newLvlObj = new LevelObjective("Tuer des ennemies", "Tué 5 ennemies avant la fin du temps");

        // cree les conditions
        Condition successNbKill = new Condition(0, 10, true);
        Condition failureDamageTaken = new Condition(0, 100, false);
        Condition failureTimeLimit = new Condition(0, 30, false);

        // on ajoute les conditions au LevelObjectif
        newLvlObj.AddCondition("numberKilled", successNbKill);
        newLvlObj.AddCondition("damageTaken", failureDamageTaken);
        newLvlObj.AddCondition("timeLimit", failureTimeLimit);

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        newLvlObj.SuccessAction = () => gameManager.GameWin();

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        newLvlObj.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(newLvlObj);
    }

    // une fonction pour update les conditions
    public static void UpdateKill(float value = 1)
    {
        listLevelObjective[0].UpdateObjective("numberKilled", value, false);
    }

    public static void UpdateHealth(float value)
    {
        listLevelObjective[0].UpdateObjective("damageTaken", value, true);
    }

    // les conditions a update constament
    private void Update()
    {
        listLevelObjective[0].UpdateObjective("timeLimit", Time.time - levelStartTime, true);
    }
}
