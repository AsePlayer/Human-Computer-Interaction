using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMeshSlicing : MonoBehaviour
{
    public Image loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        // Call a coroutine to load the main scene
        StartCoroutine(LoadLevelAsync());

        // Loadbar fill = 0, since nothing has loaded yet
        loadingBar.fillAmount = 0;
    }

    IEnumerator LoadLevelAsync()
    {
        // Create an async operation = loadSceneAsync(insertTargetSceneHere)
        // While the operation is not loading, update the progress bar

        // Give Unity time to breath, otherwise it will crash
        yield return null;

        yield return new WaitForSeconds(2);

        // Start async scene loading
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MeshSlicing");

        while (!asyncOperation.isDone)
        {
            // Update the fill for loading bar asyncronously, as progress updates using the .progress function
            loadingBar.fillAmount = asyncOperation.progress;

            // Give time for Unity to breath, so it doesn't crash.
            yield return new WaitForEndOfFrame();
        }
    }
}
