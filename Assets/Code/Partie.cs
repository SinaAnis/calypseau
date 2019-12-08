using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Partie : MonoBehaviour
{
    //public static List<Question> questions = new List<Question>(); // liste d'epreuves (questions)
    public static int nbQuestion = 6; // nombre d'epreuve (nb de question)
    public static int nbQuestionRepondu = 0; // numéro de l'epreuve en cours
    public static int nbErreur = 0; // nombre d'erreur
    public static int nbErreurMax = 3; // nombre d'erreur
    public static float[] eauLevel = new float[] { 0, 0.1f, 0.3f , 0.3f}; // tableau des différents level d'eau
    public static float levelSelect; // level de l'eau en cours

    public Epreuve lastEpreuve; // Derniere Epreuve repondu

    public Mesh meshPorte; // Mesh du portail
    public Material materialPorte; // Material du portail
    public Canvas canvasQuestion; // canvas de la question

    private float currCountdownValue; // timeur de la partie
 
    void Start()
    {

        // Initialiser l'interface utilisateur

        GameObject.Find("Gagne").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Perdue").GetComponent<Canvas>().enabled = false;

        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Text>().enabled = false;
        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Image>().enabled = false;
        GameObject.Find("CanvasMinuteurAnimation").GetComponentInChildren<Text>().enabled = false;

        canvasQuestion.enabled = false; 

        // Initialiser les passages et le Bloc 2

        var bloc2 = GameObject.Find("Bloc2").GetComponentsInChildren<MeshRenderer>();
        if (bloc2 != null)
        {
            foreach (Component flame in bloc2)
            {
                flame.GetComponent<MeshRenderer>().enabled = false;
                if (flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = false;
            }
        }

        var passage = GameObject.Find("Passage1to2A").GetComponentsInChildren<MeshRenderer>();
        if (passage != null)
        {
            foreach (Component flame in passage)
            {
                flame.GetComponent<MeshRenderer>().enabled = false;
                if(flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = false;
            }
        }

        GameObject.Find("Passage1to2A").GetComponent<BoxCollider>().enabled = false;

        var passage2 = GameObject.Find("Passage1to2B").GetComponentsInChildren<MeshRenderer>();
        if (passage2 != null)
        {

            foreach (Component flame in passage2)
            {
                flame.GetComponent<MeshRenderer>().enabled = true;
                if (flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = true;
            }
        }

        GameObject.Find("Passage1to2B").GetComponent<BoxCollider>().enabled = true;

    }

    void Update()
    {
        // condition pour animer la montée de l'eau dans le labyrinthe
        if (levelSelect > 0)
        {
            var water = GameObject.Find("Eau");
            water.transform.Translate(0, 0.0005f, 0);

            levelSelect -= 0.0005f;

        }

        // condition pour verifier le nombre de question repondu avec le nombre de question maximum
        if(nbQuestion == nbQuestionRepondu)
        {
            GameObject.Find("Gagne").GetComponent<Canvas>().enabled = true;
        }

        // condition pour vérifier le nombre d'erreur avec le nombre d'erreur maximum
        if(nbErreur == nbErreurMax)
        {
            GameObject.Find("Perdue").GetComponent<Canvas>().enabled = true;
        }
    }

    // fonction qui lance la vérification d'une question
    public void VerifQuestion()
    {
        lastEpreuve.VerifAnswer();
    }

    // fonction pour lancer le jeu
    public void Play()
    {
        GameObject.Find("Debut").GetComponentInChildren<Canvas>().enabled = false;
        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Text>().enabled = true;
        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Image>().enabled = true;
        currCountdownValue = 600;
        StartCoroutine(StartCountdown());
    }

    // fonction pour revenir au menu
    public void Menu()
    {
        GameObject.Find("Debut").GetComponentInChildren<Canvas>().enabled = true;
        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Text>().enabled = false;
        GameObject.Find("CanvasMinuteur").GetComponentInChildren<Image>().enabled = false;
    }

    //fonction pour quitter le jeu
    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

    // fonction qui permet de débuter le minuteur de la partie
    public IEnumerator StartCountdown()
    {
        
        while (currCountdownValue >= 0)
        {
            string minutes = Mathf.Floor(currCountdownValue / 60).ToString("00");
            string seconds = (currCountdownValue % 60).ToString("00");

            GameObject.Find("CanvasMinuteur").GetComponentInChildren<Text>().text = "Temps restant : " + minutes + ":" + seconds;
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        GameObject.Find("Perdue").GetComponent<Canvas>().enabled = true;

    }

    // fonction qui affiche le gain/perte de temps dans le minuteur
    public IEnumerator StartAnimationMinuteur()
    {
        GameObject.Find("CanvasMinuteurAnimation").GetComponentInChildren<Text>().enabled = true;
        yield return new WaitForSeconds(2.0f);
        GameObject.Find("CanvasMinuteurAnimation").GetComponentInChildren<Text>().enabled = false;

    }

    // fonction qui ajoute du temps du minuteur
    public void AddTime()
    {
        this.currCountdownValue += 15;
        GameObject.Find("CanvasMinuteurAnimation").GetComponentInChildren<Text>().text = "+15 secondes";
        StartCoroutine(StartAnimationMinuteur());
    }

    //fonction qui retire du temps du minuteur
    public void RemoveTime()
    {
        this.currCountdownValue -= 15;
        GameObject.Find("CanvasMinuteurAnimation").GetComponentInChildren<Text>().text = "-15 secondes";
        StartCoroutine(StartAnimationMinuteur());
    }

    // fonction qui ajouter le niveau de l'eau;
    public static void addWater()
    {
        levelSelect = eauLevel[nbErreur];
    }
}
