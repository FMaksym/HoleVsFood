using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Zenject;
using DG.Tweening;

public class GameUiManager : MonoBehaviour
{
    //[Header("Level progress")] [Tooltip("If scene index = 0. SceneOffset(Example: 1) + sceneBildIndex(0) = levelNumber(1)")]
    //[SerializeField] private int _sceneOffset = 1;
    [Space] [Header("Text On level")]
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private TMP_Text _levelCompleteText;
    [Space] [Header("Level progress fill")]
    [SerializeField] private Image _levelProgressFill;
    [SerializeField] private Image _fadeImage;

    [Inject] private LevelManager _level;

    private void Start()
    {
        _levelProgressFill.fillAmount = 0f;
        SetLevelProgress();
    }

    private void SetLevelProgress()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        _currentLevelText.text = levelIndex.ToString();
        _nextLevelText.text = (levelIndex + 1).ToString();
    }

    public void UpdateProgress()
    {
        float value = 1f - ((float)_level.ObjectInScene / _level.TotalObject);
        _levelProgressFill.DOFillAmount(value, 0.4f);
    }

    public void LevelComplete()
    {
        _level.PlayWinParticle();
        _levelCompleteText.DOFade(1f, 0.6f).From(0).OnComplete(()=> { FadeToNextLevel(); });
        StartCoroutine(WaitAndLoadScene(2.5f));
    }

    public void LevelFailed()
    {
        StartCoroutine(WaitAndReloadScene(1.5f));
    }

    private IEnumerator WaitAndLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        _level.LoadNextLevel();
    }

    private IEnumerator WaitAndReloadScene(float time)
    {
        yield return new WaitForSeconds(time);
        _level.RestartLevel();
    }

    private void FadeToNextLevel()
    {
        _fadeImage.DOFade(1, 2f).From(0);
    }
}
