using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private GameObject player;
    private Vector2 direction = new Vector2(0, 0);
    private Vector2 pos, r_pos;
    public float speed = 2.5f;

    private new Camera camera;
    private CircleCollider2D circleCollider2D;
    void Awake()
    {
        player = GameObject.Find("Player");
        direction.x = player.transform.position.x - transform.position.x;
        direction.y = player.transform.position.y - transform.position.y;
        direction.Normalize();
        camera = Camera.main;
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    
    private void OnEnable()
    {
        Debug.Log(player.transform.position);
        direction.x = player.transform.position.x - transform.position.x;
        direction.y = player.transform.position.y - transform.position.y - 0.2f;
        direction.Normalize();
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        MovementLimitation();
    }

    private void MovementLimitation()
    {
        pos = camera.WorldToViewportPoint(transform.position);

        if (pos.x < -0.1f || pos.x > 1.1f || pos.y < -0.1f)
        {
            circleCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            circleCollider2D.enabled = false;
            other.GetComponent<Player_Move>().Die();
        }
        if(other.CompareTag("Fire"))
        {
            circleCollider2D.enabled = false;
        }
    }
} 
