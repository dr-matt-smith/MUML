using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * pointer events for UI objects
 * https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
 *
 * 
 */

public class SimpleDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    public GameObject prefabLine;
    private bool _dragging = false;
//    private Image _image;

    private ObjectState _objectState;

    private void Awake()
    {
        _objectState = transform.parent.GetComponent<ObjectState>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _objectState.BUTTON_ACTION_Select();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
//        _image = GetComponent<Image>();
  //      _image.enabled = !_dragging;
        
        _objectState.BUTTON_ACTION_Select();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = Input.mousePosition;
        DrawLine(Vector3.zero, Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _dragging = false;
    //    _image.enabled = !_dragging;

    }
    
    private void DrawLine(Vector2 pointA, Vector2 pointB)
    {
        float lineWidth = 10;
        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
        Destroy(line, 0.1f);
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();

        Vector3 differenceVector = pointB - pointA;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }

}
