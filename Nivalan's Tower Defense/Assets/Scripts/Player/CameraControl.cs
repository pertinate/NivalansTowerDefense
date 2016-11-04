using UnityEngine;
using Pertinate.Utility;
using System.Collections;

namespace Pertinate.Player
{
    public class CameraControl : MonoBehaviour
    {
        public GameObject target;
        public float rotateSpeed = 5f;
        public float damping = 15f;
        Vector3 offset;

        void Start()
        {
            offset = target.transform.position - transform.position;
        }

        void LateUpdate()
        {
            float horizontal = CustomInput.cameraRotateVector.x * rotateSpeed;
            target.transform.Rotate(0, horizontal, 0);

            float desiredAngle = target.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            Vector3 position = /*Vector3.Lerp(transform.position, */target.transform.position - (rotation * offset)/*, Time.deltaTime * damping)*/;
            transform.position = position;

            transform.LookAt(target.transform);
        }
    }
}
