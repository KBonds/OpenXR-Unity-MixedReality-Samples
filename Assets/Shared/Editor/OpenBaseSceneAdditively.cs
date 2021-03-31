// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace Microsoft.MixedReality.OpenXR.Samples
{
    /// <summary>
    /// Ensure the base scene is additively opened whenever a feature scene is opened. 
    /// </summary>
    [ExecuteInEditMode]
    public class OpenBaseSceneAdditively : MonoBehaviour
    {
#if UNITY_EDITOR
        void Start()
        {
            if (EditorApplication.isPlaying)
            {
                // In play mode, MRTK handles scene loading.
                return;
            }
            UnityEngine.SceneManagement.Scene baseScene = EditorSceneManager.OpenScene("Assets/Shared/Scenes/SharedMRTK.unity", OpenSceneMode.Additive);
            EditorSceneManager.SetActiveScene(baseScene);
        }
#endif
    }
}