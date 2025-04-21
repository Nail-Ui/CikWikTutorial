using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour, ICollectible
{
   [SerializeField] private WheatDesignSO _wheatDesignSO;
   [SerializeField] private PlayerController _playerController;
   // [SerializeField] private float _forceIncrease;
   // [SerializeField] private float _resetBoostDuration;


   public void Collect()
   {
    _playerController.SetJumpForce(_wheatDesignSO.IncreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
    Destroy(gameObject);

   }


}
