using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShowQuestion : MonoBehaviour
{

    void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject tempObject = GameObject.Find("Question"); // On récupère l'objet qui affiche la question
        if (tempObject != null) // On vérifie qu'il n'est pas nul pour ne pas avoir de crash
        {
            Canvas EscCan = tempObject.GetComponent<Canvas>(); // on récupère ensuite son affichage (Canvas)

            if (EscCan != null) // On vérifie qu'il n'est pas null pour ne pas avoir de crash
            {
               EscCan.enabled = true; // On l'affiche
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject tempObject = GameObject.Find("Question"); // On récupère l'objet qui affiche la question
        if (tempObject != null) // On vérifie qu'il n'est pas nul pour ne pas avoir de crash
        {
            Canvas EscCan = tempObject.GetComponent<Canvas>(); // on récupère ensuite son affichage (Canvas)

            if (EscCan != null) // On vérifie qu'il n'est pas null pour ne pas avoir de crash
            {
                EscCan.enabled = false;  // On le cache
            }
        }
    }

    void Update()
    {
       
    }
}
