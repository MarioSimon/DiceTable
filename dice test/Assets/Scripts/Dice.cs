using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Table.Dice
{

    enum diceType
    {
        d4 = 0,
        d6 = 1,
        d8 = 2,
        d10 = 3,
        pd = 4,
        d12 = 5,
        d20 = 6
    }
    public class Dice : MonoBehaviour
    {
        [SerializeField] private diceType type;
        private Rigidbody rb;
        private Vector3 startPos;
        //public Vector3 prevPos;
        bool selected;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            startPos = transform.position;
            selected = true;
        }


        private void Update()
        {
            if (Input.GetMouseButton(1) && selected)
            {
                ReleaseDice();
            }

            if (Input.GetMouseButton(2) && selected)
            {
                Destroy(this.gameObject);
            }
        }
        // Update is called once per frame
        void FixedUpdate()
        {

            if (selected)
            {
                rb.useGravity = false;

                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);

                rb.AddTorque(dirX, dirY, dirZ);
            }
            else
            {
                rb.useGravity = true;
            }
        }

        public bool IsStopped()
        {
            return (rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0);
        }

        public void Select()
        {
            selected = true;
        }

        public void Deselect()
        {
            selected = false;
        }

        public bool IsSelected()
        {
            return selected;
        }

        public void ResetPosition()
        {
            transform.position = startPos;
        }

        public int GetDiceTypeID()
        {
            switch (type)
            {
                case diceType.d4:
                    return 0;
                case diceType.d6:
                    return 1;
                case diceType.d8:
                    return 2;
                case diceType.d10:
                    return 3;
                case diceType.pd:
                    return 4;
                case diceType.d12:
                    return 5;
                case diceType.d20:
                    return 6;
                default:
                    return -1;
            }
        }

        private void ReleaseDice()
        {
            //if (prevPos.x < transform.position.x - 0.025)
            //{
            //    rb.AddForce(new Vector3(400, 0, 0));
            //}
            //else if (prevPos.x > transform.position.x + 0.025)
            //{
            //    rb.AddForce(new Vector3(-400, 0, 0));
            //}
            //
            //if (prevPos.z < transform.position.z - 0.025)
            //{
            //    rb.AddForce(new Vector3(0, 0, 400));
            //}
            //else if (prevPos.z > transform.position.z + 0.025)
            //{
            //    rb.AddForce(new Vector3(0, 0, -400));
            //}
            //transform.parent.parent.GetComponent<PlayerHand>().diceCount -= 1;
            GetComponentInParent<PlayerHand>().diceCount -= 1;
            transform.parent = null;
            rb.AddForce(new Vector3(0, 50, 0));

            Deselect();
        }

    }
}
