using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class btnMorseOnClick : MonoBehaviour
{
    [SerializeField] private Text m_TextMeshPro;
    [SerializeField] private string shortText = "•";
    [SerializeField] private string longText = "-";
    [SerializeField] private string notText = null;


    public void ShortClick()
    {
        m_TextMeshPro.text += shortText;
    }
    public void LongClick()
    {
        m_TextMeshPro.text += longText;
    }
    public void NotPress()
    {
         m_TextMeshPro.text = notText;
        
    }
}

