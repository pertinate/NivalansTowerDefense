using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Pertinate.Utility;
using System;

namespace Pertinate.Player
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public enum JSType
        {
            Movement,
            Camera
        }
        //image to use to get input and set bounds for joystickImage to move in
        public Image backgroundImage;
        //image to control with input
        public Image joystickImage;
        public JSType joystickType = JSType.Movement;

        private void Start()
        {
            if (backgroundImage == null)
                backgroundImage = GetComponent<Image>();
            if (joystickImage == null)
                joystickImage = transform.GetChild(0).GetComponent<Image>();
        }

        //interface implementation
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = Vector2.zero;
            //get the position of finger click inside background image
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
            {
                position.x = (position.x / backgroundImage.rectTransform.sizeDelta.x);
                position.y = (position.y / backgroundImage.rectTransform.sizeDelta.y);

                float x = (backgroundImage.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
                float y = (backgroundImage.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

                if(joystickType == JSType.Movement)
                {
                    CustomInput.SetMoveVector(new Vector3(x, 0, y));
                    CustomInput.SetMoveVector((CustomInput.moveVector.magnitude > 1) ? CustomInput.moveVector.normalized : CustomInput.moveVector);

                    joystickImage.rectTransform.anchoredPosition = new Vector3(CustomInput.moveVector.x * (backgroundImage.rectTransform.sizeDelta.x / 3),
                                                                                CustomInput.moveVector.z * (backgroundImage.rectTransform.sizeDelta.y / 3));
                }
                else
                {
                    CustomInput.SetRotateVector(new Vector3(x, 0, y));
                    CustomInput.SetRotateVector((CustomInput.cameraRotateVector.magnitude > 1) ? CustomInput.cameraRotateVector.normalized : CustomInput.cameraRotateVector);

                    //set the position of image
                    joystickImage.rectTransform.anchoredPosition = new Vector3(CustomInput.cameraRotateVector.x * (backgroundImage.rectTransform.sizeDelta.x / 3),
                                                                                /*CustomInput.cameraRotateVector.z * (backgroundImage.rectTransform.sizeDelta.y / 3*/ 0f, 0f);
                }
            }
        }
        //interface implementation
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }
        //interface implementation
        public void OnPointerUp(PointerEventData eventData)
        {
            if(joystickType == JSType.Movement)
            {
                CustomInput.SetMoveVector(Vector3.zero);
                joystickImage.rectTransform.anchoredPosition = Vector3.zero;
            }
            else
            {
                CustomInput.SetRotateVector(Vector3.zero);
                joystickImage.rectTransform.anchoredPosition = Vector3.zero;
            }
        }
    }
}
