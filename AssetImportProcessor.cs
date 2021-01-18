using UnityEngine;
using UnityEditor;

namespace III.AssetImportProcessor
{
    /// <summary>
    /// Configure Asset import settings on first import.
    /// </summary>
    public class AssetImportProcessor : AssetPostprocessor
    {
        void OnPostprocessAsset()
        {
            // The variable "assetImporter" references the importer for the asset that is currently importing.
            AssetImporter importer = assetImporter;

            if (importer == null) return;

            //If we already have a meta file for that asset it's a reimport and not a first import, so we don't want to apply the preset.
            if (importer.importSettingsMissing)
            {
                // TODO
                // string assetName = System.IO.Path.GetFileNameWithoutExtension(importer.assetPath);



            }
        }
    }
}