using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playbtn : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(LoadGameScene);
        }
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
