using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    private Vector3 direction;
    private float _upperBound = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y >= _upperBound)
        {
            Destroy(this.gameObject);
        }
    }
}
