using UnityEngine;

namespace Village.UI
{
    public class GameDisplay : MonoBehaviour
    {
        [SerializeField] private PauseDisplay _pauseDisplay;

        private Color _originalColor;

        public void Pause()
        {
            _pauseDisplay.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}