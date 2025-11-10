namespace Schedule1EnhancedMod.Utils;

/// <summary>
/// Helper class for asset loading
/// Handles loading Unity asset bundles and resources
/// </summary>
public static class AssetLoader
{
    private static readonly Dictionary<string, UnityEngine.AssetBundle> _loadedBundles = new();
    
    /// <summary>
    /// Load an asset bundle from the mod's assets folder
    /// </summary>
    /// <param name="bundleName">Name of the bundle file (without path)</param>
    /// <returns>The loaded asset bundle, or null if loading failed</returns>
    public static UnityEngine.AssetBundle? LoadBundle(string bundleName)
    {
        // Check if already loaded
        if (_loadedBundles.TryGetValue(bundleName, out var cachedBundle))
        {
            return cachedBundle;
        }
        
        try
        {
            // Construct path to bundle
            // Asset bundles should be in the mod's directory under assets/
            string modDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string bundlePath = Path.Combine(modDirectory, "assets", bundleName);
            
            if (!File.Exists(bundlePath))
            {
                Logger.Error($"Asset bundle not found: {bundlePath}");
                return null;
            }
            
            // Load the bundle
            var bundle = UnityEngine.AssetBundle.LoadFromFile(bundlePath);
            
            if (bundle == null)
            {
                Logger.Error($"Failed to load asset bundle: {bundleName}");
                return null;
            }
            
            _loadedBundles[bundleName] = bundle;
            Logger.Info($"Loaded asset bundle: {bundleName}");
            
            return bundle;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error loading asset bundle: {bundleName}", ex);
            return null;
        }
    }
    
    /// <summary>
    /// Load an asset from a bundle
    /// </summary>
    /// <typeparam name="T">Type of the asset</typeparam>
    /// <param name="bundleName">Name of the bundle</param>
    /// <param name="assetName">Name of the asset within the bundle</param>
    /// <returns>The loaded asset, or null if loading failed</returns>
    public static T? LoadAsset<T>(string bundleName, string assetName) where T : UnityEngine.Object
    {
        var bundle = LoadBundle(bundleName);
        
        if (bundle == null)
        {
            return null;
        }
        
        try
        {
            var asset = bundle.LoadAsset<T>(assetName);
            
            if (asset == null)
            {
                Logger.Error($"Asset '{assetName}' not found in bundle '{bundleName}'");
                return null;
            }
            
            Logger.Debug($"Loaded asset: {assetName} from {bundleName}");
            return asset;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error loading asset '{assetName}' from bundle '{bundleName}'", ex);
            return null;
        }
    }
    
    /// <summary>
    /// Unload all loaded asset bundles
    /// </summary>
    public static void UnloadAllBundles()
    {
        foreach (var bundle in _loadedBundles.Values)
        {
            if (bundle != null)
            {
                bundle.Unload(true);
            }
        }
        
        _loadedBundles.Clear();
        Logger.Info("All asset bundles unloaded");
    }
    
    /// <summary>
    /// Unload a specific asset bundle
    /// </summary>
    /// <param name="bundleName">Name of the bundle to unload</param>
    public static void UnloadBundle(string bundleName)
    {
        if (_loadedBundles.TryGetValue(bundleName, out var bundle))
        {
            bundle?.Unload(true);
            _loadedBundles.Remove(bundleName);
            Logger.Info($"Unloaded asset bundle: {bundleName}");
        }
    }
}
