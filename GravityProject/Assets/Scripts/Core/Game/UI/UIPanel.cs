using UnityEngine;

public abstract class UIPanel : MonoBehaviour , IInitializable
{
    enum UIState
    {
        NONE,
        OPEN,
        CLOSE
    }

    private UIState _state;

    public virtual void Initialize()
    {
        
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        
        if (_state == UIState.CLOSE)
        {
            _state = UIState.OPEN;
        }
    }
    
    public virtual void Close()
    {
        gameObject.SetActive(false);
        
        if (_state == UIState.OPEN)
        {
            _state = UIState.CLOSE;
        }
    }
}