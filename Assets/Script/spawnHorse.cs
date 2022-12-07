using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHorse : MonoBehaviour
{
    public GameObject brownHorsePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(BrownHorseWave());
    }

    private void SpawnHorse ()
    {
        GameObject a = Instantiate(brownHorsePrefab) as GameObject;
        a.transform.position = new Vector2(-10, -3.5f);
    }

    IEnumerator BrownHorseWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnHorse();

        }
    }
}
