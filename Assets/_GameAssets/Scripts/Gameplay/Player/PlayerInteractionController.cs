using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private PlayerController _playerController;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
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



}
