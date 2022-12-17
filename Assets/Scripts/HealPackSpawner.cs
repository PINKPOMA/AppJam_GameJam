using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealPackSpawner : MonoBehaviour
{
  [SerializeField] private GameObject healPack;
  private void Start()
  {
    StartCoroutine(SpawnItem());
  }

  IEnumerator SpawnItem()
  {
    Instantiate(healPack, new Vector3(Random.Range(-27f, 29f), Random.Range(-27f, 27)), quaternion.identity);
    yield return new WaitForSeconds(Random.Range(10f, 30f));
    StartCoroutine(SpawnItem());
  }
}
