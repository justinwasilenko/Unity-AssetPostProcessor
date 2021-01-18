using UnityEngine;
using UnityEditor;

namespace III.AssetImportProcessor
{
    /// <summary>
    /// Configure Texture import settings on first import.
    /// </summary>
    public class TextureImportProcessor : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            // The variable "assetImporter" references the importer for the asset that is currently importing.
            var importer = assetImporter as TextureImporter;

            if (importer == null) return;

            //If we already have a meta file for that asset it's a reimport and not a first import, so we don't want to apply the preset.
            if (importer.importSettingsMissing)
            {
                string textureName = System.IO.Path.GetFileNameWithoutExtension(importer.assetPath);

                if (textureName.EndsWith("_N"))
                    importer.textureType = TextureImporterType.NormalMap;

                if (textureName.EndsWith("_GUI"))
                    importer.textureType = TextureImporterType.Sprite;

                importer.isReadable = false;
                importer.mipmapEnabled = true;
                importer.wrapMode = TextureWrapMode.Clamp;
                importer.filterMode = FilterMode.Trilinear;
                importer.textureCompression = TextureImporterCompression.Compressed;

                Debug.Log("Texture Import: override import settings for: " + importer.assetPath);
            }
        }
    }
}