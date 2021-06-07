using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    [RequireComponent (typeof(PlayerController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 5f;
        PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }
        void Start()
        {
        
        }

        void Update()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            Vector3 movementVelocity = movement.normalized * movementSpeed;

            playerController.Move(movementVelocity);
        }
    }
}
