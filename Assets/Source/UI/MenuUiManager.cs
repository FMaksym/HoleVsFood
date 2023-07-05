using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuUiManager : MonoBehaviour
{
    [Header("Games Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    [Space] [Header("Games Panels")]
    [SerializeField] private Image _fadeImage;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        Game.IsGame = false;
        FadeToStart();
    }

    private void StartGame()
    {
        Game.IsGame = true;
        _menuPanel.SetActive(false);
        _gamePanel.SetActive(true);
    }

    public void OnClickStart()
    {
        StartGame();
    }

    private void FadeToStart()
    {
        _fadeImage.DOFade(0, 1.3f).From(1).OnComplete(()=> 
        { 
            _fadeImage.gameObject.SetActive(false); 
        });
    }
}
