using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class btnMorseOnClick : MonoBehaviour
{
    [SerializeField]
    public Text m_TextMeshPro;
    

    public void ShortClick()
    {
        m_TextMeshPro.text += "•";
    }
    public void LongClick()
    {
        m_TextMeshPro.text += "-";
    }
    public void NotPress()
    {
        if( !m_TextMeshPro.text.EndsWith(" "))
        {
            m_TextMeshPro.text += " ";
        }
    }
}

