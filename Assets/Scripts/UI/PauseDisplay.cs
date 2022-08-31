using UnityEngine;
using UnityEngine.SceneManagement;

namespace Village.UI
{
    public class PauseDisplay : MonoBehaviour
    {
        public void Continue()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Exit()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}