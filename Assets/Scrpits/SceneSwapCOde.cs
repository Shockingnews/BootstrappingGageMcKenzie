using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapCOde : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void gamePlay()
    {
        SceneManager.LoadScene(1);
    }
}
