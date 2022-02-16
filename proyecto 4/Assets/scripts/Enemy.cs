using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    [SerializeField] private float speed = 10f;
    private float minHeight = -5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Variable consigue rigidbody del enemigo
        enemyRigidbody = GetComponent<Rigidbody>();
       //para que variable encuentre al player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(direction * speed);
        if (transform.position.y < minHeight)
        {
            Destroy(gameObject);
        }
    }
}
