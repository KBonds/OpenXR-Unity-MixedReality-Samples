// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using TMPro;
using UnityEngine;

namespace Microsoft.MixedReality.OpenXR.BasicSample
{
	/// <summary>
	/// Applies requested changes to mesh compute settings
	/// </summary>
	public class MeshComputeSettingsSample : MonoBehaviour
	{
		[SerializeField]
		private TextMeshPro meshTypeText;
		public TextMeshPro visualMeshLODText;
		public TextMeshPro meshComputeConsistencyText;

		private MeshComputeSettings meshComputeSettings = new MeshComputeSettings
		{
			MeshType = MeshType.Collider,
			VisualMeshLevelOfDetail = VisualMeshLevelOfDetail.Coarse,
			MeshComputeConsistency = MeshComputeConsistency.OcclusionOptimized
		};

		private void Start() => UpdateSettingsAndText();

		private T NextValueOfEnum<T>(T currentValue)
		{
			T[] allValues = (T[])Enum.GetValues(typeof(T));
			int idx = Array.IndexOf(allValues, currentValue);
			idx = (idx + 1) % allValues.Length;
			return allValues[idx];
		}

		public void ChangeMeshType()
		{
			meshComputeSettings.MeshType = NextValueOfEnum(meshComputeSettings.MeshType);
			UpdateSettingsAndText();
		}

		public void ChangeVisualMeshLevelOfDetail()
		{
			meshComputeSettings.VisualMeshLevelOfDetail = NextValueOfEnum(meshComputeSettings.VisualMeshLevelOfDetail);
			UpdateSettingsAndText();
		}

		public void ChangeMeshComputeConsistency()
		{
			meshComputeSettings.MeshComputeConsistency = NextValueOfEnum(meshComputeSettings.MeshComputeConsistency);
			UpdateSettingsAndText();
		}

		void UpdateSettingsAndText()
		{
			if (!MeshSettings.TrySetMeshComputeSettings(meshComputeSettings))
			{
				Debug.Log("Failed to set the selected mesh compute settings.");
			}
			meshTypeText.text = $"Mesh Type:\n{meshComputeSettings.MeshType}";
			visualMeshLODText.text = $"Visual Mesh LOD:\n{meshComputeSettings.VisualMeshLevelOfDetail}";
			meshComputeConsistencyText.text = $"Compute Consistency:\n{meshComputeSettings.MeshComputeConsistency}";
		}
	}
}
