using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouger : MonoBehaviour
{

    private Animator animator; // gestionnaire d'animation

    void Start()
    {
        animator = GetComponent<Animator>(); // récupérer l'animator de l'objet

        animator.Play("idle"); // jouer l'animation statique
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) // en appuyant sur la touche Z
        {
            transform.Translate(0, 0, 0.07f); // avancer
            animator.Play("walk"); // jouer l'animation marcher
        }
        if (Input.GetKey(KeyCode.Q)) // en appuyant sur la touche Q
        {
            transform.Rotate(0, -2, 0); // tourner à gauche
        }
        if (Input.GetKey(KeyCode.S)) // en appuyant sur la touche S
        {
            transform.Translate(0, 0, -0.07f); // reculer
            animator.Play("walk"); // jouer l'animation marcher
        }
        if (Input.GetKey(KeyCode.D)) // en appuyant sur la touche D
        {
            transform.Rotate(0, 2, 0); // tourner à droite
        } 
    }
}
