using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
 * TODO: ensure GameManager GameObject is child of the Canvas - otherwise Image for line won't display .....
 */
public class GameManager : MonoBehaviour
{
    public GameObject newStateStartGO;
    public GameObject prefabLine;
    private GameObject line;

    public GameObject stateGOPrefab;

    private List<Connector> connectors = new List<Connector>();
    private List<State> states = new List<State>();

    private Connector c;
    
    private Vector3 startPosition = new Vector3(20, -90, 0);
      

    private void Awake()
    {
        c = new Connector();
        connectors.Add(c);
        
        line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
    }

    private void Update()
    {
        
//        Vector3 p1 = objectState1.GetPosition();
//        Vector3 p2 = objectState2.GetPosition();
//        DrawLine(p1, p2);
//        print("drawing line from p1-p2 " + p1 + p2);

        foreach (Connector connector in connectors)
        {            
            DrawLine(connector);
        }
    }

    private void DrawLine(Connector connector)
    {
        DrawLine(connector.GetSource(), connector.GetDestination());
        
    }

    private void DrawLine(Vector2 pointA, Vector2 pointB)
    {
        float lineWidth = 10;
//        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
//        Destroy(line, 0.1f);
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();

        Vector3 differenceVector = pointB - pointA;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }

    public void BUTTON_ACTION_NewState()
    {
        // new state
        State s = new State();
        s.SetName("State " + states.Count);
        states.Add(s);        
        
        GameObject newStateView = (GameObject) Instantiate(stateGOPrefab);
        newStateView.transform.SetParent(transform.parent);
        newStateView.transform.position = newStateStartGO.transform.position;
        s.SetStateView(newStateView);
        s.UpdateView();
        newStateView.GetComponent<ObjectState>().BUTTON_ACTION_Select();
    }

}
