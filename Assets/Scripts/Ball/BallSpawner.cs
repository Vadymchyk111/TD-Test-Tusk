using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private List<ObjectPool> _objectPools;

    private int _counter;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        StartSpawning();
    }
    
    private IEnumerator SpawnBallCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float screenWidth = Screen.width;
            float randomX = Random.Range(0, screenWidth);
            Vector3 screenPosition = new Vector3(randomX, Screen.height, Camera.main.nearClipPlane);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Vector3 spawnPosition = new Vector3(worldPosition.x, 5, 0);
            if (_counter == 5)
            {
                _objectPools[Random.Range(1,4)].GetBall().transform.position = spawnPosition;
                _counter = 0;
                continue;
            }
            _objectPools[0].GetBall().transform.position = spawnPosition;
            _counter++;
        }
    }
    
    public void StartSpawning()
    {
        if (_spawnCoroutine is not null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(nameof(SpawnBallCoroutine));
    }

    public void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
        foreach (Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(false);
        }
    }
}