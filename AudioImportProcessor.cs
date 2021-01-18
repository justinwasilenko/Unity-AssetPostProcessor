using UnityEngine;
using UnityEditor;

namespace III.AssetImportProcessor
{
    /// <summary>
    /// Configure Audio import settings on first import.
    /// </summary>
    public class AudioImportProcessor : AssetPostprocessor
    {
        private void OnPreprocessAudio()
        {
            // The variable "assetImporter" references the importer for the asset that is currently importing.
            var importer = assetImporter as AudioImporter;

            if (importer == null) return;

            //If we already have a meta file for that asset it's a reimport and not a first import, so we don't want to apply the preset.
            if (importer.importSettingsMissing)
            {
                AudioImporterSampleSettings sampleSettings = importer.defaultSampleSettings;

                // Compression format should be dependant on the sound file being played
                // sampleSettings.compressionFormat = AudioCompressionFormat.Vorbis;
                sampleSettings.quality = 75f;
                sampleSettings.sampleRateSetting = AudioSampleRateSetting.OptimizeSampleRate;

                Debug.Log("Audio Import: override import settings for: " + importer.assetPath);
            }
        }
    }
}