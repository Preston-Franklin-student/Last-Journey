using System.Collections;
using System.Collections.Generic;
using LastJourney;
using UnityEngine;

namespace LastJourney
{
    public class ShootingEnemy2 : MonoBehaviour
    {
        public Projectile projectilePrefab;
        public float fireRate;
        public int decreaseTime;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            while (true)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                projectile.Init();
                yield return new WaitForSeconds(fireRate);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
        }
    }

}