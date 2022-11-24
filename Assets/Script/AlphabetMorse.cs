using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class AlphabetMorse : MonoBehaviour
{
	public AudioClip dotSound;
	public AudioClip dashSound;
	public float spaceDelay;
	public float letterDelay;

	// International Morse Code Alphabet
	private string[] alphabet = 
    //A     B       C       D      E    F       G
	{".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
    //H       I     J       K      L       M     N
	 "....", "..", ".---", "-.-", ".-..", "--", "-.", 
	//O      P       Q       R      S      T    U
	 "---", ".--.", "--.-", ".-.", "...", "-", "..-",
	//V       W      X       Y       Z
	 "...-", ".--", "-..-", "-.--", "--..",
	//0        1        2        3        4        
	 "-----", ".----", "..---", "...--", "....-", 
	//5        6        7        8        9     
	 ".....", "-....", "--...", "---..", "----."};

	// Start is called before the first frame update
	void Start()
    {
		// H   E  L    L   O       W  O    R   L   D
		//.... . .-.. .-.. ---    .-- --- .-. .-.. -..
		PlayMorseCodeMessage("Hello World.");
	}

	public void PlayMorseCodeMessage(string message)
	{
		StartCoroutine("_PlayMorseCodeMessage", message);
	}
	private IEnumerator _PlayMorseCodeMessage(string message)
	{
		// Remove all characters that are not supported by Morse code...
		Regex regex = new Regex("[^A-z0-9 ]");
		message = regex.Replace(message.ToUpper(), "");

		// Convert the message into Morse code audio... 
		foreach (char letter in message)
		{
			if (letter == ' ')
				yield return new WaitForSeconds(spaceDelay);
			else
			{
				int index = letter - 'A';
				if (index < 0)
					index = letter - '0' + 26;
				string letterCode = alphabet[index];
				foreach (char bit in letterCode)
				{
					// Dot or Dash?
					AudioClip sound = dotSound;
					if (bit == '-') sound = dashSound;

					// Play the audio clip and wait for it to end before playing the next one.
					GetComponent<AudioSource>().PlayOneShot(sound);
					yield return new WaitForSeconds(sound.length + letterDelay);
				}
			}
		}
	}
}
