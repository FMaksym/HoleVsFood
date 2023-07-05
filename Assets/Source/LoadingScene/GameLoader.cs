using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameLoader : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text _nameCompanyText;

    private const int DEFAULT_SCENE_INDEX = 1;

    private void Start()
    {
        int currentScene = PlayerPrefs.GetInt("CurrentScene", DEFAULT_SCENE_INDEX);
        _nameCompanyText.DOFade(1f, 0.1f).From(0).OnComplete(() => { LoadCurrentScene(currentScene); });
    }

    private void LoadCurrentScene(int sceneIndex)
    {
        StartCoroutine(WaitAndLoad(2, sceneIndex));
    }

    private IEnumerator WaitAndLoad(float time, int currentScene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(currentScene);
    }
}
