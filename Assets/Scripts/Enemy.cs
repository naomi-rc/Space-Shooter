using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float LEFT_BOUND = -11.3f;
    private const float RIGHT_BOUND = 11.3f;
    private const float UPPER_BOUND = 0;
    private const float STARTING_HEIGHT = 6f;
    private const float LOWER_BOUND = -3.8f;
    private const string LASER_TAG = "Laser";
    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _speed = 4;

    Random random;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move enemy down 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //if botton of screen respawn at top with new random x position
        if(transform.position.y <= LOWER_BOUND)
        {
            float randomHorizontal = Random.Range(LEFT_BOUND, RIGHT_BOUND);
            transform.position = new Vector3(randomHorizontal, STARTING_HEIGHT, 0);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.transform.name);
        //if other is player, damage player and destroy this object 
        if (other.CompareTag(PLAYER_TAG))
        {
            //damager player

            Destroy(this.gameObject);
        }
        //if other is laser, destroy this object and destroy laser
        else if (other.CompareTag(LASER_TAG))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
            


    }
}
