using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * pointer events for UI objects
 * https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
 *
 * TODO: When clicked, if selected already wait a few milliseconds before de-selecting - time to start dragging
 */

public class SimpleDragObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler

{
    private bool _dragging = false;
    
    private ObjectModel _objectModel;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("Inspector").GetComponent<GameManager>();
    }


    public void SetObjectModel(ObjectModel objectModel)
    {
        _objectModel = objectModel;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_objectModel != null)
            _objectModel.SetHighlighted(true);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_objectModel != null)
            _objectModel.SetHighlighted(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _dragging = true;

        if (_objectModel != null)
        {
            _gameManager.SetSelectedObject(_objectModel); 
        }
    }

                
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_objectModel != null)
        {
            if (_objectModel.IsSelected())
            {
                transform.parent.position = Input.mousePosition;
            }
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_objectModel != null)
        {
            if (_dragging)
            {
                _dragging = false;
            }
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (_objectModel != null)
        {
            if (_dragging)
            {
                transform.parent.position = Input.mousePosition;
                _objectModel.SetPosition(transform.parent.position);
            }
        }
    }

}
