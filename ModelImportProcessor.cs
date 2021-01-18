using UnityEngine;
using UnityEditor;

namespace III.AssetImportProcessor
{
    /// <summary>
    /// Configure Model import settings on first import.
    /// </summary>
    public class ModelImportProcessor : AssetPostprocessor
    {
        private void OnPreprocessModel()
        {
            // The variable "assetImporter" references the importer for the asset that is currently importing.
            var importer = assetImporter as ModelImporter;

            if (importer == null) return;

            //If we already have a meta file for that asset it's a reimport and not a first import, so we don't want to apply the preset.
            if (importer.importSettingsMissing)
            {
                // Model Import
                // Scene
                importer.globalScale = 1f;
                importer.useFileUnits = true;
                importer.bakeAxisConversion = true;
                importer.importBlendShapes = false;
                importer.importVisibility = false;
                importer.importCameras = false;
                importer.importLights = false;
                importer.preserveHierarchy = false;
                importer.sortHierarchyByName = true;

                // Meshes
                importer.meshCompression = ModelImporterMeshCompression.Off;
                importer.isReadable = false;
                importer.addCollider = false;

                // Geometery
                importer.keepQuads = false;
                importer.weldVertices = true;
                importer.importNormals = ModelImporterNormals.Import;
                importer.importBlendShapeNormals = ModelImporterNormals.None;
                importer.normalCalculationMode = ModelImporterNormalCalculationMode.AreaAndAngleWeighted;
                importer.normalSmoothingSource = ModelImporterNormalSmoothingSource.FromSmoothingGroups;
                importer.importTangents = ModelImporterTangents.CalculateMikk;
                importer.swapUVChannels = false;
                importer.generateSecondaryUV = false;

                // Rig Import
                importer.animationType = ModelImporterAnimationType.None;

                // Animation Import
                importer.importConstraints = false;
                importer.importAnimation = false;

                // Material Import
                importer.materialImportMode = ModelImporterMaterialImportMode.None;

                Debug.Log("Model Import: override import settings for: " + importer.assetPath);
            }
        }
    }
}