using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    //Setting all the variables
    [SerializeField]
    private float _speed = 5.0f;
    public int Health { get; private set; }

    public Text healthText;
    public static int Score { get; private set; }
    private const float delay = 0.25f;
    private float _nextShot = 0.0f;
    public GameObject bulletPrefab;
    private int shootingMode = 1;
    void Start()
    {
        //Set the health(will change after the upgrade is bought)
        Health = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Display text
        healthText.text = "HEALTH -  " + Health;

        //Destroy player when the health is 0
        if (Health < 1)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        //Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput, 0) * _speed * Time.deltaTime);

        //Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(0, verticalInput) * _speed * Time.deltaTime);

        //Block the player to go off the screen
        if (transform.position.x >= 12f)
            transform.position = new Vector2(12f, transform.position.y);
        else if (transform.position.x <= -12f)
            transform.position = new Vector2(-12f, transform.position.y);
        else if (transform.position.y <= -6.2f)
            transform.position = new Vector2(transform.position.x, -6.2f);

        //Shooting
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextShot)
        {
            switch (shootingMode)
            {
                case 1:
                    _nextShot = Time.time + delay;
                    Instantiate(bulletPrefab, new Vector2(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y), Quaternion.identity);
                    break;
                case 2:
                    _nextShot = Time.time + delay;
                    Instantiate(bulletPrefab, new Vector2(this.gameObject.transform.position.x - 1f, this.gameObject.transform.position.y-0.2f), Quaternion.identity);
                    Instantiate(bulletPrefab, new Vector2(this.gameObject.transform.position.x + .1f, this.gameObject.transform.position.y-.2f), Quaternion.identity);
                    break;
            }
        }
    }
   
    //Checking for the collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health--;
        }
        if (collision.gameObject.tag == "PowerUp")
        {
            shootingMode = 2;
        }
    }
}
