﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2020 Matt McManis
https://github.com/MattMcManis/Axiom
https://axiomui.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Controls.Audio.Codec
{
    public class DTS : Controls.IAudioCodec
    {
        // ---------------------------------------------------------------------------
        // Codec
        // ---------------------------------------------------------------------------
        public ObservableCollection<ViewModel.Audio.AudioCodec> codec { get; set; } = new ObservableCollection<ViewModel.Audio.AudioCodec>()
        {
            new ViewModel.Audio.AudioCodec() { Codec = "dca", Parameters = "-strict -2" }
        };


        // ---------------------------------------------------------------------------
        // Items Source
        // ---------------------------------------------------------------------------

        // -------------------------
        // Channel
        // -------------------------
        public ObservableCollection<string> channel { get; set; } = new ObservableCollection<string>()
        {
            "Source",
            "Mono",
            "Stereo",
            "5.1"
        };

        // -------------------------
        // Quality
        // -------------------------
        public ObservableCollection<ViewModel.Audio.AudioQuality> quality { get; set; } = new ObservableCollection<ViewModel.Audio.AudioQuality>()
        {
            new ViewModel.Audio.AudioQuality() { Name = "Auto",   CBR_BitMode = "-b:a", CBR = "",     VBR_BitMode = "", VBR = "", NA = "1509" },
            new ViewModel.Audio.AudioQuality() { Name = "1509",   CBR_BitMode = "-b:a", CBR = "1509", VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "755",    CBR_BitMode = "-b:a", CBR = "755",  VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "640",    CBR_BitMode = "-b:a", CBR = "640",  VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "448",    CBR_BitMode = "-b:a", CBR = "448",  VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "320",    CBR_BitMode = "-b:a", CBR = "320",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "256",    CBR_BitMode = "-b:a", CBR = "256",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "224",    CBR_BitMode = "-b:a", CBR = "224",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "192",    CBR_BitMode = "-b:a", CBR = "192",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "160",    CBR_BitMode = "-b:a", CBR = "160",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "128",    CBR_BitMode = "-b:a", CBR = "128",  VBR_BitMode = "", VBR = "" },
            //new ViewModel.Audio.AudioQuality() { Name = "96",     CBR_BitMode = "-b:a", CBR = "96",   VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "Custom", CBR_BitMode = "-b:a", CBR = "",     VBR_BitMode = "", VBR = "" },
            new ViewModel.Audio.AudioQuality() { Name = "Mute",   CBR_BitMode = "",     CBR = "",     VBR_BitMode = "", VBR = "" }
        };

        // -------------------------
        // Compression Level
        // -------------------------
        public ObservableCollection<string> compressionLevel { get; set; } = new ObservableCollection<string>()
        {
            "auto"
        };

        // -------------------------
        // Sample Rate
        // -------------------------
        public ObservableCollection<ViewModel.Audio.AudioSampleRate> sampleRate { get; set; } = new ObservableCollection<ViewModel.Audio.AudioSampleRate>()
        {
            new ViewModel.Audio.AudioSampleRate() { Name = "auto",     Frequency = "" },
            new ViewModel.Audio.AudioSampleRate() { Name = "8k",       Frequency = "8000" },
            new ViewModel.Audio.AudioSampleRate() { Name = "11.025k",  Frequency = "11025" },
            new ViewModel.Audio.AudioSampleRate() { Name = "12k",      Frequency = "12000" },
            new ViewModel.Audio.AudioSampleRate() { Name = "16k",      Frequency = "16000" },
            new ViewModel.Audio.AudioSampleRate() { Name = "22.05k",   Frequency = "22050" },
            new ViewModel.Audio.AudioSampleRate() { Name = "24k",      Frequency = "24000" },
            new ViewModel.Audio.AudioSampleRate() { Name = "32k",      Frequency = "32000" },
            new ViewModel.Audio.AudioSampleRate() { Name = "44.1k",    Frequency = "44100" },
            new ViewModel.Audio.AudioSampleRate() { Name = "48k",      Frequency = "48000" },
        };

        // -------------------------
        // Bit Depth
        // -------------------------
        public ObservableCollection<ViewModel.Audio.AudioBitDepth> bitDepth { get; set; } = new ObservableCollection<ViewModel.Audio.AudioBitDepth>()
        {
            new ViewModel.Audio.AudioBitDepth() { Name = "auto", Depth = "" }
        };



        // ---------------------------------------------------------------------------
        // Controls Behavior
        // ---------------------------------------------------------------------------

        // -------------------------
        // Selected Items
        // -------------------------
        public List<ViewModel.Audio.Selected> controls_Selected { get; set; } = new List<ViewModel.Audio.Selected>()
        {
            new ViewModel.Audio.Selected() {  CompressionLevel = "auto" },
        };

        // -------------------------
        // Checked
        // -------------------------
        public List<ViewModel.Audio.Checked> controls_Checked { get; set; } = new List<ViewModel.Audio.Checked>()
        {
            new ViewModel.Audio.Checked() {  VBR = false },
        };

        // -------------------------
        // Enabled
        // -------------------------
        public List<ViewModel.Audio.Enabled> controls_Enabled { get; set; } = new List<ViewModel.Audio.Enabled>()
        {
            new ViewModel.Audio.Enabled() {  Codec =            true },
            new ViewModel.Audio.Enabled() {  Stream =           true },
            new ViewModel.Audio.Enabled() {  Channel =          true },
            new ViewModel.Audio.Enabled() {  Quality =          true },
            new ViewModel.Audio.Enabled() {  CompressionLevel = false },
            new ViewModel.Audio.Enabled() {  VBR =              true },
            new ViewModel.Audio.Enabled() {  SampleRate =       true },
            new ViewModel.Audio.Enabled() {  BitDepth =         false },
            new ViewModel.Audio.Enabled() {  Volume =           true },
            new ViewModel.Audio.Enabled() {  HardLimiter =      true },
        };

    }
}
