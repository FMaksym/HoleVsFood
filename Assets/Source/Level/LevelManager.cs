using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int TotalObject { get; private set; }
    public int ObjectInScene { get; private set; }

    [Header("Parent of Food Object")]
    [SerializeField] private Transform _foodParent;
    [Header("Level complate particle")]
    [SerializeField] private ParticleSystem _winParticle;

    private void Start()
    {
        CounterFoodObjects();
    }

    public void CounterFoodObjects()
    {
        TotalObject = _foodParent.childCount;
        ObjectInScene = TotalObject;
    }

    public void DestroyFoodObject()
    {
        ObjectInScene--;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayWinParticle()
    {
        _winParticle.Play();
    }
}
