using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private GameObject _laserPrefab;

    private const float LEFT_BOUND = -11.3f;
    private const float RIGHT_BOUND = 11.3f;
    private const float UPPER_BOUND = 0;
    private const float LOWER_BOUND = -3.8f;
    private Vector3 offset;
    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {        
        transform.position = new Vector3(0, 0, 0);
        offset = new Vector3(0, 0.8f, 0);
    }

    // Update is called once per frame (60 frames per second)
    void Update()
    {
        CalculateMovement();

        if (FirePressed() && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
       
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LOWER_BOUND, UPPER_BOUND), 0);

        if (transform.position.x <= LEFT_BOUND)
        {
            transform.position = new Vector3(RIGHT_BOUND, transform.position.y, 0);
        }
        else if (transform.position.x >= RIGHT_BOUND)
        {
            transform.position = new Vector3(LEFT_BOUND, transform.position.y, 0);
        }
    } 

    private void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
    }

    private bool FirePressed()
    {       
        return Input.GetKey(KeyCode.Space) || Input.GetAxis("Fire1") != 0 || Input.GetAxis("Fire2") != 0 || Input.GetAxis("Fire3") != 0;
    }
}
