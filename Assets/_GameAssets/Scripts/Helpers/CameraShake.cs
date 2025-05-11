using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

   public static CameraShake Instance {get; private set;}

   private float _shakeTimer;
   private float _shakeTimerTotal;
   private float _startingIntesity;

    private void Awake()
    {
        Instance = this;  
        _cinemachineBasicMultiChannelPerlin = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private IEnumerator CameraShakeCoroutine(float intensity, float time, float delay )
    {
        yield return new WaitForSeconds(delay);
        _cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
        _shakeTimer = time;
        _shakeTimerTotal = time;
        _startingIntesity = intensity;
    }

    public void ShakeCamera(float intensity, float time, float delay = 0f)
    { 
        StartCoroutine(CameraShakeCoroutine(intensity, time, delay));
    }

    private void Update()
    {
        if(_shakeTimer > 0f)
        {
            _shakeTimer -= Time.deltaTime;

            if(_shakeTimer <= 0f)
            {
                _cinemachineBasicMultiChannelPerlin.AmplitudeGain
                  =Mathf.Lerp(_startingIntesity, 0f, 1- (_shakeTimer / _shakeTimerTotal));
            }
        }
    }
}
 