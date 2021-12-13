using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F500
{

    public class Controls : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        public float panSpeed = 20f;
        
        // Update is called once per frame
        private void FixedUpdate()
        {
            if ( Input.GetKey("d") )
            {
                transform.Rotate (Vector3.forward * -10);
            }
            
            if ( Input.GetKey("a") )
            {
                pos.x -= speed * Time.deltaTime;
                transform.Rotate (Vector3.forward * 10);
            }
            transform.position = pos;
        }
    }
}
