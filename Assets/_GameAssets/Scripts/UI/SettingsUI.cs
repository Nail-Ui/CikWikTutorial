using System;
using DG.Tweening;
using MaskTransitions;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{

   [Header("References")]
   [SerializeField] private GameObject _settingsPopUpObject;
   [SerializeField] private GameObject _blackBackgroundObject;

   [Header("Buttons")]
   [SerializeField] private Button _settingsButton;
   [SerializeField] private Button _musicButton;
   [SerializeField] private Button _soundButton;
   [SerializeField] private Button _resumeButton;
   [SerializeField] private Button _mainMenuButton;

   [Header("Sprites")]
   [SerializeField] private Sprite _musicActiveSprite;
   [SerializeField] private Sprite _musicPassiveSprite;
   [SerializeField] private Sprite _soundActiveSprite;
   [SerializeField] private Sprite _soundPassiveSprite;

   [Header("Settings")]

   [SerializeField] private float _animationDuration;

   private Image _blackBackGroundImage;

   [SerializeField] private bool _isMusicActive;
   [SerializeField] private bool _isSoundActive;

    private void Awake()
    {
      _blackBackGroundImage = _blackBackgroundObject.GetComponent<Image>();
      _settingsPopUpObject.transform.localScale = Vector3.zero;
      
      _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
      _resumeButton.onClick.AddListener(OnResumeButtonClicked);
      
      _mainMenuButton.onClick.AddListener(() =>
      {
        AudioManager.Instance.Play(SoundType.TransitionSound);
        TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
      });

      _musicButton.onClick.AddListener(OnMusicButtonClicked);
      _soundButton.onClick.AddListener(OnSoundButtonClicked);
    }

    private void OnSoundButtonClicked()
    {
      AudioManager.Instance.Play(SoundType.ButtonClickSound);
      _isSoundActive = !_isSoundActive;
      _soundButton.image.sprite = _isSoundActive ? _soundActiveSprite : _soundPassiveSprite; //ternary operatör
      AudioManager.Instance.SetSoundEffectsMute(!_isSoundActive);
    }

    private void OnMusicButtonClicked()
    {
      AudioManager.Instance.Play(SoundType.ButtonClickSound);
      _isMusicActive = !_isMusicActive;
      _musicButton.image.sprite = _isMusicActive ? _musicActiveSprite : _musicPassiveSprite;
      BackgroundMusic.Instance.SetMusicMute(!_isMusicActive);
    }

    private void OnSettingsButtonClicked()
   {
    
    GameManager.Instance.ChangeGameState(GameState.Pause);
    AudioManager.Instance.Play(SoundType.ButtonClickSound);
    
    _blackBackgroundObject.SetActive(true);
    _settingsPopUpObject.SetActive(true);

    _blackBackGroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
    _settingsPopUpObject.transform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);

   }

   private void OnResumeButtonClicked()
   {
      AudioManager.Instance.Play(SoundType.ButtonClickSound);
      
      _blackBackGroundImage.DOFade(0f, _animationDuration).SetEase(Ease.Linear);
      _settingsPopUpObject.transform.DOScale(0f, _animationDuration).SetEase(Ease.OutExpo).OnComplete(() =>
      {
        GameManager.Instance.ChangeGameState(GameState.Resume); 
        _blackBackgroundObject.SetActive(false);
        _settingsPopUpObject.SetActive(false);
      });
   }
}
