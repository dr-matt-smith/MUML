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
//    public const float MAX_WAIT_DRAG_TIME = 0.2f;
    private bool _dragging = false;

    private ObjectView _objectView;
    private ObjectModel _objectModel;

//    private float _timeLastClicked;

    private void Awake()
    {
        _objectView = transform.parent.GetComponent<ObjectView>();
        _objectModel = _objectView.GetObjectModel();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ObjectModel.Select(_objectModel);
//        _timeLastClicked = Time.time;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
//        if (!_objectModel.IsSelected())
//        {
//            float clickToDragInterval = Time.time - _timeLastClicked;
//            if (clickToDragInterval < MAX_WAIT_DRAG_TIME)
//            {
//                _objectView.BUTTON_ACTION_Select();
//            }
//            
//        }
        
        
        if (_objectModel.IsSelected())
        {
            _dragging = true;            
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_dragging)
        {
            transform.parent.position = Input.mousePosition;
            _objectView.SetPosition(transform.parent.position);            
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
