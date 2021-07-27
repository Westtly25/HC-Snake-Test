using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.UINavigation
{
    public class LevelCompletedView : View
    {
        [SerializeField] private Button restartButton;

        public override void Initialize()
        {
            restartButton.onClick.AddListener(() => OnRestartClicked());
        }

        private void OnRestartClicked()
        {
            
        }
    }
}