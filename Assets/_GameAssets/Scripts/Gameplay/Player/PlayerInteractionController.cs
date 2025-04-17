using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Consts.WheatType.GOLD_WHEAT))
        {
            other.gameObject.GetComponent<GoldenWheatCollectible>().Collect();
        }
        if(other.CompareTag(Consts.WheatType.HOLY_WHEAT))
        {
            other.gameObject.GetComponent<HolyWheatCollectible>().Collect();
        }
        if(other.CompareTag(Consts.WheatType.ROTTEN_WHEAT))
        {
            other.gameObject.GetComponent<RottenWheatCollectible>().Collect();
        }
    }
}
