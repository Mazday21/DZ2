using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private Component[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren(typeof(Transform));
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(2f);

        foreach (var point in _spawnPoints)
        {
            Instantiate(_enemy, point.transform.position, Quaternion.identity);
            yield return wait;
        }
    }
}