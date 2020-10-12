using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Connector
{
    private Vector3 source;
    private Vector3 destination;

    public void SetSource(Vector3 source)
    {
        this.source = source;
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public Vector3 GetSource()
    {
        return this.source;
    }

    public Vector3 GetDestination()
    {
        return this.destination;
    }
    
   
}
