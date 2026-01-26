using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    void Update()
    {
        // Enterキー または Spaceキー
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SceneTitle");
            // BuildIndexなら
            // SceneManager.LoadScene(0);
        }
    }
}
