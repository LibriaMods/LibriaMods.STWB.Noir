using LibriaMods.Shared;
using UnityEngine;

namespace LibriaMods.STWB.Noir
{
    /// <summary>
    /// Black & white "film noir" look for Syberia: The World Before.
    /// Settings: UserData\LibriaMods\LibriaMods.STWB.Noir.cfg
    /// </summary>
    [LibriaMod("Syberia Noir", "1.0.0", Id = "LibriaMods.STWB.Noir")]
    [LibriaGame("Microids", "SyberiaTWB")]
    public class NoirMod : LibriaMod
    {
        IConfigEntry<KeyCode> toggleKey, cycleKey, reloadKey;
        IConfigEntry<string> preset;
        IConfigEntry<bool> enabled, verboseLog;
        IConfigEntry<float> fadeSeconds;

        public override void OnLoad(IModContext context)
        {
            base.OnLoad(context);
            toggleKey   = context.Config("ToggleKey", KeyCode.F9, "Turn the effect on/off");
            cycleKey    = context.Config("CycleKey", KeyCode.F10, "Next preset: Noir, Noir Cold, Sepia, Old Film, Damaged Film, VHS, CRT, Technicolor, Super 8, your own .ini files, off");
            reloadKey   = context.Config("ReloadKey", KeyCode.F11, "Re-read a custom .ini preset and apply it again (for tweaking)");
            preset      = context.Config("Preset", "Noir", "Preset used by ToggleKey. Built-in: Noir, Noir Cold, Sepia, Old Film, Damaged Film, VHS, CRT, Technicolor, Super 8. Custom: .ini files in UserData\\LibriaMods\\Presets");
            enabled     = context.Config("Enabled", false, "Effect on at startup (saved automatically)");
            fadeSeconds = context.Config("FadeSeconds", 0.6f, "Fade time (0 = instant)");
            verboseLog  = context.Config("VerboseLog", false, "Log every applied/skipped setting");
            context.SaveConfig();

            Fx.BuiltIn.Clear();
            Fx.BuiltIn.AddRange(Presets.All);
            Fx.Verbose = s => { if (verboseLog.Value) context.Log(s); };
            Fx.FadeSeconds = fadeSeconds.Value;
            if (enabled.Value) Fx.Apply(preset.Value);
        }

        public override void OnUpdate()
        {
            Fx.FadeSeconds = fadeSeconds.Value;

            if (Input.GetKeyDown(toggleKey.Value))
            {
                if (Fx.IsOn) Fx.Off(); else Fx.Apply(preset.Value);
                Save();
            }
            if (Input.GetKeyDown(cycleKey.Value))
            {
                Fx.Cycle(+1);
                if (Fx.Current != null) preset.Value = Fx.Current.Name;
                Save();
            }
            if (Input.GetKeyDown(reloadKey.Value)) Fx.Reload();
        }

        public override void OnUnload()
        {
            // Hot reload: the new instance re-applies the effect if Enabled.
            Fx.Off();
            Fx.BuiltIn.Clear();
            Fx.Verbose = _ => { };
        }

        void Save()
        {
            enabled.Value = Fx.IsOn;
            Context.SaveConfig();
        }
    }
}
