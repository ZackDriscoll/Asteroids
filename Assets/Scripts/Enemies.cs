using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Transform tf;

    public float movementSpeed = 1.0f;
    public float rotationSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Adjust rotation every update for heat seeking behavior
        //Want the enemy to always fly forward
        tf.position += tf.right * movementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }
}
