using UnityEngine;

namespace BigBangStudio.Utilities
{
    public class ObjectRotator : MonoBehaviour
    {
        // the speed of the rotation
        public float speed = 100.0f;

        // setup the possible rotation states
        public enum whichWayToRotate { AroundX, AroundY, AroundZ }

        public bool isDiscreteAnimation;

        // set the direction of the rotation
        public whichWayToRotate way = whichWayToRotate.AroundX;

        public bool stopRotating;
        
        void Update()
        {
            if(stopRotating)
                return;
            // do the appropriate rotation based on the way state
            switch (way)
            {
                case whichWayToRotate.AroundX:
                    transform.Rotate(Vector3.right * (Time.deltaTime * speed));
                    break;
                case whichWayToRotate.AroundY:
                    transform.Rotate(Vector3.up * (Time.deltaTime * speed));
                    break;
                case whichWayToRotate.AroundZ:
                    transform.Rotate(Vector3.forward * (Time.deltaTime * speed));
                    break;
            }
        }
        
        public void StopRotating()
        {
            stopRotating = true;
        }
    }
}

