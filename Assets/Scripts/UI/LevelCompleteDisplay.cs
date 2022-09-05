using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Village.UI
{
    public class LevelCompleteDisplay : MonoBehaviour
    {
        [SerializeField] private Button _next;
        [SerializeField] private Button _exit;

        private const int MainMenuBuildIndex = 0;

        private void OnEnable()
        {
            _next.onClick.AddListener(OnNextClicked);
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _next.onClick.RemoveListener(OnNextClicked);
            _exit.onClick.RemoveListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(MainMenuBuildIndex);
        }

        private void OnNextClicked()
        {
            Time.timeScale = 1f;
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
}