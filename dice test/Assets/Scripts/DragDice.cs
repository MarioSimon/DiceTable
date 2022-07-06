using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Table.Dice
{
    public class DragDice : MonoBehaviour
    {

        public Vector3 mouseOffset;
        public Vector3 prevPos;
        private float mZCoord;
        Dice dice;
        Rigidbody rb;

        private void Start()
        {
            dice = GetComponent<Dice>();
            rb = GetComponent<Rigidbody>();
        }

        private Vector3 GetMouseWorldPos()
        {
            // 2d coordinates
            Vector3 mousePoint = Input.mousePosition;
            // z coordinate of game object on screen
            mousePoint.z = mZCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        // Start is called before the first frame update
        private void OnMouseDown()
        {
            //selected = true;
            //rb.useGravity = false;
            //prevPos = new Vector3(transform.position.x, 1, transform.position.y);
            //transform.position = prevPos;
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mouseOffset = gameObject.transform.position - GetMouseWorldPos();
            dice.Select();
            //selected = false;
        }

        private void OnMouseDrag()
        {
            prevPos = transform.position;
            transform.position = GetMouseWorldPos() + mouseOffset;
            
            //selected = true;
        }

        private void OnMouseUp()
        {
            if (prevPos.x < transform.position.x - 0.025)
            {
                rb.AddForce(new Vector3(400, 0, 0));
            }
            else if (prevPos.x > transform.position.x + 0.025)
            {
                rb.AddForce(new Vector3(-400, 0, 0));
            }

            if (prevPos.z < transform.position.z - 0.025)
            {
                rb.AddForce(new Vector3(0, 0, 400));
            }
            else if (prevPos.z > transform.position.z + 0.025)
            {
                rb.AddForce(new Vector3(0, 0, -400));
            }

            rb.AddForce(new Vector3(0, 50, 0));

            dice.Deselect();
        }
    }
}
