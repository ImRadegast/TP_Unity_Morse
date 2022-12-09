using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textColorUpdate : MonoBehaviour
{
     public Text m_TextMeshPro;
     private Color baseColor = Color.white;
     private Color ValidateColor = Color.cyan;
     private GameObject Entity;
    // Start is called before the first frame update


    public void UpdateStart()
    {
        if(m_TextMeshPro != null && Entity != null)
        {
            UpdateColor(m_TextMeshPro, baseColor, ValidateColor, Entity);
        }
    }
    public void UpdateColor(Text m_TextMeshPro, Color baseColor, Color ValidateColor, GameObject Entity)
    {
        

        //Parcour touts les Enfants de child
        for (int i = 0; i < Entity.transform.childCount; i++)
        {
            GameObject theHorseChild = Entity.transform.GetChild(i).transform.Find("text").gameObject;
          
            string text = theHorseChild.GetComponent<TextMeshPro>().text;

            // Comment fire la correctin de caractere ?
            // achaque espace supprimer la partit ecrite et l'ecrire dans un text mesh au dessus ?
            Console.WriteLine(i + "/" + Entity.transform.childCount);
            
        }
       
    }

}
