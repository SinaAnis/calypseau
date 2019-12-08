using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Epreuve : MonoBehaviour
{
    public Partie partie; // L'objet Partie pour gérer la partie
    public GameObject monstre; // l'objet monstre de l'epreuve
    public GameObject passage; // l'objet passage de l'epreuve

    public bool isImportantQuestion; // marqueur si c'est une question obligatoire ou non
    public string question; // question
    public string[] answers = new string[3]; // tableau regroupant les réponses
    public int goodAnswer; // index de la bonne réponse 

    private float currCountdownValue; // minuteur
    private bool alreadyAnswered = false; // verifier si la question n'est pas déja répondu
    private GameObject timerObject; // l'objet du minuteur

    private bool passed = false; //verifier si la question n'est pas déja lancé

    // fonction déclenché quand on entre dans la dalle
    private void OnTriggerEnter(Collider other)
    {
        if (alreadyAnswered)
            return;

        if (!passed) // condition pour ne pas initialiser à chaque fois que vous entrée dans la dalle
        {
            passed = true;

            partie.lastEpreuve = this;

            EventSystem.current.SetSelectedGameObject(null);

            Transform[] ts = partie.canvasQuestion.GetComponentsInChildren<Transform>(); 

            foreach (Transform child in ts) 
            {
                switch (child.name) // on compare son nom
                {
                    case "Title": // si c'est égale à "Title"
                        child.GetComponentInChildren<Text>().text = question; // on lui met la question
                        break;
                    case "0": // si c'est égale à "0"
                        child.GetComponentInChildren<Text>().text = answers[0]; // on lui met le titre du premier bouton
                        child.GetComponent<Image>().color = Color.white;
                        Button button0 = child.GetComponent<Button>();
                        ColorBlock cb0 = button0.colors;
                        cb0.normalColor = Color.black;
                        button0.colors = cb0;
                        break;
                    case "1": // si c'est égale à "1"
                        child.GetComponentInChildren<Text>().text = answers[1]; // on lui met le titre du second bouton
                        child.GetComponent<Image>().color = Color.white;
                        Button button1 = child.GetComponent<Button>();
                        ColorBlock cb1 = button1.colors;
                        cb1.normalColor = Color.black;
                        button1.colors = cb1;
                        break;
                    case "2": // si c'est égale à "2"
                        child.GetComponentInChildren<Text>().text = answers[2]; // on lui met le titre du troisième bouton
                        child.GetComponent<Image>().color = Color.white;
                        Button button2 = child.GetComponent<Button>();
                        ColorBlock cb2 = button2.colors;
                        cb2.normalColor = Color.black;
                        button2.colors = cb2;
                        break;
                    case "timer": // si c'est égale à "2"
                        timerObject = child.gameObject;
                        break;
                    default:
                        break;
                }
            }

            partie.canvasQuestion.enabled = true; 
            StartCoroutine(StartCountdown());
        }
       
    }

    // fonction si l'utilisateur sort de la dalle
    private void OnTriggerExit(Collider other)
    {
        //partie.canvasQuestion.enabled = false;  // On le cache
    }


    // fonction pour vérifier qui lance la vérification d'une réponse
    public void VerifAnswer()
    {
        StopAllCoroutines();
        StartCoroutine(CoroutineVerification()); // on lance la fonction de vérification

    }

    // fonction qui permet de verifier la réponse avec une pause de 2 secondes
    IEnumerator CoroutineVerification()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // on récupère le bouton qui à été préssé

        int num = int.Parse(obj.name); // on récupère le nom de ce bouton (0,1 ou 2)

        if (num == goodAnswer) // on compare ce numéro au numéro bonne réponse de la question
        {
            obj.GetComponent<Image>().color = Color.green; // on change la couleur du bouton en vert 
            yield return new WaitForSeconds(1);
            GoodAnswer();
        }
        else
        {
            obj.GetComponent<Image>().color = Color.red; // on change la couleur du bouton en rouge
            yield return new WaitForSeconds(1);  // on fait une pause de 2 seconde
            BadAnswer();
        }
        
        yield return new WaitForSeconds(2);

        monstre.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

        partie.canvasQuestion.enabled = false; // on cache l'affiche
    }

    // fonction qui lance le minuteur de l'epreuve
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0 )
        {
            timerObject.GetComponentInChildren<Text>().text = (currCountdownValue < 10) ? "0" + currCountdownValue : currCountdownValue.ToString();
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        // si l'utilisateur n'a pas répondu à la question après les 10 secondes

        BadAnswer();
          
        yield return new WaitForSeconds(3);

        monstre.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

        partie.canvasQuestion.enabled = false;
      
    }

    // fonction pour mauvaise réponse
    void BadAnswer() {

        Transform[] ts = partie.canvasQuestion.GetComponentsInChildren<Transform>(); // on récupère tous les elements enfant de l'affiche
        foreach (Transform child in ts) // pour chaque element enfant
        {
            switch (child.name) // on compare son nom
            {
               
                case "0": // si c'est égale à "0"
                    if (0 == goodAnswer)
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.green;
                        button.colors = cb;
                    }
                    else
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.red;
                        button.colors = cb;
                    }
                    break;
                case "1": // si c'est égale à "1"
                    if (1 == goodAnswer)
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.green;
                        button.colors = cb;
                    }
                    else
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.red;
                        button.colors = cb;
                    }
                    break;
                case "2": // si c'est égale à "2"
                    if (2 == goodAnswer)
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.green;
                        button.colors = cb;
                    }
                    else
                    {
                        Button button = child.GetComponent<Button>();
                        ColorBlock cb = button.colors;
                        cb.normalColor = Color.red;
                        button.colors = cb;
                    }
                    break;
                default:
                    break;
            }
        }

        if (isImportantQuestion)
        {
            Partie.nbErreur++; 

            Partie.addWater();

            Partie.nbQuestionRepondu++; 

            passage.GetComponent<MeshFilter>().mesh = partie.meshPorte;

            passage.GetComponent<MeshRenderer>().material = partie.materialPorte;

            if(passage.transform.parent.GetComponent<BoxCollider>() != null)
                passage.transform.parent.GetComponent<BoxCollider>().enabled = false;

        } else
        {
            partie.RemoveTime();
        }

        alreadyAnswered = true;


    }

    // fonction pour bonne réponse
    void GoodAnswer()
    {
        if (isImportantQuestion)
        {

            Partie.nbQuestionRepondu++; 

            passage.GetComponent<MeshFilter>().mesh = partie.meshPorte;

            passage.GetComponent<MeshRenderer>().material = partie.materialPorte;

            if (passage.transform.parent.GetComponent<BoxCollider>() != null)
            {
                passage.transform.parent.GetComponent<BoxCollider>().enabled = false;
            }

        }
        else
        {
            partie.AddTime();
        }

        alreadyAnswered = true;
    }

}
