using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _playerVisualTransform;
    private PlayerController _playerController;
    private Rigidbody _playerRigidbody;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody = GetComponent<Rigidbody>();
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.Collect();
        }
        
        // if(other.CompareTag(Consts.WheatType.GOLD_WHEAT))
        // {
        //     other.gameObject.GetComponent<GoldenWheatCollectible>().Collect();
        // }
        // if(other.CompareTag(Consts.WheatType.HOLY_WHEAT))
        // {
        //     other.gameObject.GetComponent<HolyWheatCollectible>().Collect();
        // }
        // if(other.CompareTag(Consts.WheatType.ROTTEN_WHEAT))
        // {
        //     other.gameObject.GetComponent<RottenWheatCollectible>().Collect();
        // }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostable>(out var boostable))
        {
            boostable.Boost(_playerController);
        }
        
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.GiveDamage(_playerRigidbody, _playerVisualTransform);
        }
    }

}
