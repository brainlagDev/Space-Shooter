using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy2Behaviour : MonoBehaviour
{
    public int Health { get; private set; }
    private const float speed = 5.0f;
    public GameObject bulletPrefab;
    void Start()
    {
        //Setting up the variables
        Health = 2;
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Health >= 0)
        {
            //Movement
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            
        }
        else
        {
            //Manipulating Enemy after it dies
            GameManager.Instance.AddScore(50);
            Destroy(this.gameObject);
            GameManager.Instance.enemiesSpawned--;
        }
    }
    
    //Check for the collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
            GameManager.Instance.enemiesSpawned--;
        }
        else
        {
            Health--;
        }
    }

    //shooting routine
    IEnumerator Shoot()
    {
        while(Health > 0)
        {
            Instantiate(bulletPrefab, new Vector2(this.gameObject.transform.position.x -0.12f, this.gameObject.transform.position.y - 0.5f), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}