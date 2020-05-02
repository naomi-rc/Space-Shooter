using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float LEFT_BOUND = -11.3f;
    private const float RIGHT_BOUND = 11.3f;
    private const float STARTING_HEIGHT = 6f;
    private const float LOWER_BOUND = -3.8f;
    private const string LASER_TAG = "Laser";
    private const string PLAYER_TAG = "Player";
    

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _speed = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= LOWER_BOUND)
        {
            float randomHorizontal = Random.Range(LEFT_BOUND, RIGHT_BOUND);
            transform.position = new Vector3(randomHorizontal, STARTING_HEIGHT, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            Player playerComponent = other.transform.GetComponent<Player>();
            if(playerComponent != null)
            {
                playerComponent.Damage();
            }
            Destroy(this.gameObject);
        }
        else if (other.CompareTag(LASER_TAG))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }   
    }
}
