using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    RectTransform pageRectTransform;
    RectTransform deskRectTransform;
    Canvas canvas;

    [Header("Gameplay")]
    [SerializeField] bool resetToTop;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        pageRectTransform = GetComponent<RectTransform>();
        deskRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        PreventOutOfBounds();
    }

    private void PreventOutOfBounds()
    {
        //Finding the current Rect position
        Vector2 pageAnchoredPosition = pageRectTransform.anchoredPosition;

        float pageRectWidth = pageRectTransform.rect.width;
        float pageRectHeight = pageRectTransform.rect.height;
        float deskRectWidth = deskRectTransform.rect.width;
        float deskRectHeight = deskRectTransform.rect.height;

        //checking against corners of the desk
        if (pageAnchoredPosition.x + pageRectWidth > deskRectWidth)
        {
            pageAnchoredPosition.x = deskRectWidth - pageRectWidth;
        }
        if (pageAnchoredPosition.x < 0)
        {
            pageAnchoredPosition.x = 0;
        }

        if (pageAnchoredPosition.y + pageRectHeight > deskRectHeight)
        {
            pageAnchoredPosition.y = deskRectHeight - pageRectHeight;
        }
        if (pageAnchoredPosition.y < 0)
        {
            pageAnchoredPosition.y = 0;
        }

        //Setting the Rect position which we found earlier
        pageRectTransform.anchoredPosition = pageAnchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        pageRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (resetToTop)
        {
            pageRectTransform.SetAsLastSibling();
        }
    }
}
