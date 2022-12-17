using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monster;
    private void Start()
    {
        StartCoroutine(CreateMonsters());
    }

    IEnumerator CreateMonsters()
    {
        Instantiate(monster[Random.Range(0,3)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1.25f,3f));
        StartCoroutine(CreateMonsters());
    }

}
