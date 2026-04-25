using UnityEngine;
using UnityEngine.InputSystem;

public class Scrolling : MonoBehaviour
{
    public GameObject scrollHoverArea;
    public float minPos = -5;
    public float maxPos = 0;

    bool dragging = false;
    Vector2 lastMousePosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }

        if (scrollHoverArea.GetComponent<HoverCheck>().isHovered)
        {
            Vector2 scroll = Mouse.current.scroll.ReadValue();
            transform.position -= new Vector3(0, scroll.y, 0);

            if (Mouse.current.leftButton.wasPressedThisFrame && !dragging)
            {
                dragging = true;
                lastMousePosition = getMousePos();
            }
        }

        if (dragging)
        {
            Vector2 mouseMovement = getMousePos() - lastMousePosition;
            transform.position += new Vector3(0, mouseMovement.y, 0);
            lastMousePosition = getMousePos();
        }

        if (transform.localPosition.y > maxPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxPos, 0);
        }
        if (transform.localPosition.y < minPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, minPos, 0);
        }
    }

    private Vector2 getMousePos()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        return mouseWorldPosition;
    }


}
