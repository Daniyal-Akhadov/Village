using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Village.UI
{
    public class GameOverDisplay : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        private const int MainMenuBuildIndex = 0;

        private void OnEnable()
        {
            _restart.onClick.AddListener(OnRestartClicked);
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(OnRestartClicked);
            _exit.onClick.RemoveListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            SceneManager.LoadScene(MainMenuBuildIndex);
        }

        private void OnRestartClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}