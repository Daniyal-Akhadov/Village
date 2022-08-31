using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Village.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _start.onClick.AddListener(OnStartClicked);
            _exit.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(OnStartClicked);
            _exit.onClick.RemoveListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            Application.Quit();
        }

        private void OnStartClicked()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}