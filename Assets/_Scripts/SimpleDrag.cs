using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * pointer events for UI objects
 * https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
 *
 * TODO: When clicked, if selected already wait a few milliseconds before de-selecting - time to start dragging
 */

public class SimpleDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    public const float MAX_WAIT_DRAG_TIME = 0.2f;
    private bool _dragging = false;

    private ObjectState _objectState;

    private float _timeLastClicked;

    private void Awake()
    {
        _objectState = transform.parent.GetComponent<ObjectState>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _objectState.BUTTON_ACTION_Select();
        _timeLastClicked = Time.time;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_objectState.IsSelected())
        {
            float clickToDragInterval = Time.time - _timeLastClicked;
            if (clickToDragInterval < MAX_WAIT_DRAG_TIME)
            {
                _objectState.BUTTON_ACTION_Select();
            }
            
        }
        
        
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
//            DrawLine(Vector3.zero, _objectState.GetPosition());
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

}
