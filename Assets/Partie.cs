using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Partie : MonoBehaviour
{

    public static List<Question> questions = new List<Question>(); // liste d'epreuves (questions)
    public static int nbQuestion = 12; // nombre d'epreuve (nb de question)
    public static int nbQuestionRepondu = 0; // numéro de l'epreuve en cours
    public static int nbErreur = 0; // nombre d'erreur

    public static Canvas affiche; // canvas de l'affiche
    public static GameObject afficheObjet; // objet de l'affiche

    // méthode qui génère les questions
    public void GenerateQuestions()
    {
        questions.Add(new Question("Question 1 : Quel jour sommes-nous ?", new string[] { "Lundi", "Mardi", "Mercredi" }, 1)); // ajoute une question dans la liste de question
        questions.Add(new Question("Question 2 : De quelle couleur est le cheval blanc d'Henri IV ?", new string[] { "Noir", "Gris", "Blanc" }, 1));
    }

    // méthode qui génère l'affiche
    public void GenerateToggle()
    {
        afficheObjet = GameObject.Find("Question"); // récupère l'objet affiche
        if (afficheObjet != null) // on vérifie qu'il n'est pas null
        {
            affiche = afficheObjet.GetComponent<Canvas>(); // on récupère le canvas de cette affiche
            affiche.enabled = false; // on cache cette affiche
        }
    }

    // méthode qui initialise une question dans le canvas
    public static void SetQuestion()
    {
        if (nbQuestionRepondu < questions.Count) // on véfiie que le nombre de question répondu est inferieur aux nombres de question
        {
            Transform[] ts = afficheObjet.GetComponentsInChildren<Transform>(); // on récupère tous les elements enfant de l'affiche

            foreach (Transform child in ts) // pour chaque element enfant
            {
                switch (child.name) // on compare son nom
                {
                    case "Title": // si c'est égale à "Title"
                        child.GetComponentInChildren<Text>().text = questions[nbQuestionRepondu].question; // on lui met la question
                        break;
                    case "0": // si c'est égale à "0"
                        child.GetComponentInChildren<Text>().text = questions[nbQuestionRepondu].answers[0]; // on lui met le titre de la premiere bouton
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    case "1": // si c'est égale à "1"
                        child.GetComponentInChildren<Text>().text = questions[nbQuestionRepondu].answers[1]; // on lui met le titre de la seconde bouton
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    case "2": // si c'est égale à "2"
                        child.GetComponentInChildren<Text>().text = questions[nbQuestionRepondu].answers[2]; // on lui met le titre de la troisième bouton
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void VerifAnswer()
    {
        StartCoroutine(MyCoroutine()); // on lance la fonction de vérification
    }

    IEnumerator MyCoroutine()
    {
        questions[nbQuestionRepondu].SetVerification(); // lance la vérification de la question

        yield return new WaitForSeconds(2); // on fait une pause de 2 seconde

        nbQuestionRepondu++; // on incrémente le nombre de question répondu

        Partie.ToogleVisibility(); // on cache l'affiche
    }

    // fonction qui affiche ou cache l'affiche
    public static void ToogleVisibility()
    {
        if (affiche != null) // on vérifie qu'affiche n'est pas null
        {
            if (affiche.enabled) // si l'affiche est visible
                affiche.enabled = false; // alors on la cache
            else
                affiche.enabled = true; // sinon on l'affiche

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateQuestions(); // lancer la fonction pour générer les questions
        GenerateToggle(); // lancer la fonction pour générer l'affiche
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
