using UnityEngine;
using UnityEngine.SceneManagement;

namespace tanker
{
    public class MenuScript : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Exit()
        {
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false; // Stop playing the Unity editor
            }
            else
            {
                Application.Quit(); // Quit the application in a build
            }
        }
    }
}
