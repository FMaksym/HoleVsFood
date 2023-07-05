using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using DG.Tweening;

public class UndergroundTrigger : MonoBehaviour
{
    [SerializeField] private AddScoreEffect _addScoreEffect;
    [Header("FloatingText spawn position")]
    [SerializeField] private Transform _addScoreEffectSpawnPos;

    [Inject] private LevelManager _level;
    [Inject] private GameUiManager _uiManager;
    [Inject] private Magnet _magnet;

    private void OnTriggerEnter(Collider other)
    {
        if (!Game.IsGameOver){
            if (other.gameObject.GetComponent<Food>()){
                _magnet.RemoveFromMagnet(other.attachedRigidbody);
                _level.DestroyFoodObject();
                _uiManager.UpdateProgress();

                _addScoreEffect.ShowFloatingText(_addScoreEffectSpawnPos.position);

                if (_level.ObjectInScene == 0){
                    _uiManager.LevelComplete();
                }
            }
            else if (other.gameObject.GetComponent<Bomb>()){
                Debug.Log("You lose!");
                Game.IsGameOver = true;
                Camera.main.transform
                    .DOShakePosition(1, 0.2f, 20, 90f)
                    .OnComplete(() => { });
                _uiManager.LevelFailed();
            }
            Destroy(other.gameObject, 1);
        }
    }
}
