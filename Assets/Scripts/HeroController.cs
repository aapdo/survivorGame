using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class HeroController : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        private void FixedUpdate()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("direction", 3);
                spriteRenderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("direction", 2);
                spriteRenderer.flipX = true;

            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("direction", 1);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("direction", 0);
            }
            //Debug.Log(animator.GetInteger("direction"));
            //dir.Normalize();
            animator.SetBool("isMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
