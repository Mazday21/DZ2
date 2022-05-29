using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class EnemySpawn : MonoBehaviour
{
    private Component[] _spawnPoints;

    public GameObject Enemy;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren(typeof(Transform));
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitFor2Seconds = new WaitForSeconds(2f);

        foreach (var point in _spawnPoints)
        {
            Transform pointPosition = point.GetComponent<Transform>();
            Instantiate(Enemy, pointPosition.position, Quaternion.identity);
            yield return waitFor2Seconds;
        }
    }
}
