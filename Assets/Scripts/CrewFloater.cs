using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewFloater : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Sprite> sprites;

    private bool[] crewStates = new bool[Enum.GetValues(typeof(EPlayerColor)).Length];
    private float timer = 0.5f;
    private float distance = 11f;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, UnityEngine.Random.Range(0f, distance));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EPlayerColor)).Length), distance);
            timer = 1f;
        }
    }

    public void SpawnFloatingCrew(EPlayerColor playerColor, float dist)
    {
        if(!crewStates[(int)playerColor])
        {
            crewStates[(int)playerColor] = true;

            float angle = UnityEngine.Random.Range(0f, 360f);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * distance;
            Vector3 direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f);
            float floatingSpeed = UnityEngine.Random.Range(1f, 4f);
            float rotateSpeed = UnityEngine.Random.Range(-90f, 90f);

            var crew = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(sprites[UnityEngine.Random.Range(0, sprites.Count)], 
                playerColor, direction, floatingSpeed, rotateSpeed, UnityEngine.Random.Range(0.5f, 1f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var crew = collision.GetComponent<FloatingCrew>();
        if(crew != null)
        {
            crewStates[(int)crew.playerColor] = false;
            Destroy(crew.gameObject);
        }
    }
}
