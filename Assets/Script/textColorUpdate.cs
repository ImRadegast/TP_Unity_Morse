using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textColorUpdate : MonoBehaviour
{
    [SerializeField] private Text txtWritten;
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color ValidateColor = Color.cyan;
    [SerializeField] private GameObject Entity;
    private Text textValide;
    private Text textRemaining;
    // Start is called before the first frame update


  
    
    public void UpdateColor()
    {
        //Parcour touts les Enfants de child
        for (int i = 0; i < Entity.transform.childCount; i++)
        {
            GameObject theHorseChild = Entity.transform.GetChild(i).transform.Find("text").gameObject;

            string text = theHorseChild.GetComponent<TextMeshPro>().text;

            // Comment fire la correctin de caractere ?
            // achaque espace supprimer la partit ecrite et l'ecrire dans un text mesh au dessus ?
           


            if (text == txtWritten.text)
            {
                GameObject parent = Entity.transform.GetChild(i).gameObject;
                Destroy(parent);
            }
        }
    }
}
