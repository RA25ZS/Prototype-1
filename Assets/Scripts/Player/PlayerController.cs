using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        Rigidbody playerRb;
        Vector3 velocity;
        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void LookAt(Vector3 lookPos)
        {
            Vector3 heightPoint = new Vector3(lookPos.x, transform.position.y, lookPos.z);
            transform.LookAt(heightPoint);
        }

        public void Move(Vector3 _velocity)
        {
            velocity = _velocity;
        }

        public void FixedUpdate()
        {
            playerRb.MovePosition(playerRb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
