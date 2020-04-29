using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    Random random;
    // Start is called before the first frame update
    void Start()
    {
        random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalPosition = 
        //transform.position = new Vector3(horizontalPosition, verticalPosition, 0);
    }
}
