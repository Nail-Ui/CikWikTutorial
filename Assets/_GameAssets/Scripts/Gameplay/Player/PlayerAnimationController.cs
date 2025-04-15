using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
   [SerializeField] private Animator _playerAnimator; 
   private PlayerController _playerController;
   private StateController _stateController;

    private void Awake()
    {
      _playerController = GetComponent<PlayerController>();
      _stateController = GetComponent<StateController>();   
    }
    private void Start()
    {
        _playerController.OnplayerJumped += PlayerController_OnplayerJumped;
    }


    private void Update()
    {
        SetPlayerAnimations();
    }
    private void PlayerController_OnplayerJumped()
    {
        _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_JUMPING, true);
        Invoke(nameof(ResetJumping), 0.5f);

    }

    private void ResetJumping()
    {
        _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_JUMPING, false);
    }

    private void SetPlayerAnimations()
    {
        var currentState = _stateController.GetCurrentState();

        switch(currentState)
        {
            case PlayerState.Idle:
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING, false);
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_MOVING, false);
                break;
            case PlayerState.Move:
               _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_MOVING, true);
               _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING, false);
               break;
            case PlayerState.SlideIdle:
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING, true);
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING_ACTIVE, false);
                break;
            case PlayerState.slide:
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING, true);
                _playerAnimator.SetBool(Consts.SetPlayerAnimations.IS_SLIDING_ACTIVE, true);
                break;
        }
    }


}
