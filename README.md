# Syberia Noir

A MelonLoader mod for **Syberia: The World Before** that turns the game black & white – film noir,
sepia, a worn 1930s newsreel or a badly damaged print – or an old VHS tape, a CRT TV, 1950s Technicolor or a Super 8 home movie, with one key. Uses the game's own post-processing (HDRP), so menus,
the diary and subtitles stay in colour.

Download: [Nexus Mods](https://www.nexusmods.com/syberiatheworldbefore/mods/6) · [GitHub releases](https://github.com/LibriaMods/LibriaMods.STWB.Noir/releases)

Built on [LibriaMods.Unity.Shared](https://github.com/LibriaMods/LibriaMods.Unity.Shared).

## Install

1. Install [MelonLoader](https://github.com/LavaGang/MelonLoader/releases) 0.6+ (tested with 0.7.3) and run the game once.
2. Extract the zip into the game folder (next to `SyberiaTWB.exe`):
   ```
   Mods\LibriaMods.Unity.Loader.dll
   UserLibs\LibriaMods.Unity.Shared.dll
   UserData\LibriaMods\Mods\LibriaMods.STWB.Noir.dll
   ```

## Keys (defaults)

| Key | Action |
|---|---|
| **F9** | Effect on/off |
| **F10** | Next preset (see below) → your own → off |
| **F11** | Re-read a custom preset file (for tweaking) |

## Presets

| Preset | Look |
|---|---|
| **Noir** | Black & white, punchy contrast, light grain and vignette |
| **Noir Cold** | Black & white with the blue tone of old film prints and CRT TVs |
| **Sepia** | Warm old photograph |
| **Old Film** | Noir plus a worn print: scratches, dust, hairs, flicker |
| **Damaged Film** | Noir plus a badly damaged print: tracking bands, rolls, burns, scratches, dust |
| **VHS** | Washed-out colour, colour bleed, glow, tracking noise, faint scanlines |
| **CRT** | Curved tube with rounded corners, scanlines, glow |
| **Technicolor** | Rich 1950s colour: deep reds, teal shadows, warm highlights |
| **Super 8** | Home movie: warm faded colour, heavy grain, strong vignette, soft flicker |

The presets are in [`Presets.cs`](LibriaMods.STWB.Noir/Presets.cs), in the mod itself, so with the loader's
`AutoReload = true` a rebuild shows up in game straight away.

## Settings – `UserData\LibriaMods\LibriaMods.STWB.Noir.cfg`

| Setting | Default | |
|---|---|---|
| `ToggleKey` / `CycleKey` / `ReloadKey` | `F9` / `F10` / `F11` | Unity `KeyCode` names |
| `Preset` | `Noir` | Preset used by F9 (any preset name below, or a custom one) |
| `Enabled` | `false` | Effect on at startup (saved when you toggle) |
| `FadeSeconds` | `0.6` | Fade time |
| `VerboseLog` | `false` | Log every applied setting |

## Your own looks

Drop `.ini` presets in `UserData\LibriaMods\Presets` – see the
[preset format](https://github.com/LibriaMods/LibriaMods.Unity.Shared#custom-presets). Edit, press F11, see the result.

Works nicely with [Kate's Pace](https://github.com/LibriaMods/KatesPace).

## Building

Clone this repo and [LibriaMods.Unity.Shared](https://github.com/LibriaMods/LibriaMods.Unity.Shared) side by side and
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
