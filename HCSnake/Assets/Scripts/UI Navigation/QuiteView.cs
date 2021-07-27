using UnityEngine;
using UnityEngine.UI;

namespace Project.UINavigation
{
    public class QuiteView : View
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;

        public override void Initialize()
        {
            exitButton.onClick.AddListener(() => OnExiteClicked());
            restartButton.onClick.AddListener(() => OnRestartClicked());
        }

        private void OnExiteClicked()
        {

        }

        private void OnRestartClicked()
        {
            
        }
    }
}