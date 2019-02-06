using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] float speedOfSpin = 200f;
    [SerializeField] float projectileSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    private void MoveProjectile()
    {
      transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }
}
