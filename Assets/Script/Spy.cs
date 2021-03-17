using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : Enemy
{

    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currState = enemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position)
            > attackRadius)
        {
            if (currState == enemyState.idle || currState == enemyState.walk && currState != enemyState.stagger)
            {
                Vector3 move = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnimation(move - transform.position);
                myRigidbody.MovePosition(move);
                ChangeState(enemyState.walk);
                anim.SetBool("walk", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        { 
            anim.SetBool("walk", false);
        }
    }

    private void setAnimationFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {

            if(direction.x > 0)
            {
                setAnimationFloat(Vector2.right);
            }else if(direction.x < 0)
            {
                setAnimationFloat(Vector2.left);
            }

        }else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {

            if(direction.y > 0)
            {
                setAnimationFloat(Vector2.up);
            }
            else if(direction.y < 0)
            {
                setAnimationFloat(Vector2.down);
            }

        }
    }

    private void ChangeState(enemyState newState)
    {
        if(currState != newState)
        {
            currState = newState;
        }
    }
}
