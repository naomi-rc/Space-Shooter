using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private const float LEFT_BOUND = -11.3f;
    private const float RIGHT_BOUND = 11.3f;
    private const float UPPER_BOUND = 0;
    private const float LOWER_BOUND = -3.8f;

    // Start is called before the first frame update
    void Start()
    {
        //take current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame (60 frames per second)
    void Update()
    {
        CalculateMovement();

    }

    void CalculateMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right); //1 unity unit = 1 meter so this is moving 60m/s
        //transform.Translate(Vector3.right * horizontalInput* _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        //if player position on y > 0, y position = 0
        //else if position on y < -3.8f, y position = -3.8f
       /* if (transform.position.y >= UPPER_BOUND)
        {
            transform.position = new Vector3(transform.position.x, UPPER_BOUND, 0);
        }
        else if (transform.position.y <= LOWER_BOUND)
        {
            transform.position = new Vector3(transform.position.x, LOWER_BOUND, 0);
        }*/

        //clamp position instead of else-if 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LOWER_BOUND, UPPER_BOUND), 0);

        //if player position on x <= LEFT_BOUND, x position = RIGHT_BOUND
        //else if player position on x >= RIGHT_BOUND, x position = LEFT_BOUND
        if (transform.position.x <= LEFT_BOUND)
        {
            transform.position = new Vector3(RIGHT_BOUND, transform.position.y, 0);
        }
        else if (transform.position.x >= RIGHT_BOUND)
        {
            transform.position = new Vector3(LEFT_BOUND, transform.position.y, 0);
        }
    } 
}
