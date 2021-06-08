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
        Camera mainCamera;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }
        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            MovePlayer();
            FollowMousePos();
        }

        private void FollowMousePos()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                playerController.LookAt(point);
            }
        }

        private void MovePlayer()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            Vector3 movementVelocity = movement.normalized * movementSpeed;

            playerController.Move(movementVelocity);
        }
    }
}
