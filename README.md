# Syberia Noir

A MelonLoader mod for **Syberia: The World Before** that turns the game black & white – film noir,
sepia or a worn 1930s newsreel – with one key. Uses the game's own post-processing (HDRP), so menus,
the diary and subtitles stay in colour.

Built on [LibriaMods.Shared](https://github.com/LibriaMods/LibriaMods.Shared).

## Install

1. Install [MelonLoader](https://github.com/LavaGang/MelonLoader/releases) 0.6+ (tested with 0.7.3) and run the game once.
2. Extract the zip into the game folder (next to `SyberiaTWB.exe`):
   ```
   Mods\LibriaMods.Loader.dll
   UserLibs\LibriaMods.Shared.dll
   UserData\LibriaMods\Mods\LibriaMods.STWB.Noir.dll
   ```

## Keys (defaults)

| Key | Action |
|---|---|
| **F9** | Effect on/off |
| **F10** | Next preset: Noir → Sepia → Old Film → your own → off |
| **F11** | Re-read a custom preset file (for tweaking) |

## Settings – `UserData\LibriaMods\LibriaMods.STWB.Noir.cfg`

| Setting | Default | |
|---|---|---|
| `ToggleKey` / `CycleKey` / `ReloadKey` | `F9` / `F10` / `F11` | Unity `KeyCode` names |
| `Preset` | `Noir` | Preset used by F9 (`Noir`, `Sepia`, `Old Film` or a custom one) |
| `Enabled` | `false` | Effect on at startup (saved when you toggle) |
| `FadeSeconds` | `0.6` | Fade time |
| `VerboseLog` | `false` | Log every applied setting |

## Your own looks

Drop `.ini` presets in `UserData\LibriaMods\Presets` – see the
[preset format](https://github.com/LibriaMods/LibriaMods.Shared#custom-presets). Edit, press F11, see the result.

Works nicely with [Kate's Pace](https://github.com/LibriaMods/KatesPace).

## Building

Clone this repo and [LibriaMods.Shared](https://github.com/LibriaMods/LibriaMods.Shared) side by side and
open `LibriaMods.STWB.Noir.slnx`. Unity and MelonLoader come from NuGet, so it builds without the game.

If Syberia is installed, the build also installs it: the mod to `UserData\LibriaMods\Mods` (hot-reloaded by the
loader when `AutoReload = true`), the loader to `Mods` and the shared library to `UserLibs`.
It looks in the default Steam folder; for another location create `LibriaMods.user.props` in the folder
that contains both repos:

```xml
<Project>
  <PropertyGroup>
    <SyberiaTWBDir>D:\Games\Syberia - The World Before</SyberiaTWBDir>
  </PropertyGroup>
</Project>
```
