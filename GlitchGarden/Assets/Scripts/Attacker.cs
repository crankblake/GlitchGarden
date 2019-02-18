using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject  currentTarget;
    Animator animator;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
        /*
        if (health.GetHP() <= 0)
        {
            StopAttack();
        }*/
    }
    public void Attack(GameObject target)
    {
        //Debug.Log("Attacking...");
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }
    /*
    public void Jump()
    {
        Debug.Log("Jumping...");
        animator.SetTrigger("jumpTrigger");
    }
    public void StopAttack()
    {
        Debug.Log("Stopping attack...");
        animator.SetBool("isAttacking", false);
    }*/
}
