using UnityEngine;
using System.Collections;

namespace Script
{
    public class ApplicationStartup : MonoBehaviour
    {
        // Member variable
        public Vector3 center; // Center position
        public float radius = 5.0f; // Desired radius
        public float radiusSpeed = 0.1f; // Speed at which radius change
        public float radiusMin = 2.0f; // Minimum radius
        public float radiusMax = 20.0f; // Maximum radius
        public float rotationSpeed = 30.0f; // Degrees per seconds

        // Use this for initialzation system.
        void Awake() {
            center = new Vector3(0, 0, 0);
        }

        // Use this for initialization game object.
        void Start() {
            // Ensure the object starts at the correct radius
            Vector3 direction = (transform.position - center).normalized;
            transform.position = center + direction * radius;
        }

        // Update information and render view.
        void Update()
        {
            this.moveAround();
        }
        
        private void moveAround() {
            // Left/Right movement (W/S)
            if (Input.GetKey(KeyCode.W)) this.transform.RotateAround(center, transform.right, rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.S)) this.transform.RotateAround(center, -transform.right, rotationSpeed * Time.deltaTime);
            // Up/Down movement (A/D)
            if (Input.GetKey(KeyCode.A)) this.transform.RotateAround(center, transform.up, rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D)) this.transform.RotateAround(center, -transform.up, rotationSpeed * Time.deltaTime);
            // Forward/Backward movement (left Mouse/Right Mouse, Q/E)
            float isRadiusChange = Input.mouseScrollDelta.y;
            if (Input.GetKey(KeyCode.Q)) isRadiusChange = 1.0f;
            if (Input.GetKey(KeyCode.E)) isRadiusChange = -1.0f;
            if ( isRadiusChange != 0 ) {
                // Calculate new radius with input status.
                if (isRadiusChange > 0)
                    radius += radiusSpeed;
                else if (isRadiusChange < 0)
                    radius -= radiusSpeed;
                radius = ( radius < radiusMin ) ? radiusMin : radius;
                radius = ( radius > radiusMax ) ? radiusMax : radius;
                // Adjust the position to enforce the desired radius smoothly
                Vector3 desiredPosition = center + (transform.position - center).normalized * radius;
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, radiusSpeed);
            }
        }
    }
}
