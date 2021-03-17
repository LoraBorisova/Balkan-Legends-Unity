using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    idle,
    attack,
    walk, 
    stagger
}

public class Enemy : MonoBehaviour
{

    public enemyState currState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseattack;
    public float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth.initValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDmg(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float dmg)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDmg(dmg);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currState = enemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

}
