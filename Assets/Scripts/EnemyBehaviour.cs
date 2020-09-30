using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public int Health { get; private set; }
    private const float _speed = 7.0f;


    void Start()
    {
        Health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            //Movement
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
        else
        {
            //Destroy the obj when the health is 0
            GameManager.Instance.AddScore(20);
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
}
