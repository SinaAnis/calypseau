using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Epreuve : MonoBehaviour
{
    public Partie partie;
    public GameObject monstre;
    public GameObject passage;

    public string question; // question
    public string[] answers = new string[3]; // tableau regroupant les réponses
    public int goodAnswer; // index de la bonne réponse 

    private bool answered = false;
    private Canvas canvasQuestion;

    void Start()
    {
        canvasQuestion = GameObject.Find("Question").GetComponent<Canvas>();
        canvasQuestion.enabled = false; // on cache cette affiche
  
        Transform[] ts = GameObject.Find("Question").GetComponentsInChildren<Transform>(); // on récupère tous les elements enfant de l'affiche

        foreach (Transform child in ts) // pour chaque element enfant
        {
            switch (child.name) // on compare son nom
            {
                case "Title": // si c'est égale à "Title"
                    child.GetComponentInChildren<Text>().text = question; // on lui met la question
                    break;
                case "0": // si c'est égale à "0"
                    child.GetComponentInChildren<Text>().text = answers[0]; // on lui met le titre du premier bouton
                    child.GetComponent<Image>().color = Color.white;
                    break;
                case "1": // si c'est égale à "1"
                    child.GetComponentInChildren<Text>().text = answers[1]; // on lui met le titre du second bouton
                    child.GetComponent<Image>().color = Color.white;
                    break;
                case "2": // si c'est égale à "2"
                    child.GetComponentInChildren<Text>().text = answers[2]; // on lui met le titre du troisième bouton
                    child.GetComponent<Image>().color = Color.white;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canvasQuestion.enabled = true; // On l'affiche   
    }

    private void OnTriggerExit(Collider other)
    {
        canvasQuestion.enabled = false;  // On le cache
    }


    // méthode pour vérifier qui lance la vérification d'une réponse
    public void VerifAnswer()
    {
        StartCoroutine(CoroutineVerification()); // on lance la fonction de vérification
    }

    // méthode qui permet de verifier la réponse avec une pause de 2 secondes
    IEnumerator CoroutineVerification()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // on récupère le bouton qui à été préssé

        int num = int.Parse(obj.name); // on récupère le nom de ce bouton (0,1 ou 2)

        if (num == goodAnswer) // on compare ce numéro au numéro bonne réponse de la question
        {
            obj.GetComponent<Image>().color = Color.green; // on change la couleur du bouton en vert 
            yield return new WaitForSeconds(2);
        }
        else
        {
            obj.GetComponent<Image>().color = Color.red; // on change la couleur du bouton en rouge
            yield return new WaitForSeconds(2);  // on fait une pause de 2 seconde
            Partie.nbErreur++; // on incrémente le nbErreur de la partie
            Partie.addWater();
        }

        answered = true;

        Partie.nbQuestionRepondu++; // on incrémente le nombre de question répondu

        canvasQuestion.enabled = false; // on cache l'affiche
    }

    // fonction qui affiche ou cache l'affiche
    void ToogleVisibility()
    {
        if (canvasQuestion.enabled) // si l'affiche est visible
            canvasQuestion.enabled = false; // alors on la cache
        else
            canvasQuestion.enabled = true; // sinon on l'affiche
    }

    void Update()
    {
        if (answered)
        {
            
            passage.GetComponent<MeshFilter>().mesh = partie.meshPorte;

            passage.GetComponent<MeshRenderer>().material = partie.materialPorte;

            monstre.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
    }
}
