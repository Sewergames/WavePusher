using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelSwitcher : MonoBehaviour {
    public string levelName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Apple")
            SceneManager.LoadScene(levelName);
    }
}
