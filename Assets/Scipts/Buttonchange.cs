using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonchange : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
