using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //float speedOfSpin = 360f;
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 100;
    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
      transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
      //transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("I hit: " + otherCollider.name);
        var health = otherCollider.gameObject.GetComponent<Health>();
        var attacker = otherCollider.gameObject.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
        //Projectile projectile = otherCollider.gameObject.GetComponent<Projectile>();
        //if (!projectile) { return; }
        //ProcessHit(projectile);
    }
}
