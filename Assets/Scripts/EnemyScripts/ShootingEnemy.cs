using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class ShootingEnemy : MonoBehaviour
    {
        public Projectile projectilePrefab;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>();
                projectile.Init(other.gameObject);
            }
        }
    }
}
