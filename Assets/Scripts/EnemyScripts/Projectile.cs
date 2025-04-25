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
 
        public void Init(GameObject target)
        {
            this.target = target;
        }
        // Update is called once per frame
        void Update()
        {
            Vector2 directionVector = (target.transform.position - transform.position).normalized;

            rigidbody.velocity = directionVector;
        }
        //For later use:
        //
        // transform.position = Vector2.Lerp(transform.position, player.transform.position, 0.001f);
    }
}
