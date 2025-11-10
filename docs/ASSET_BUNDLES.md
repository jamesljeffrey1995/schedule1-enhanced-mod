# Unity Asset Bundle Creation Guide

This guide explains how to create Unity asset bundles for use with the Schedule 1 Enhanced Mod.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Setting Up Unity](#setting-up-unity)
3. [Creating Asset Bundles](#creating-asset-bundles)
4. [Using Asset Bundles in Code](#using-asset-bundles-in-code)
5. [Best Practices](#best-practices)
6. [Troubleshooting](#troubleshooting)

## Prerequisites

### Required Software

1. **Unity Editor**
   - Version should match Schedule 1's Unity version
   - Check the game files to determine the version
   - Download from [Unity Archive](https://unity.com/releases/editor/archive)

2. **3D Modeling Software** (optional)
   - Blender (free) - recommended for beginners
   - Maya, 3ds Max, or other professional tools

### Finding Schedule 1's Unity Version

1. Navigate to your Schedule 1 installation folder
2. Go to `Schedule I_Data/`
3. Right-click `globalgamemanagers` → Properties
4. Check the "Details" tab or use a hex editor to find the Unity version

## Setting Up Unity

### 1. Create a New Unity Project

1. Open Unity Hub
2. Click "New Project"
3. Select **3D** template
4. Name it "Schedule1ModAssets"
5. Choose a location and click "Create"

### 2. Set Up Project Structure

Create the following folder structure in your Assets folder:

```
Assets/
├── Bundles/            # Where built bundles will go
├── Items/              # Item assets
│   ├── Icons/         # Item icons (sprites)
│   ├── Models/        # Item 3D models
│   └── Prefabs/       # Item prefabs
├── NPCs/               # NPC assets
│   ├── Models/        # NPC 3D models
│   ├── Animations/    # NPC animations
│   └── Prefabs/       # NPC prefabs
├── UI/                 # UI elements
│   └── Icons/         # Various UI icons
└── Editor/             # Build scripts
```

### 3. Create the Asset Bundle Build Script

Create a file at `Assets/Editor/BuildAssetBundles.cs`:

```csharp
using UnityEditor;
using System.IO;
using UnityEngine;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/Bundles";
        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        BuildPipeline.BuildAssetBundles(
            assetBundleDirectory,
            BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows64
        );
        
        Debug.Log("Asset bundles built successfully!");
    }
    
    [MenuItem("Assets/Build AssetBundles (Development)")]
    static void BuildAssetBundlesDevelopment()
    {
        string assetBundleDirectory = "Assets/Bundles";
        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        BuildPipeline.BuildAssetBundles(
            assetBundleDirectory,
            BuildAssetBundleOptions.UncompressedAssetBundle | 
            BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.StandaloneWindows64
        );
        
        Debug.Log("Development asset bundles built successfully!");
    }
}
```

## Creating Asset Bundles

### Example 1: Creating an Item Icon Bundle

#### Step 1: Import Your Icon

1. Import your icon image (PNG recommended, 256x256 or 512x512)
2. Place it in `Assets/Items/Icons/`
3. Select the image in Unity

#### Step 2: Configure Import Settings

In the Inspector:
- **Texture Type:** Sprite (2D and UI)
- **Sprite Mode:** Single
- **Pixels Per Unit:** 100
- **Filter Mode:** Bilinear
- **Compression:** None or Low Quality for development
- Click "Apply"

#### Step 3: Assign to Asset Bundle

At the bottom of the Inspector:
- **AssetBundle:** Click the dropdown
- Select "New..." and name it `itemicons`
- The variant can be left empty

#### Step 4: Build the Bundle

1. Go to menu: **Assets → Build AssetBundles**
2. Find your bundle in `Assets/Bundles/itemicons`

### Example 2: Creating a 3D Model Bundle

#### Step 1: Import Your Model

1. Import your 3D model (FBX, OBJ, etc.)
2. Place it in `Assets/Items/Models/`

#### Step 2: Create a Prefab

1. Drag your model into the scene
2. Add any necessary components:
   - Colliders
   - Rigidbody (if physics-based)
   - Custom scripts
3. Adjust materials and textures
4. Drag from Hierarchy into `Assets/Items/Prefabs/` to create a prefab
5. Delete from scene

#### Step 3: Assign to Asset Bundle

Select the prefab:
- **AssetBundle:** `itemmodels`

Also assign any dependencies (materials, textures) to the same bundle.

#### Step 4: Build the Bundle

**Assets → Build AssetBundles**

### Example 3: Creating an NPC Bundle with Animations

#### Step 1: Import Model with Animations

1. Import your rigged and animated model
2. Configure the import settings:
   - **Animation Type:** Humanoid (if applicable)
   - **Avatar Definition:** Create From This Model
   - Click "Apply"

#### Step 2: Extract Animations

1. Select the model
2. Go to the "Animation" tab in Inspector
3. Review the animation clips
4. Click "Apply"

#### Step 3: Create Animator Controller

1. Right-click in `Assets/NPCs/Animations/`
2. Create → Animator Controller
3. Name it (e.g., "MerchantController")
4. Double-click to open Animator window
5. Add animation states and transitions

#### Step 4: Create NPC Prefab

1. Drag model into scene
2. Add Animator component
3. Assign your Animator Controller
4. Add any other components needed
5. Create prefab in `Assets/NPCs/Prefabs/`

#### Step 5: Assign to Asset Bundle

Select all NPC assets (model, animations, controller, prefab):
- **AssetBundle:** `npcassets`

#### Step 6: Build

**Assets → Build AssetBundles**

## Using Asset Bundles in Code

### Loading an Item Icon

```csharp
using Schedule1EnhancedMod.Utils;

public class MyCustomItem : CustomItem
{
    public override string IconPath => "itemicons.bundle/fire_sword_icon";
    
    private Sprite? _icon;
    
    public override void OnRegister()
    {
        base.OnRegister();
        
        // Load the icon
        _icon = AssetLoader.LoadAsset<Sprite>("itemicons.bundle", "fire_sword_icon");
        
        if (_icon == null)
        {
            Logger.Warning($"Failed to load icon for {ItemName}");
        }
    }
}
```

### Loading an NPC Model

```csharp
using Schedule1EnhancedMod.Utils;
using UnityEngine;

public class MyNPC : CustomNPC
{
    private GameObject? _modelPrefab;
    private GameObject? _spawnedModel;
    
    protected override void OnSpawn()
    {
        base.OnSpawn();
        
        // Load the model prefab
        _modelPrefab = AssetLoader.LoadAsset<GameObject>("npcassets.bundle", "merchant_prefab");
        
        if (_modelPrefab != null)
        {
            // Instantiate the model at spawn location
            // Vector3 spawnPos = GetSpawnPosition(); // Your spawn logic
            // _spawnedModel = GameObject.Instantiate(_modelPrefab, spawnPos, Quaternion.identity);
            
            Logger.Info($"Spawned model for {NPCName}");
        }
    }
    
    protected override void OnDespawn()
    {
        base.OnDespawn();
        
        if (_spawnedModel != null)
        {
            GameObject.Destroy(_spawnedModel);
            _spawnedModel = null;
        }
    }
}
```

### Loading Multiple Assets

```csharp
// Load entire bundle
var bundle = AssetLoader.LoadBundle("itemicons.bundle");

if (bundle != null)
{
    // Load all sprites
    var allSprites = bundle.LoadAllAssets<Sprite>();
    
    foreach (var sprite in allSprites)
    {
        Logger.Info($"Found sprite: {sprite.name}");
    }
}
```

## Best Practices

### Asset Naming

- Use lowercase with underscores: `fire_sword_icon`
- Be descriptive: `merchant_idle_animation`
- Include type in name: `icon_`, `model_`, `anim_`
- Avoid special characters

### Bundle Organization

- **Keep bundles focused:** One bundle per category (e.g., all item icons in one bundle)
- **Consider size:** Large bundles take longer to load
- **Group dependencies:** Put related assets in the same bundle
- **Use multiple bundles:** Don't put everything in one bundle

### Performance

- **Texture sizes:** Use appropriate resolutions (icons: 256x256, models: 1024x1024 max)
- **Polygon count:** Keep models optimized (under 10k triangles for NPCs)
- **Compression:** Use compressed textures for release builds
- **Unload when done:** Unload bundles when no longer needed

### Version Control

- **Don't commit bundles to Git:** They're binary files and can be large
- **Add to .gitignore:** `*.bundle`, `*.manifest`
- **Store source assets:** Commit the Unity project, not the built bundles
- **Document:** Keep a list of what's in each bundle

## Troubleshooting

### Bundle Not Loading

**Problem:** AssetLoader returns null

**Solutions:**
1. Check that the bundle file is in the mod's `assets/` folder
2. Verify the bundle name is correct (case-sensitive)
3. Check MelonLoader console for error messages
4. Ensure the bundle was built for the correct platform (Windows x64)

### Asset Not Found in Bundle

**Problem:** Asset can't be loaded from bundle

**Solutions:**
1. Verify the asset name is correct (case-sensitive)
2. Check that the asset was assigned to the bundle before building
3. Use a bundle viewer tool to inspect bundle contents
4. Rebuild the bundle

### Wrong Unity Version

**Problem:** Bundle causes crashes or doesn't load

**Solutions:**
1. Verify you're using the same Unity version as Schedule 1
2. Rebuild bundles with the correct Unity version
3. Check Unity Editor console for warnings during build

### Missing Materials/Textures

**Problem:** Models load but appear pink or have missing textures

**Solutions:**
1. Assign all materials and textures to the same bundle as the model
2. Use Standard shader (built-in shaders may not work)
3. Check material references in the prefab

### Large File Sizes

**Problem:** Bundle files are too large

**Solutions:**
1. Reduce texture resolutions
2. Enable texture compression in import settings
3. Optimize models (reduce polygon count)
4. Split into multiple smaller bundles
5. Use BuildAssetBundleOptions.ChunkBasedCompression

## Example Workflow

Here's a complete workflow for adding a new item:

1. **Create the icon:**
   - Create a 256x256 PNG icon
   - Import to `Assets/Items/Icons/fire_sword_icon.png`
   - Set as Sprite
   - Assign to `itemicons` bundle

2. **Create the 3D model:**
   - Import model to `Assets/Items/Models/`
   - Create materials in `Assets/Items/Materials/`
   - Create prefab in `Assets/Items/Prefabs/fire_sword.prefab`
   - Assign all to `itemmodels` bundle

3. **Build bundles:**
   - Assets → Build AssetBundles
   - Copy `itemicons` and `itemmodels` from `Assets/Bundles/` to your mod's `assets/` folder

4. **Code the item:**
   ```csharp
   public class FireSword : CustomItem
   {
       public override string IconPath => "itemicons.bundle/fire_sword_icon";
       // ... implementation
   }
   ```

5. **Test:**
   - Build your mod
   - Copy to Mods folder
   - Launch game and verify assets load correctly

## Resources

- [Unity Asset Bundle Manual](https://docs.unity3d.com/Manual/AssetBundlesIntro.html)
- [Unity Asset Bundle Browser](https://github.com/Unity-Technologies/AssetBundles-Browser) - Tool for inspecting bundles
- [Blender](https://www.blender.org/) - Free 3D modeling software
- [GIMP](https://www.gimp.org/) - Free image editor for icons

## Next Steps

- Read the [Modding Guide](MODDING_GUIDE.md) for how to use assets in your code
- Check out the [API Documentation](API.md) for AssetLoader details
- Join the Schedule 1 modding community for help and resources
