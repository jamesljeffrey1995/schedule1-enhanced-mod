# Assets Folder

This folder contains Unity asset bundles for the mod.

## What are Asset Bundles?

Asset bundles are Unity's way of packaging assets (3D models, textures, sprites, audio, etc.) that can be loaded at runtime. They allow you to include custom visual and audio content in your mod.

## Creating Asset Bundles

See the [Asset Bundle Creation Guide](../docs/ASSET_BUNDLES.md) for detailed instructions on creating asset bundles in Unity.

## Bundle Structure

Organize your bundles by category:

```
assets/
├── itemicons.bundle       # Item icons (sprites)
├── itemmodels.bundle      # Item 3D models
├── npcassets.bundle       # NPC models and animations
├── uielements.bundle      # Custom UI elements
└── audio.bundle           # Custom sound effects and music
```

## Loading Asset Bundles

Use the AssetLoader utility to load bundles in your code:

```csharp
using Schedule1EnhancedMod.Utils;

// Load a sprite
var icon = AssetLoader.LoadAsset<Sprite>("itemicons.bundle", "fire_sword_icon");

// Load a GameObject prefab
var model = AssetLoader.LoadAsset<GameObject>("itemmodels.bundle", "fire_sword_prefab");

// Load an AudioClip
var sound = AssetLoader.LoadAsset<AudioClip>("audio.bundle", "sword_swing");
```

## Bundle Naming Conventions

- Use lowercase with no spaces
- Use descriptive names
- Add `.bundle` extension
- Example: `itemicons.bundle`, `npcmodels.bundle`

## Asset Naming Conventions

Within bundles, use:
- Lowercase with underscores: `fire_sword_icon`
- Descriptive names that match your code: `merchant_idle_anim`
- Consistent prefixes: `icon_`, `model_`, `anim_`, `sound_`

## Performance Tips

- Keep bundle sizes reasonable (under 50MB per bundle)
- Use appropriate texture sizes (icons: 256x256, models: 1024x1024)
- Compress textures in Unity import settings
- Unload bundles when no longer needed

## Git Ignore

Asset bundles are binary files and typically shouldn't be committed to Git. They are automatically ignored by the `.gitignore` file. Instead:

1. Commit your Unity project with source assets
2. Build bundles from the Unity project
3. Copy bundles to this folder for testing
4. For releases, include bundles in the release package

## Example Asset Bundle

To help you get started, here's what an item icon bundle might contain:

**itemicons.bundle:**
- fire_sword_icon.png (256x256)
- health_potion_icon.png (256x256)
- multitool_icon.png (256x256)

Each icon should be:
- 256x256 or 512x512 pixels
- PNG format with transparency
- Set as "Sprite (2D and UI)" in Unity
- Assigned to the `itemicons` bundle

## Need Help?

- Read the [Asset Bundle Creation Guide](../docs/ASSET_BUNDLES.md)
- Check the [Modding Guide](../docs/MODDING_GUIDE.md)
- Review the Unity documentation
- Ask in the Schedule 1 modding community
