using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 pos;

    private Circle_Skill_Fire coalSkill;
    private Circle_Skill_Fire gunpowerSkill;
    private Box_Skill_Fire oilSkill;
    private Circle_Skill_Fire_2 oxygenSkill;
    private void Awake()
    {
        coalSkill = GameObject.FindGameObjectWithTag("CoalSkill").GetComponent<Circle_Skill_Fire>();
        gunpowerSkill = GameObject.FindGameObjectWithTag("GunPowderSkill").GetComponent<Circle_Skill_Fire>();
        oilSkill = GameObject.FindGameObjectWithTag("OilSkill").GetComponent<Box_Skill_Fire>();
        oxygenSkill = GameObject.FindGameObjectWithTag("OxygenSkill").GetComponent<Circle_Skill_Fire_2>();
    }
    void Update()
    {
        Move();
        MovementLimitation();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // 휴대폰 기울기 이동
        Vector3 direction = Vector3.zero;
        direction.x = Input.acceleration.x * speed;
        direction.y = (Input.acceleration.y + 0.3f) * speed;
        transform.Translate(direction * speed * DataCenter.instance.gameData.sensitivity * Time.deltaTime);
    }
    
    private void MovementLimitation()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        else if (pos.x > 1f) pos.x = 1f;
        else if (pos.y < 0.08f) pos.y = 0.08f;
        else if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public void Die()
    {
        coalSkill.Remove();
        gunpowerSkill.Remove();
        oilSkill.Remove();
        oxygenSkill.Remove();
        gameObject.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coal"))
        {
            coalSkill.Fire();
        }
        if (other.CompareTag("GunPowder"))
        {
            gunpowerSkill.Fire();
        }
        if (other.CompareTag("Oil"))
        {
            oilSkill.Fire();
        }
        if (other.CompareTag("Oxygen"))
        {
            oxygenSkill.Fire();
        }
    }
}
