using UnityEngine;
using UnityEngine.EventSystems;

public class HoverCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Not hovered");
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered area");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse left area");
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over area");
    }

    public void enter()
    {
        Debug.Log("ENTER");
    }

    public void exit()
    {
        Debug.Log("EXIT");
    }
}
