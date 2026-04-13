//TEHTY TEKOÄLYLLÄ

using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalScroller : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private float swipeStep = 11.59f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 11.59f;

    private Vector2 lastPointerPosition;
    private bool isDragging = false;

    private void Update()
    {
        if (content == null)
            return;

        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                lastPointerPosition = Mouse.current.position.ReadValue();
                isDragging = true;
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector2 currentPointerPosition = Mouse.current.position.ReadValue();
                float deltaY = currentPointerPosition.y - lastPointerPosition.y;

                if (Mathf.Abs(deltaY) > 5f)
                {
                    Vector3 pos = content.localPosition;

                    if (deltaY > 0f)
                    {
                        pos.y += swipeStep;
                    }
                    else if (deltaY < 0f)
                    {
                        pos.y -= swipeStep;
                    }

                    pos.y = Mathf.Clamp(pos.y, minY, maxY);
                    content.localPosition = pos;

                    lastPointerPosition = currentPointerPosition;
                }
            }
        }
    }
}