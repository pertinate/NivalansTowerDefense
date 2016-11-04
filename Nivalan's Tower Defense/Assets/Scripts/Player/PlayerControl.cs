using UnityEngine;
using Pertinate.Utility;
using System.Collections;

namespace Pertinate.Player
{
    public class PlayerControl : MonoBehaviour
    {
        public float speed = 6.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;
        private CharacterController controller;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }
        private void FixedUpdate()
        {
            Vector3 moveDirection = CustomInput.moveVector;
            transform.Translate(moveDirection * Time.deltaTime * speed);
            /*// is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = transform.TransformDirection(moveDirection);
                //Multiply it by speed.
                moveDirection *= speed;

            }
            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            Debug.Log(moveDirection);
            //Making the character move
            controller.Move(moveDirection * Time.deltaTime);*/
        }
    }
}
