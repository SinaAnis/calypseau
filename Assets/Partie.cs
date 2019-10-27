using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Partie : MonoBehaviour
{

    //public static List<Question> questions = new List<Question>(); // liste d'epreuves (questions)
    public static int nbQuestion = 12; // nombre d'epreuve (nb de question)
    public static int nbQuestionRepondu = 0; // numéro de l'epreuve en cours
    public static int nbErreur = 0; // nombre d'erreur
    public static float[] eauLevel = new float[] { 0, 0.1f, 0.3f , 0.3f}; // tableau des différents level d'eau
    public static float levelSelect;

    public Mesh meshPorte;
    public Material materialPorte;

    // fonction qui ajouter le niveau de l'eau;
    public static void addWater()
    {
        levelSelect = eauLevel[nbErreur];  
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    void Update()
    {
        if (levelSelect > 0)
        {
            var water = GameObject.Find("Eau");
            water.transform.Translate(0, 0.0005f, 0);

            levelSelect -= 0.0005f;

        }
    }

}
