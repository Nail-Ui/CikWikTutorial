using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour, ICollectible
{
   [SerializeField] private PlayerController _playerController;
   [SerializeField] private float _movementDecreaseSpeed;
   [SerializeField] private float _resetSlowDuration;


   public void Collect()
   {  
    _playerController.SetMovementSpeed(_movementDecreaseSpeed, _resetSlowDuration);
    Destroy(gameObject);

   }
}
