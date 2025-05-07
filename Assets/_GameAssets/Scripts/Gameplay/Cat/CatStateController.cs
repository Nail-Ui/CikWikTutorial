using UnityEngine;

public class CatStateController : MonoBehaviour
{
    [SerializeField] CatState _currentCatState = CatState.Walking;

    private void Start()
    {
        ChangeState(CatState.Walking);
    }

    public void ChangeState(CatState newState)
    {
        if(_currentCatState == newState){return; }
        _currentCatState = newState;
    }

    public CatState CurrentCatState()
    {
        return _currentCatState;
    }
}
