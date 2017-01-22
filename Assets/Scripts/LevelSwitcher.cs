using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelSwitcher : MonoBehaviour {
    public string levelName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Apple")
        {
            string currLevelName = SceneManager.GetActiveScene().name;
            if (currLevelName != "MainMenu")
            {
                LockController lockController = GameObject.Find("Dickass").GetComponent<LockController>();
                if (!lockController.levelsCompleted.Contains(currLevelName))
                    lockController.levelsCompleted.Add(currLevelName);
            }

            SceneManager.LoadScene(levelName);
        }
    }
}
