using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindowRotated : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
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

        Vector3[] pageCorners = new Vector3[4];
        Vector3[] deskCorners = new Vector3[4];

        pageRectTransform.GetWorldCorners(pageCorners);
        deskRectTransform.GetWorldCorners(deskCorners);
        //Debug.Log("Page World Corners");
        for (var i = 0; i < 4; i++)
        {
            //Debug.Log("Page World Corner " + i + " : " + pageCorners[i]);
        }
        //Debug.Log("Desk World Corners");
        for (var i = 0; i < 4; i++)
        {
            //Debug.Log("Desk World Corner " + i + " : " + deskCorners[i]);
        }

 

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
