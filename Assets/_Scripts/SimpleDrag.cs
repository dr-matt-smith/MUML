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

    private ObjectState _objectState;

    private GameObject line;

    private void Awake()
    {
        _objectState = transform.parent.GetComponent<ObjectState>();
        line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _objectState.BUTTON_ACTION_Select();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_objectState.IsSelected())
        {
            _dragging = true;            
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_dragging)
        {
            transform.parent.position = Input.mousePosition;
            _objectState.SetPosition(transform.parent.position);            
            DrawLine(Vector3.zero, _objectState.GetPosition());
//            DrawLine(Vector3.zero, Input.mousePosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_dragging)
        {
            _dragging = false;    
        }
    }
    
    
    private void DrawLine(Vector2 p1, Vector2 p2)
    {
        print("drawing line from p1-p2 " + p1 + p2);
        
        float lineWidth = 10;
//        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
//        Destroy(line, 0.1f);
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();

        Vector3 differenceVector = p2 - p1;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = p1;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }

}
