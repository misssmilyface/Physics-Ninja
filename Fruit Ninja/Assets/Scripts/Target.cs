using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager; // calling out the GameManager script from Game Manager, and calling it gameManager.
    
    public ParticleSystem explosionParticle;
    public int pointValue;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);// targetRb.AddTorque(x, y, z, ForceMode.Impulse);
        //trying to make the object that's attached to this script turn randomly.

        transform.position = RandomSpawnPos();
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        // In the beginning, we need to say what gameManager does. gameManager finds a GameObject called "Game Manager" and get's it's component(script) called GameManager.
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
// we make these methods because we want to make it easier to read when reading the codes in Start().
// we don't put these in separate lines in Start() is because it'll just add more lines to the Start() method and that's not what we want. We want the Start() method to be as simple as possible.
    
    private void OnMouseDown() // when your mouse clicks on smth, it'll destroy the object.
    {
        if (gameManager.isGameActive) // when the game is active
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue); // Now that we called our GameManager script and made the UpdateScore() public, we can use it in our script to add 5 points (which is now pointValue) to the score every time we click on an object.
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        
    }
    
    private void OnTriggerEnter(Collider other) // the sensor has the "is trigger" box checked, so whenever our objects reach the sensor, they get destroyed.
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad")) // we put a tag on the skull(bad), so when one of the good ones touch the sensor, GameOver() method pops up to say Game Over.
        {
            gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);//not setting the z position because it's not moving forward or backward.
    }
}
