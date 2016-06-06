using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour {

    public void Load(int a) { SceneManager.LoadScene(a); ResetTime(); }
    public void Load(string a) { SceneManager.LoadScene(a); ResetTime(); }
    public void ReloadLvl() { Load(SceneManager.GetActiveScene().buildIndex); }
    public void ReloadApp() { Load(0); }
    void ResetTime() { Time.timeScale = 1f; }
    public void Quit() { Application.Quit(); }

}
