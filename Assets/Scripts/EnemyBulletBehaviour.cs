using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{ 
    [SerializeField]
    private float _speed = 11.0f;

    private Renderer m_renderer;
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        //Delete the game object when it's not visible
        if (m_renderer.isVisible)
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
        else if (!(m_renderer.isVisible))
        {
            Destroy(this.gameObject);
        }
    }
    //Check for the collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}