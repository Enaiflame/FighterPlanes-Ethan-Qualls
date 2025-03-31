using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase isGameOver
    //4. value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 10.5f;
    private float lowScreenLimit = -3.5f;
    private float highScreenLimit = 0f;

    public GameObject bulletPrefab;
    void Start()
    {
        //This function is called at the start of the game
        playerSpeed = 6.0f;
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();
    }


    void Shooting()
    {
        //If the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player hits the bottom of the screen
        if(transform.position.y <= lowScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, lowScreenLimit, 0);
        }
        //Player hits the middle of the screen
        if(transform.position.y >= highScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, highScreenLimit, 0);
        }
    }
}
