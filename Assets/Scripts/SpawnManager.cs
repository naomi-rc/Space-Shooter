using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private Vector3 _enemyPosition;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {        
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
            float randomHorizontal = Random.Range(Enemy.LEFT_BOUND, Enemy.RIGHT_BOUND);
            _enemyPosition = new Vector3(randomHorizontal, Enemy.STARTING_HEIGHT, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, _enemyPosition, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(5);
        }
    }
}
