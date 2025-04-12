using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XaviEssencials.Runtime
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SceneBundle_", menuName = "Xavi Games/SceneBundle")]
    public class SceneBundle : ScriptableObject
    {
        [field: Space]
        [field: Header("Scenes References")]
        [field: SerializeField]
        public SceneReference SceneSingle { get; private set; }

        [field: Space]
        [field: SerializeField]
        public List<SceneReference> ScenesAdditives { get; private set; }

        public async Task LoadScenesAsync(
            Action<string, float> onSceneProgress = null,
            Action<float> onTotalProgress = null)
        {
            if (!SceneManager.GetSceneByName(SceneSingle.SceneName).isLoaded)
            {
                var mainSceneLoad = SceneManager.LoadSceneAsync(SceneSingle.SceneName, LoadSceneMode.Single);

                while (!mainSceneLoad.isDone)
                {
                    onSceneProgress?.Invoke(SceneSingle.SceneName, mainSceneLoad.progress);
                    await Task.Yield();
                }

                onSceneProgress?.Invoke(SceneSingle.SceneName, 1f);
            }

            var additiveOperations = new List<(string sceneName, AsyncOperation op)>();

            foreach (var sceneRef in ScenesAdditives)
            {
                if (!SceneManager.GetSceneByName(sceneRef.SceneName).isLoaded)
                {
                    var loadOp = SceneManager.LoadSceneAsync(sceneRef.SceneName, LoadSceneMode.Additive);
                    additiveOperations.Add((sceneRef.SceneName, loadOp));
                }
            }

            while (additiveOperations.Any(pair => !pair.op.isDone))
            {
                float totalProgress = 0f;

                foreach (var (sceneName, op) in additiveOperations)
                {
                    onSceneProgress?.Invoke(sceneName, op.progress);
                    totalProgress += op.progress;
                }

                float averageProgress = additiveOperations.Count > 0 ? totalProgress / additiveOperations.Count : 1f;
                onTotalProgress?.Invoke(averageProgress);

                await Task.Yield();
            }

            foreach (var (sceneName, _) in additiveOperations)
            {
                onSceneProgress?.Invoke(sceneName, 1f);
            }

            onTotalProgress?.Invoke(1f);
        }

    }
}
