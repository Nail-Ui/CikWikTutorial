using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour, ICollectible
{
   [SerializeField] private WheatDesignSO _wheatDesignSO;
   [SerializeField] private PlayerController _playerController;
   // [SerializeField] private float _movementDecreaseSpeed;
   // [SerializeField] private float _resetSlowDuration;


   public void Collect()
   {  
    _playerController.SetMovementSpeed(_wheatDesignSO.IncreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
    Destroy(gameObject);

   }
}
