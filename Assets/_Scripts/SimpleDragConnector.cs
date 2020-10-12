using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleDragConnector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    public const float MAX_WAIT_DRAG_TIME = 0.2f;
    private bool _dragging = false;

    private ConnectorController _objectState;

    private float _timeLastClicked;

    private void Awake()
    {
        _objectState = transform.parent.GetComponent<ConnectorController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("clicked");
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
