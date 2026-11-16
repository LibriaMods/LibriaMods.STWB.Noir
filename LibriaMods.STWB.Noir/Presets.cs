using System.Collections.Generic;

using LibriaMods.Shared;

namespace LibriaMods.STWB.Noir
{
    /// <summary>
    /// Syberia Noir's built-in presets, tuned on Syberia: The World Before (a dark HDRP game). They live in the mod,
    /// not in LibriaMods.Shared, so the loader's hot reload picks up changes. Each targets HDRP, URP and PPv2 at once
    /// (sections a pipeline doesn't have are skipped); [FilmDamage] and [Screen] are LibriaMods' own overlays.
    /// A custom .ini with the same name in <see cref="Fx.CustomPresetsFolder"/> replaces a built-in preset.
    /// Black &amp; white with a tint uses the Channel Mixer: HDRP applies saturation after tinting,
    /// so "saturation = -100" would wipe the tint out.
    /// </summary>
    public static class Presets
    {
        /// <summary>Black & white, punchy contrast, light grain and vignette.</summary>
        public static Preset Noir => Preset.Parse(@"
name = Noir
[ColorAdjustments]
saturation   = -100
contrast     = 28
postExposure = 0.98
[LiftGammaGain]
gamma = 1, 1, 1, 0.03
[FilmGrain]
type      = Medium3
intensity = 0.3
response  = 0.8
[Vignette]
intensity  = 0.3
smoothness = 0.45
[ColorGrading]
saturation   = -100
contrast     = 28
postExposure = 0.98
[Grain]
intensity  = 0.3
size       = 1.2
lumContrib = 0.8
", "Noir");

        /// <summary>Black & white with the blue tone of old prints and CRT TVs (Channel Mixer, so the tint survives).</summary>
        public static Preset NoirCold => Preset.Parse(@"
name = Noir Cold
[ChannelMixer]
redOutRedIn     = 26
redOutGreenIn   = 50
redOutBlueIn    = 9
greenOutRedIn   = 29
greenOutGreenIn = 57
greenOutBlueIn  = 11
blueOutRedIn    = 48
blueOutGreenIn  = 84
blueOutBlueIn   = 14
[ColorAdjustments]
contrast     = 28
postExposure = 0.98
[FilmGrain]
type      = Medium3
intensity = 0.3
response  = 0.8
[Vignette]
intensity  = 0.3
smoothness = 0.45
[ColorGrading]
mixerRedOutRedIn     = 26
mixerRedOutGreenIn   = 50
mixerRedOutBlueIn    = 9
mixerGreenOutRedIn   = 29
mixerGreenOutGreenIn = 57
mixerGreenOutBlueIn  = 11
mixerBlueOutRedIn    = 48
mixerBlueOutGreenIn  = 84
mixerBlueOutBlueIn   = 14
contrast     = 28
postExposure = 0.98
[Grain]
intensity  = 0.3
size       = 1.2
lumContrib = 0.8
", "NoirCold");

        /// <summary>Warm old photograph via the classic sepia colour matrix (Channel Mixer).</summary>
        public static Preset Sepia => Preset.Parse(@"
name = Sepia
[ChannelMixer]
redOutRedIn     = 39
redOutGreenIn   = 77
redOutBlueIn    = 19
greenOutRedIn   = 35
greenOutGreenIn = 69
greenOutBlueIn  = 17
blueOutRedIn    = 27
blueOutGreenIn  = 53
blueOutBlueIn   = 13
[ColorAdjustments]
contrast     = 8
postExposure = 1.0
[Vignette]
intensity  = 0.2
smoothness = 0.5
[ColorGrading]
mixerRedOutRedIn     = 39
mixerRedOutGreenIn   = 77
mixerRedOutBlueIn    = 19
mixerGreenOutRedIn   = 35
mixerGreenOutGreenIn = 69
mixerGreenOutBlueIn  = 17
mixerBlueOutRedIn    = 27
mixerBlueOutGreenIn  = 53
mixerBlueOutBlueIn   = 13
contrast     = 8
postExposure = 1.0
", "Sepia");

        /// <summary>Noir colours plus a worn print: grain, vignette, light scratches, dust and flicker.</summary>
        public static Preset OldFilm => Preset.Parse(@"
name = Old Film
[ColorAdjustments]
saturation   = -100
contrast     = 28
postExposure = 0.98
[LiftGammaGain]
gamma = 1, 1, 1, 0.03
[FilmGrain]
type      = Large02
intensity = 0.45
response  = 0.7
[Vignette]
intensity  = 0.35
smoothness = 0.4
roundness  = 0.8
[FilmDamage]
amount    = 0.45
bands     = 0
rolls     = 0
scratches = 0.8
dust      = 0.8
hairs     = 0.6
burns     = 0.2
flicker   = 0.6
pops      = 0.3
[ColorGrading]
saturation   = -100
contrast     = 28
postExposure = 0.98
[Grain]
intensity  = 0.45
size       = 1.6
lumContrib = 0.7
", "OldFilm");

        /// <summary>Noir colours plus a badly damaged print: bands, rolls, burns, scratches, dust.</summary>
        public static Preset DamagedFilm => Preset.Parse(@"
name = Damaged Film
[ColorAdjustments]
saturation   = -100
contrast     = 28
postExposure = 0.98
[LiftGammaGain]
gamma = 1, 1, 1, 0.03
[FilmGrain]
type      = Large02
intensity = 0.55
response  = 0.6
[Vignette]
intensity  = 0.4
smoothness = 0.4
[ChromaticAberration]
intensity = 0.1
[FilmDamage]
amount    = 0.6
bands     = 0.5
rolls     = 0.4
scratches = 1
dust      = 1
hairs     = 0.8
burns     = 0.5
flicker   = 0.8
pops      = 0.5
[ColorGrading]
saturation   = -100
contrast     = 28
postExposure = 0.98
[Grain]
intensity  = 0.55
size       = 1.8
lumContrib = 0.6
", "DamagedFilm");

        /// <summary>Worn VHS tape: washed colours, colour bleed, glow, tracking noise, faint scanlines.</summary>
        public static Preset Vhs => Preset.Parse(@"
name = VHS
[ColorAdjustments]
saturation   = -20
contrast     = 25
postExposure = 1.0
[WhiteBalance]
temperature = 6
tint        = 6
[ChromaticAberration]
intensity = 0.7
[Bloom]
intensity = 0.35
scatter   = 0.8
[FilmGrain]
type      = Thin2
intensity = 0.35
response  = 0.5
[Vignette]
intensity  = 0.25
smoothness = 0.5
[Screen]
scanlines = 0.12
lines     = 240
snow      = 0.06
[FilmDamage]
amount    = 0.5
bands     = 0.8
rolls     = 0.5
scratches = 0
dust      = 0
hairs     = 0
burns     = 0
flicker   = 0.3
pops      = 0
fps       = 30
[ColorGrading]
saturation   = -20
contrast     = 25
postExposure = 1.0
temperature  = 6
tint         = 6
[Grain]
intensity  = 0.35
size       = 1
lumContrib = 0.5
", "VHS");

        /// <summary>Old CRT television: curved tube with rounded corners, scanlines, RGB mask, glow and a slow refresh bar.</summary>
        public static Preset Crt => Preset.Parse(@"
name = CRT
[ColorAdjustments]
saturation   = 10
contrast     = 28
postExposure = 1.5
[LensDistortion]
intensity = -0.18
scale     = 0.95
[ChromaticAberration]
intensity = 0.3
[Bloom]
intensity = 0.5
scatter   = 0.7
[Vignette]
intensity  = 0.35
smoothness = 0.4
roundness  = 0.6
[Screen]
scanlines = 0.3
lines     = 360
bezel     = 0.25
[ColorGrading]
saturation   = 10
contrast     = 28
postExposure = 1.5
", "CRT");

        /// <summary>1950s Technicolor: rich saturated colour, deep reds, teal shadows, warm highlights.</summary>
        public static Preset Technicolor => Preset.Parse(@"
name = Technicolor
[ColorAdjustments]
saturation   = 45
contrast     = 22
postExposure = 1.3
[ChannelMixer]
redOutRedIn     = 115
redOutGreenIn   = -10
redOutBlueIn    = -5
greenOutRedIn   = -5
greenOutGreenIn = 108
greenOutBlueIn  = -3
blueOutRedIn    = -5
blueOutGreenIn  = -10
blueOutBlueIn   = 115
[SplitToning]
shadows    = 0.1, 0.35, 0.4, 1
highlights = 1, 0.75, 0.45, 1
balance    = 10
[WhiteBalance]
temperature = 8
[Bloom]
intensity = 0.25
scatter   = 0.7
[FilmGrain]
type      = Medium1
intensity = 0.15
response  = 0.8
[Vignette]
intensity  = 0.25
smoothness = 0.45
[ColorGrading]
saturation   = 45
contrast     = 22
postExposure = 1.3
temperature  = 8
mixerRedOutRedIn     = 115
mixerRedOutGreenIn   = -10
mixerRedOutBlueIn    = -5
mixerGreenOutRedIn   = -5
mixerGreenOutGreenIn = 108
mixerGreenOutBlueIn  = -3
mixerBlueOutRedIn    = -5
mixerBlueOutGreenIn  = -10
mixerBlueOutBlueIn   = 115
[Grain]
intensity  = 0.15
size       = 1
lumContrib = 0.8
", "Technicolor");

        /// <summary>Home movie on Super 8: warm faded colour, heavy grain, strong vignette, soft flicker.</summary>
        public static Preset Super8 => Preset.Parse(@"
name = Super 8
[ColorAdjustments]
saturation   = -12
contrast     = 12
postExposure = 0.9
[WhiteBalance]
temperature = 25
tint        = 5
[LiftGammaGain]
lift = 1, 0.95, 0.85, 0.04
[SplitToning]
shadows    = 0.45, 0.35, 0.25, 1
highlights = 1, 0.85, 0.6, 1
balance    = 0
[FilmGrain]
type      = Large01
intensity = 0.6
response  = 0.6
[Vignette]
intensity  = 0.45
smoothness = 0.4
roundness  = 0.8
[Bloom]
intensity = 0.3
scatter   = 0.75
[FilmDamage]
amount    = 0.4
bands     = 0
rolls     = 0
scratches = 0
dust      = 0
hairs     = 0
burns     = 0
flicker   = 0.3
pops      = 0.1
fps       = 18
[ColorGrading]
saturation   = -12
contrast     = 12
postExposure = 0.9
temperature  = 25
tint         = 5
[Grain]
intensity  = 0.6
size       = 2
lumContrib = 0.6
", "Super8");

        public static IEnumerable<Preset> All
        {
            get
            {
                yield return Noir; yield return NoirCold; yield return Sepia; yield return OldFilm; yield return DamagedFilm;
                yield return Vhs; yield return Crt; yield return Technicolor; yield return Super8;
            }
        }
    }
}
