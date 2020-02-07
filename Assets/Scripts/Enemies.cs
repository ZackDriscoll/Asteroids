using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Transform tf;

    public float movementSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        tf.position += tf.right * movementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D Player)
    {
        Destroy(Player.gameObject);
    }
}
