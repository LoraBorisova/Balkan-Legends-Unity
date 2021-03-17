using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float dmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                
                Vector2 diff = hit.transform.position - transform.position;
                diff = diff.normalized * thrust;
                hit.AddForce(diff, ForceMode2D.Impulse);
                if (collision.gameObject.CompareTag("enemy") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currState = enemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, dmg);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }
}
