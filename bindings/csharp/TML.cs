// machine generated, do not edit
using System;
using System.Runtime.InteropServices;
using M = System.Runtime.InteropServices.MarshalAsAttribute;
using U = System.Runtime.InteropServices.UnmanagedType;

using static TinySoundFont.TSF;

namespace TinySoundFont
{
public static unsafe partial class TML
{
public enum TSFOutputMode
{
    TSF_STEREO_INTERLEAVED,
    TSF_STEREO_UNWEAVED,
    TSF_MONO,
}
// Helper union for tml_message: note_on/off (key+vel), control_change (control+val),
// program_change (program), pitch_bend (int), set_tempo (uint) — 4 bytes wide.
[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct tml_union {
    [FieldOffset(0)] public byte key;
    [FieldOffset(1)] public byte vel;
    [FieldOffset(0)] public byte control;
    [FieldOffset(1)] public byte value;
    [FieldOffset(0)] public byte program;
    [FieldOffset(0)] public int pitch_bend;
    [FieldOffset(0)] public uint tempo;
}
[StructLayout(LayoutKind.Sequential)]
public struct tml_message
{
    public uint time;
    public byte type;
    public byte channel;
    public tml_union data; // union: data.key, data.vel, data.control, data.value, data.program, data.pitch_bend, data.tempo
    public tml_message* next;
}
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_load_filename", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_load_filename", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern tml_message* tml_load_filename([M(U.LPUTF8Str)] string filename);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_load_memory", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_load_memory", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern tml_message* tml_load_memory(void* buffer, int size);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_get_info", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_get_info", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tml_get_info(tml_message* first_message, ref int used_channels, ref int used_programs, ref int total_notes, ref uint time_first_note, ref uint time_length);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_get_tempo_value", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_get_tempo_value", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int tml_get_tempo_value(tml_message* set_tempo_message);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_free", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_free", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void tml_free(tml_message* f);

[StructLayout(LayoutKind.Sequential)]
public struct tml_stream
{
    public void* data;
    public delegate* unmanaged<void*, void*, uint, void*> read;
}
#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_load", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_load", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern tml_message* tml_load(tml_stream* stream);

#if __IOS__
[DllImport("@rpath/tsf.framework/tsf", EntryPoint = "tml_load_tsf_stream", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("tsf", EntryPoint = "tml_load_tsf_stream", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern tml_message* tml_load_tsf_stream(tsf_stream* stream);

}
}
