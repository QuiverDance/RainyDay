using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Move : MonoBehaviour
{
    private GameObject player;
    private Vector2 direction = new Vector2(0, 0);
    private Vector2 pos,r_pos;
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
        direction.x = player.transform.position.x - transform.position.x;
        direction.y = player.transform.position.y - transform.position.y;
        direction.Normalize();
    }
    void Update()
    {
        MoveReflect();
        r_pos = transform.position;
        r_pos = r_pos + direction * speed * Time.deltaTime;
        transform.position = r_pos;
    }

    private void MoveReflect()
    {
        pos = transform.position;
        pos = camera.WorldToViewportPoint(pos);

       if(pos.x < 0f)
        {
            if (Vector2.Dot(direction, Vector2.right) < 0)
            {
                direction = Vector2.Reflect(direction, Vector2.right);
            }
        }
       else if(pos.x >= 1f)
        {
            if (Vector2.Dot(direction, Vector2.left) < 0)
            {
                direction = Vector2.Reflect(direction, Vector2.left);
            }
        }
        else if (pos.y <= 0f)
        {
            if (Vector2.Dot(direction, Vector2.up) < 0)
            {
                direction = Vector2.Reflect(direction, Vector2.up);
            }
        }
        else if (pos.y >= 1f)
        {
            if (Vector2.Dot(direction, Vector2.down) < 0)
            {
                direction = Vector2.Reflect(direction, Vector2.down);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            circleCollider2D.enabled = false;
        }
    }
} 
