using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
   [SerializeField] Animator _catAnimator;

   private CatStateController _catStateController;

    private void Awake()
    {
        _catStateController = GetComponent<CatStateController>();
    }

    private void Update()
    {
        SetCatAnimation();
    }

    private void SetCatAnimation()
    { 
        var currentCatState = _catStateController.CurrentCatState();

        switch(currentCatState)
        {
            case CatState.Idle:
               _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, true);
               _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING,false );
               _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
               break;
            
            case CatState.Walking:
               _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, false);
               _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING, true);
               _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
               break;
            case CatState.Running:
               _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, true);
               break;
            case CatState.Attacking:
               _catAnimator.SetBool(Consts.CatAnimations.IS_ATTACKING, true);
               break;
        }
    }
}
