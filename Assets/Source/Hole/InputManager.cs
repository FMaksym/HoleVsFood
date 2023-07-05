using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float _touchSensitivity = 0.01f;

    public bool IsMoving()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
    return Input.GetMouseButton(0);
#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
    return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
#endif
    }

    public Vector2 GetInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(mouseX, mouseY);
#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchX = touch.deltaPosition.x * _touchSensitivity;
            float touchY = touch.deltaPosition.y * _touchSensitivity;
            return new Vector2(touchX, touchY);
        }
        else
        {
            return Vector2.zero;
        }
#else
        return Vector2.zero;
#endif
    }
}
