using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHorse : MonoBehaviour
{
    [SerializeField] private GameObject[] HorsePrefab;
    [SerializeField] private GameObject[] spawnAnchor;

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
        //Choisis aléatoirement une couleur de cheval
        int randomHorseColor = Random.Range(0, HorsePrefab.Length);
        int randomSpawnAnchor = Random.Range(0, spawnAnchor.Length);
        
        GameObject a = Instantiate(HorsePrefab[randomHorseColor], spawnAnchor[randomSpawnAnchor].transform) as GameObject;
        
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
