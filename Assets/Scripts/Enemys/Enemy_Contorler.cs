using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Contorler : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public int health;
    public Transform Sprite;
    public Animator animator;
    private Vector3 movement;
    private Vector3 prevPos;
    public GameObject player;
    private IEnumerator coroutine;

    private void Awake()
    {
        prevPos = transform.position;
    }

    protected void Move()
    {
        if (target == null)
        {
            target = HealthSystem.instance.gameObject.transform;
        }
        movement = prevPos - transform.position;
        movement = Vector3.Normalize(movement);
        Debug.Log(movement);
        if(Mathf.Abs(movement.x) < Mathf.Abs(movement.y))
        {
            animator.SetFloat("vertical speed",  movement.y);
            animator.SetFloat("horizontal speed", 0f);
        }
        else
        {
            animator.SetFloat("horizontal speed", movement.x);
            animator.SetFloat("vertical speed",  0f);
        }
        agent.destination = target.position;
        Sprite.position = this.gameObject.transform.position;
        prevPos = transform.position;
    }
    public void Damage(int damage)
    {
        this.health -= damage;
        coroutine = SchowHit(0.2f);
        StartCoroutine(coroutine);

        if (health < 0)
        {
          
            Globals.currentScore += 50;
            
            Destroy(this.transform.parent.gameObject);
        }
    }
    private IEnumerator SchowHit(float waitTime)
    {
            this.Sprite.gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1);
            yield return new WaitForSeconds(waitTime);
            this.Sprite.gameObject.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
    }

}
