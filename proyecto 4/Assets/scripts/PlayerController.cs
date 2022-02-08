using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10f;
    private GameObject focalPoint;
    public GameObject powerup;
    private bool hasPowerUp;
    public GameObject[] powerUpIndicator;
    private float powerUpForce = 15f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);

    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Powerup")) 
        {
            hasPowerUp = true;
            StartCoroutine(PowerUpCountDown());
            Destroy(otherCollider.gameObject);
        
        
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (hasPowerUp)
        {
            Rigidbody enemyRigidbody = otherCollider.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (otherCollider.gameObject.transform.position - transform.position).normalized;
            //Hacer que el enemigo salga volando
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }

        
    }
    private IEnumerator PowerUpCountDown()
    {
        for (int i = 0; i< powerUpIndicator.Length; i++)
        {
            powerUpIndicator[i].SetActive(true);
                yield return new WaitForSeconds(2);
            powerUpIndicator[i].SetActive(false);
        }
        yield return new WaitForSeconds(6);
        hasPowerUp = false;

    }
}
