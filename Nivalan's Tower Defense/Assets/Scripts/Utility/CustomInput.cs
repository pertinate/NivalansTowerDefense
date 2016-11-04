using UnityEngine;

namespace Pertinate.Utility
{
    public static class CustomInput
    {
        private static Vector3 _moveVector = Vector3.zero;
        public static Vector3 moveVector
        {
            get { return _moveVector; }
        }
        public static void SetMoveVector(Vector3 v)
        {
            _moveVector = v;
        }

        private static Vector3 _cameraRotateVector = Vector3.zero;
        public static Vector3 cameraRotateVector
        {
            get { return _cameraRotateVector; }
        }
        public static void SetRotateVector(Vector3 v)
        {
            _cameraRotateVector = v;
        }
    }
}
