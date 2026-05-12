// machine generated, do not edit
using System;
using System.Runtime.InteropServices;
using M = System.Runtime.InteropServices.MarshalAsAttribute;
using U = System.Runtime.InteropServices.UnmanagedType;

namespace TinySoundFont
{
public static unsafe partial class TSF
{
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_load_filename", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_load_filename", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr tsf_load_filename([M(U.LPUTF8Str)] string filename);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_load_memory", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_load_memory", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr tsf_load_memory(void* buffer, int size);

[StructLayout(LayoutKind.Sequential)]
public struct tsf_stream
{
    public void* data;
    public delegate* unmanaged<void*, void*, uint, void*> read;
    public delegate* unmanaged<void*, uint, void*> skip;
}
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_load", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_load", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr tsf_load(tsf_stream* stream);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_copy", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_copy", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr tsf_copy(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_close", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_close", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_close(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_reset", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_reset", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_reset(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_get_presetindex", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_get_presetindex", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_get_presetindex(IntPtr f, int bank, int preset_number);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_get_presetcount", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_get_presetcount", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_get_presetcount(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_get_presetname", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_get_presetname", CallingConvention = CallingConvention.Cdecl)]
#endif
private static extern IntPtr tsf_get_presetname_native(IntPtr f, int preset_index);

public static string tsf_get_presetname(IntPtr f, int preset_index)
{
    IntPtr ptr = tsf_get_presetname_native(f, preset_index);
    if (ptr == IntPtr.Zero)
        return "";

    // Manual UTF-8 to string conversion to avoid marshalling corruption
    try
    {
        return Marshal.PtrToStringUTF8(ptr) ?? "";
    }
    catch
    {
        // Fallback in case of any marshalling issues
        return "";
    }
}

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_bank_get_presetname", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_bank_get_presetname", CallingConvention = CallingConvention.Cdecl)]
#endif
private static extern IntPtr tsf_bank_get_presetname_native(IntPtr f, int bank, int preset_number);

public static string tsf_bank_get_presetname(IntPtr f, int bank, int preset_number)
{
    IntPtr ptr = tsf_bank_get_presetname_native(f, bank, preset_number);
    if (ptr == IntPtr.Zero)
        return "";

    // Manual UTF-8 to string conversion to avoid marshalling corruption
    try
    {
        return Marshal.PtrToStringUTF8(ptr) ?? "";
    }
    catch
    {
        // Fallback in case of any marshalling issues
        return "";
    }
}

public enum TSFOutputMode
{
    TSF_STEREO_INTERLEAVED,
    TSF_STEREO_UNWEAVED,
    TSF_MONO,
}
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_set_output", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_set_output", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_set_output(IntPtr f, TSFOutputMode outputmode, int samplerate, float global_gain_db);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_set_volume", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_set_volume", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_set_volume(IntPtr f, float global_gain);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_set_max_voices", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_set_max_voices", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_set_max_voices(IntPtr f, int max_voices);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_note_on", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_note_on", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_note_on(IntPtr f, int preset_index, int key, float vel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_bank_note_on", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_bank_note_on", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_bank_note_on(IntPtr f, int bank, int preset_number, int key, float vel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_note_off", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_note_off", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_note_off(IntPtr f, int preset_index, int key);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_bank_note_off", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_bank_note_off", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_bank_note_off(IntPtr f, int bank, int preset_number, int key);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_note_off_all", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_note_off_all", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_note_off_all(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_active_voice_count", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_active_voice_count", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_active_voice_count(IntPtr f);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_render_short", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_render_short", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_render_short(IntPtr f, short* buffer, int samples, int flag_mixing);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_render_float", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_render_float", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_render_float(IntPtr f, ref float buffer, int samples, int flag_mixing);
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_render_float", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_render_float", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_render_float(IntPtr f, float* buffer, int samples, int flag_mixing);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_presetindex", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_presetindex", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_presetindex(IntPtr f, int channel, int preset_index);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_presetnumber", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_presetnumber", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_presetnumber(IntPtr f, int channel, int preset_number, int flag_mididrums);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_bank", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_bank", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_bank(IntPtr f, int channel, int bank);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_bank_preset", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_bank_preset", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_bank_preset(IntPtr f, int channel, int bank, int preset_number);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_pan", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_pan", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_pan(IntPtr f, int channel, float pan);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_volume", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_volume", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_volume(IntPtr f, int channel, float volume);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_pitchwheel", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_pitchwheel", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_pitchwheel(IntPtr f, int channel, int pitch_wheel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_pitchrange", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_pitchrange", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_pitchrange(IntPtr f, int channel, float pitch_range);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_tuning", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_tuning", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_tuning(IntPtr f, int channel, float tuning);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_set_sustain", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_set_sustain", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_set_sustain(IntPtr f, int channel, int flag_sustain);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_note_on", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_note_on", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_note_on(IntPtr f, int channel, int key, float vel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_note_off", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_note_off", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_channel_note_off(IntPtr f, int channel, int key);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_note_off_all", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_note_off_all", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_channel_note_off_all(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_sounds_off_all", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_sounds_off_all", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tsf_channel_sounds_off_all(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_midi_control", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_midi_control", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_midi_control(IntPtr f, int channel, int controller, int control_value);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_preset_index", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_preset_index", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_get_preset_index(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_preset_bank", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_preset_bank", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_get_preset_bank(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_preset_number", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_preset_number", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_get_preset_number(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_pan", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_pan", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float tsf_channel_get_pan(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_volume", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_volume", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float tsf_channel_get_volume(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_pitchwheel", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_pitchwheel", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tsf_channel_get_pitchwheel(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_pitchrange", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_pitchrange", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float tsf_channel_get_pitchrange(IntPtr f, int channel);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tsf_channel_get_tuning", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tsf_channel_get_tuning", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float tsf_channel_get_tuning(IntPtr f, int channel);

}
}
