// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Microsoft.MixedReality.OpenXR.BasicSample
{
	public class CountMeshesFound : MonoBehaviour
	{
		public ARMeshManager m_arMeshManager;

		public TextMesh m_textMesh;

		void Start()
		{
			m_arMeshManager.meshesChanged += MeshesChanged;
		}

		void Update()
		{
			m_textMesh.text = $"Meshes Found: {m_arMeshManager.meshes.Count}";
		}

		public void MeshesChanged(ARMeshesChangedEventArgs eventArgs)
		{
			foreach (var added in eventArgs.added)
			{
				Debug.Log($"Added:    {added.name}");
			}

			foreach (var updated in eventArgs.updated)
			{
				Debug.Log($"Updated: {updated.name}");
			}

			foreach (var removed in eventArgs.removed)
			{
				Debug.Log($"Removed: {removed.name}");
			}
		}
	}
}
