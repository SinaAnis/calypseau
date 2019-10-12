using UnityEngine;
using UnityEditor;

public class Question
{
    public string question;
    public string[] answers;
    public int goodAnswer;

    public Question()
    {

    }

    public Question(string quest,string[] ans, int goodAns)
    {
        this.question = quest;
        this.answers = ans;
        this.goodAnswer = goodAns;
    }
}