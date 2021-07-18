using System;
using System.Collections.Generic;
using TMPro;
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
    private static float levelStartTime;
    private static int currentZone;
    
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI ObjectiveUI;


    private void Awake()
    {
        // init les variables
        listLevelObjective = new List<LevelObjective>();
        
        currentZone = 0;
        // pour test on ajoute les différents niveau ici
        // peut être rajouter un systeme ou des fonctions pour mieux inserer
        InitLevel();
        timeUI.enabled = false;
    }

    // cree les conditions du premier niveau
    private void InitLevel()
    {
        initZoneIntermediary();
        initZone1();
        initZone2();
        initZone3();
        initZone4();
        initZone5();
    }
    
    private void initZoneIntermediary()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective intermediary = new LevelObjective("Atteindre la prochaine zone", "Dépéchez-vous!!!");


        // on ajoute les conditions au LevelObjectif
        intermediary.AddCondition("damageTaken", new Condition(0, 100, false));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        intermediary.SuccessAction = () => gameManager.IncreaseScore();

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        intermediary.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(intermediary);
    }

    private void initZone1()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective zone1 = new LevelObjective("Tuer des ennemies", "Tué 10 ennemies avant la fin du temps");

        zone1.AddCondition("damageTaken", new Condition(0, 100, false));
        zone1.AddCondition("timeLimit", new Condition(0, 60, false));
        zone1.AddCondition("numberKilled", new Condition(0, 10, true));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        zone1.SuccessAction = () => gameManager.IncreaseScore();

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        zone1.FailureAction = () => gameManager.GameOver();
        

        // on rajoute l'objectif
        listLevelObjective.Add(zone1);
    }
    
    private void initZone2()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective zone2 = new LevelObjective("Tuer des ennemies", "Tuer 20 ennemies avant la fin du temps");

        // on ajoute les conditions au LevelObjectif
        zone2.AddCondition("damageTaken", new Condition(0, 100, false));
        zone2.AddCondition("timeLimit", new Condition(0, 60, false));
        zone2.AddCondition("numberKilled", new Condition(0, 10, true));
        zone2.AddCondition("HitTheZone", new Condition(0f, 1f, true));
        zone2.AddCondition("IncreaseScore", new Condition(0f, 100000f, true));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        zone2.SuccessAction = () => gameManager.IncreaseScore();
        
        
        // fonction a realiser en cas d'echec
        // retour checkpoint?
        zone2.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(zone2);
    }
    
    private void initZone3()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective zone3 = new LevelObjective("Tuer des ennemies", "Tuer 20 ennemies avant la fin du temps");

        // on ajoute les conditions au LevelObjectif
        zone3.AddCondition("damageTaken", new Condition(0, 100, false));
        zone3.AddCondition("timeLimit", new Condition(0, 60, false));
        zone3.AddCondition("numberKilled", new Condition(0, 20, true));
        zone3.AddCondition("HitTheZone", new Condition(0f, 1f, true));
        zone3.AddCondition("IncreaseScore", new Condition(0f, 100000f, true));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        zone3.SuccessAction = () =>
        {
            
            zone3.RemoveCondition("numberKilled");
            zone3.AddCondition("numberKilled", new Condition(0, 10, true));
            zone3.description = "Tuer 10 autres ennemies";
            zone3.SuccessAction = () => gameManager.IncreaseScore();
        };

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        zone3.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(zone3);
    }
    
    private void initZone4()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective zone4 = new LevelObjective("Tuer des ennemies", "Tuer 20 ennemies avant la fin du temps");

        // on ajoute les conditions au LevelObjectif
        zone4.AddCondition("damageTaken", new Condition(0, 100, false));
        zone4.AddCondition("timeLimit", new Condition(0, 60, false));
        zone4.AddCondition("numberKilled", new Condition(0, 20, true));
        zone4.AddCondition("HitTheZone", new Condition(0f, 1f, true));
        zone4.AddCondition("IncreaseScore", new Condition(0f, 100000f, true));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        zone4.SuccessAction = () =>
        {
            
            zone4.RemoveCondition("numberKilled");
            zone4.AddCondition("numberKilled", new Condition(0, 10, true));
            zone4.description = "Tuer 10 autres ennemies";
            zone4.SuccessAction = () => gameManager.IncreaseScore();
        };

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        zone4.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(zone4);
    }
    
    private void initZone5()
    {
        // cree une liste de conditions de succes ou d'echec pour un objectif
        LevelObjective zone5 = new LevelObjective("Tuer des ennemies", "Tuer 20 ennemies avant la fin du temps");

        // on ajoute les conditions au LevelObjectif
        zone5.AddCondition("damageTaken", new Condition(0, 100, false));
        zone5.AddCondition("timeLimit", new Condition(0, 60, false));
        zone5.AddCondition("numberKilled", new Condition(0, 25, true));
        zone5.AddCondition("HitTheZone", new Condition(0f, 1f, true));
        zone5.AddCondition("IncreaseScore", new Condition(0f, 100000f, true));

        // fonction a realiser en cas de reussite
        // Lance le prochain level
        // clear précédent objectif?
        zone5.SuccessAction = () =>
        {
            
            zone5.RemoveCondition("numberKilled");
            zone5.AddCondition("numberKilled", new Condition(0, 5, true));
            zone5.description = "Tuer 5 autres ennemies";
            zone5.SuccessAction = () => gameManager.IncreaseScore();
        };

        // fonction a realiser en cas d'echec
        // retour checkpoint?
        zone5.FailureAction = () => gameManager.GameOver();

        // on rajoute l'objectif
        listLevelObjective.Add(zone5);
    }

    public static void ChangeCurrentZone(int zoneNumber)
    {
        currentZone = zoneNumber;
        levelStartTime = Time.time;
    }

    // une fonction pour update les conditions
    public static void UpdateKill(float value = 1)
    {
        listLevelObjective[currentZone].UpdateObjective("numberKilled", value, false);
    }

    public static void UpdateHealth(float value)
    {
        listLevelObjective[currentZone].UpdateObjective("damageTaken", value, true);
    }

    public static void UpdateScore(int value = 100)
    {
        listLevelObjective[currentZone].UpdateObjective("IncreaseScore", value, true);
    }

    public static void UpdateZone()
    {
        listLevelObjective[currentZone].UpdateObjective("HitTheZone", 1f, true);
    }

    // les conditions a update constament
    private void Update()
    {
        ObjectiveUI.text = listLevelObjective[currentZone].title + "\n" + listLevelObjective[currentZone].description;
        
        if (currentZone == 0) timeUI.enabled = false;
        else
        {
            timeUI.enabled = true;
            listLevelObjective[currentZone].UpdateObjective("timeLimit", Time.time - levelStartTime, true);
            float t = listLevelObjective[currentZone].GetCondition("timeLimit").limitValue - (Time.time - levelStartTime);
            timeUI.text = (int)t/60+":"+((int)t/10)%6+""+(int)t%10;
        }

    }
}
