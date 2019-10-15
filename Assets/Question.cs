using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Question
{
    public string question; // question
    public string[] answers; // tableau regroupant les réponses
    public int goodAnswer; // index de la bonne réponse 

    // Constructeur pour initialiser une Question
    public Question(string quest,string[] ans, int goodAns)
    {
        this.question = quest;
        this.answers = ans;
        this.goodAnswer = goodAns;
    }

    // Methode pour verifier la réponse
    public void SetVerification()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject; // on récupère le bouton qui à été préssé

        int num = int.Parse(obj.name); // on récupère le nom de ce bouton (0,1 ou 2)

        if (num == goodAnswer) // on compare ce numéro au numéro bonne réponse de la question
        {
            obj.GetComponent<Image>().color = Color.green; // on change la couleur du bouton en vert 
        }
        else
        {
            obj.GetComponent<Image>().color = Color.red; // on change la couleur du bouton en rouge
            Partie.nbErreur++; // on incrémente le nbErreur de la partie
        }

    }

   

}