using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class ShootingEnemy : MonoBehaviour
    {
        public Projectile projectilePrefab;
        bool isfiring = false;
        public int fireRate;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && isfiring == false)
            {
                StartCoroutine(Fire(other));
            }
        }

        IEnumerator Fire(Collider2D other)
        {
            isfiring = true;
            yield return new WaitForSeconds(0.5f);
            Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>();
            projectile.Init(other.gameObject);
            yield return new WaitForSeconds(fireRate);
            isfiring = false;
        }
    }
}
