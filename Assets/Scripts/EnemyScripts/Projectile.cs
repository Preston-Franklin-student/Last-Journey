using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LastJourney
{
    public class Projectile : MonoBehaviour
    {
        public GameObject target;
        public Rigidbody2D rigidbody;
        public int speed;

        public void Init(GameObject target)
        {
            this.target = target;
            Vector2 directionVector = (target.transform.position - transform.position).normalized;
            rigidbody.velocity = directionVector * speed;
        }
        //For future use:
        //
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.001f);
    }
}
