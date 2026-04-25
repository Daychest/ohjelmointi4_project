using UnityEngine;
using UnityEngine.InputSystem;

public class Scrolling : MonoBehaviour
{
    public float minPos = -5;
    public float maxPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scroll = Mouse.current.scroll.ReadValue();
        transform.position -= new Vector3(0, scroll.y, 0);

        if (transform.localPosition.y > maxPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxPos, 0);
        }
        if (transform.localPosition.y < minPos)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, minPos, 0);
        }
    }
}
