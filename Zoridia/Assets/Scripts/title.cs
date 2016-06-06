using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
    [SerializeField]
    float unskipTime = 5f;
    void Start() { saveload.Load(); }
	void Update () {
        if (unskipTime > 0) unskipTime -= Time.deltaTime;
	    if(Input.anyKey & unskipTime < 0)
        { SceneManager.LoadScene(1); }
	}
}
