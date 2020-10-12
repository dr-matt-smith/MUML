using UnityEngine;

public class State
{
    public enum StateType
    {
        INITIAL, 
        FINAL, 
        TERMINAL, 
        DEFAULT
    }
    
    private string name;
    private StateType type = StateType.DEFAULT;
    private GameObject stateView;

    public void SetStateView(GameObject newStateView)
    {
        this.stateView = newStateView;
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetName(string newName)
    {
        this.name = newName;
    }

    public StateType GetType()
    {
        return this.type;
    }

    public void SetType(StateType newType)
    {
        this.type = newType;
    }

    public void UpdateView()
    {
        this.stateView.GetComponent<ObjectState>().SetStateName(this.name);
    }
    
    

}
