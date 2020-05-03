using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private Vector3 _enemyPosition;

    private const float LEFT_BOUND = -11.3f;
    private const float RIGHT_BOUND = 11.3f;
    private const float STARTING_HEIGHT = 6f;
    private const float LOWER_BOUND = -3.8f;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        float randomHorizontal = Random.Range(LEFT_BOUND, RIGHT_BOUND);
        _enemyPosition = new Vector3(randomHorizontal, STARTING_HEIGHT, 0);
        yield return StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn game objects every 5 seconds
    //create a coroutine of type IEnumerator using Yield Events
    //while loop - always create in coroutine and use yield
    IEnumerator SpawnRoutine()
    {
        //while loop
        //instantiate enemy prefab
        //yield wait for 5 seconds
        while (true)
        {
            _enemyPosition.x = Random.Range(LEFT_BOUND, RIGHT_BOUND);
            Instantiate(_enemyPrefab, _enemyPosition, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
