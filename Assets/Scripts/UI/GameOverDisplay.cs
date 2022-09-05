using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Village.Hero;

namespace Village.UI
{
    public class GameOverDisplay : MonoBehaviour
    {
        [SerializeField] private float _showDelay = 1.5f;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        private CanvasGroup _canvasGroup;
        private HeroHealth _hero;
        private const int MainMenuBuildIndex = 0;

        private void Awake()
        {
            _hero = FindObjectOfType<HeroHealth>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _hero.Died += OnHeroDied;
            _restart.onClick.AddListener(OnRestartClicked);
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _hero.Died -= OnHeroDied;
            _restart.onClick.RemoveListener(OnRestartClicked);
            _exit.onClick.RemoveListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(MainMenuBuildIndex);
        }

        private void OnRestartClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnHeroDied()
        {
            _canvasGroup.DOFade(1, 1f).SetDelay(_showDelay).OnComplete(() => { _canvasGroup.blocksRaycasts = true; });
        }
    }
}