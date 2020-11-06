using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * pointer events for UI objects
 * https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
 *
 * TODO: When clicked, if selected already wait a few milliseconds before de-selecting - time to start dragging
 */

public class BackgroundSelector : MonoBehaviour, IPointerDownHandler
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Inspector").GetComponent<GameManager>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        ObjectModel.Select(null);
        gameManager.HideDeleteButton();
    }
}
