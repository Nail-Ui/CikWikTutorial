using UnityEngine;
using UnityEngine.UI;

public class HolyWheatCollectible : MonoBehaviour, ICollectible
{
   [SerializeField] private WheatDesignSO _wheatDesignSO;
   [SerializeField] private PlayerController _playerController;
   // [SerializeField] private float _forceIncrease;
   // [SerializeField] private float _resetBoostDuration;

   [SerializeField] private PlayerStateUI _playerStateUI;
   private RectTransform _playerBoosterTransform;
   private Image _playerBoosterImage;

    private void Awake()
    {
        _playerBoosterTransform = _playerStateUI.GetBoosterJumpTransform;
        _playerBoosterImage = _playerBoosterTransform.GetComponent<Image>();
    }


    public void Collect()
   {
    _playerController.SetJumpForce(_wheatDesignSO.IncreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
    
    _playerStateUI.PlayBoostersUIAnimations(_playerBoosterTransform, _playerBoosterImage, _playerStateUI.GetHolyBoosterImage, _wheatDesignSO.ActiveSprite, 
    _wheatDesignSO.PassiveSprite, _wheatDesignSO.ActiveWheatSprite, _wheatDesignSO.PassiveWheatSprite, _wheatDesignSO.ResetBoostDuration);
    
    Destroy(gameObject);

   }


}
