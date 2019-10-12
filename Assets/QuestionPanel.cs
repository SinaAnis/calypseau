using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestionPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas EscCan;
    public GameObject tempObject;
    public List<Question> questions = new List<Question>();
    public int questionEnCours = 0;

    public void ToogleVisibility()
    {
        if (EscCan != null)
        {
            if (EscCan.enabled)
                EscCan.enabled = false;
            else
                EscCan.enabled = true;

        }
    }

    public void GenerateQuestions()
    {
        questions.Add(new Question("Question 1 : Quelle jours sommes nous ?", new string[] { "Lundi", "Mardi", "Mercredi" },1));
        questions.Add(new Question("Question 2 : Qui est tu ?", new string[] { "Moi", "Toi", "Vous" }, 0));
    }

    public void SetQuestion()
    { 

        if (questionEnCours < questions.Count)
        {
            Transform[] ts = tempObject.GetComponentsInChildren<Transform>();

            foreach (Transform child in ts)
            {
                switch (child.name)
                {
                    case "Title":
                        child.GetComponentInChildren<Text>().text = questions[questionEnCours].question;
                        break;
                    case "0":
                        child.GetComponentInChildren<Text>().text = questions[questionEnCours].answers[0];
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    case "1":
                        child.GetComponentInChildren<Text>().text = questions[questionEnCours].answers[1];
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    case "2":
                        child.GetComponentInChildren<Text>().text = questions[questionEnCours].answers[2];
                        child.GetComponent<Image>().color = Color.white;
                        break;
                    default:
                        break;
                }
            }
            
        } else
        {

            ToogleVisibility();
            questionEnCours = 0;
        }
        
    }

    IEnumerator MyCoroutine()
    {
        SetVerification();

        yield return new WaitForSeconds(3);

        questionEnCours++;
        SetQuestion();

    }

    public void SetVerification()
    {
        if (questionEnCours < questions.Count)
        {

            GameObject obj = EventSystem.current.currentSelectedGameObject;

            int num = int.Parse(obj.name);

            if (num == questions[questionEnCours].goodAnswer)
            {
                obj.GetComponent<Image>().color = Color.green;
            }
            else
            {
                obj.GetComponent<Image>().color = Color.red;
            }
        }
    }

    public void VerifAnswer()
    {

        StartCoroutine(MyCoroutine());

    }

    void Start()
    {
        tempObject = GameObject.Find("Question");
        if (tempObject != null)
        {
            EscCan = tempObject.GetComponent<Canvas>();
        }

        ToogleVisibility();
        GenerateQuestions();
        SetQuestion();

    }

    // Update is called once per frame
    void Update()
    {
        /*
             GameObject obj = EventSystem.current.currentSelectedGameObject;
             if (obj != null)
             {
                 obj.GetComponent<Image>().color = Color.white;
             }*/
    }
}
