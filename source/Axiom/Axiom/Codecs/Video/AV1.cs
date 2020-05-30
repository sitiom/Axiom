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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Controls
{
    namespace Video
    {
        namespace Codec
        {
            public class AV1
            {
                // ---------------------------------------------------------------------------
                // Codec
                // ---------------------------------------------------------------------------
                public static List<ViewModel.Video.VideoCodec> codec = new List<ViewModel.Video.VideoCodec>()
                {
                     new ViewModel.Video.VideoCodec()
                     {
                         Codec = "libaom-av1",
                         Parameters = "-strict -2"
                     }
                };

                public static void Codec_Set()
                {
                    // Combine Codec + Parameters
                    List<string> codec = new List<string>()
                    {
                        "-c:v",
                        AV1.codec.FirstOrDefault()?.Codec,
                        AV1.codec.FirstOrDefault()?.Parameters
                    };

                    VM.VideoView.Video_Codec = string.Join(" ", codec.Where(s => !string.IsNullOrEmpty(s)));
                }



                // ---------------------------------------------------------------------------
                // Items Source
                // ---------------------------------------------------------------------------

                // -------------------------
                // Encode Speed
                // -------------------------
                public static List<ViewModel.Video.VideoEncodeSpeed> encodeSpeed = new List<ViewModel.Video.VideoEncodeSpeed>()
                {
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "none",       Command = ""},
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Placebo",    Command = "-cpu-used 0" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Very Slow",  Command = "-cpu-used 0" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Slower",     Command = "-cpu-used 0" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Slow",       Command = "-cpu-used 0" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Medium",     Command = "-cpu-used 1" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Fast",       Command = "-cpu-used 1" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Faster",     Command = "-cpu-used 2" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Very Fast",  Command = "-cpu-used 3" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Super Fast", Command = "-cpu-used 4" },
                     new ViewModel.Video.VideoEncodeSpeed() { Name = "Ultra Fast", Command = "-cpu-used 5" }
                };

                // -------------------------
                // Pixel Format
                // -------------------------
                public static List<string> pixelFormat = new List<string>()
                {
                    "auto",
                    "yuv420p",
                    "yuv420p10le",
                    "yuv420p12le",
                    "yuv422p",
                    "yuv422p10le",
                    "yuv422p12le",
                    "yuv444p",
                    "yuv444p10le",
                    "yuv444p12le"
                };

                // -------------------------
                // Quality
                // -------------------------
                public static List<ViewModel.Video.VideoQuality> quality = new List<ViewModel.Video.VideoQuality>()
                {
                     new ViewModel.Video.VideoQuality() { Name = "Auto",      CRF = "",   CBR_BitMode = "-b:v", CBR = "",      VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="", NA = "3000K" },
                     new ViewModel.Video.VideoQuality() { Name = "Ultra",     CRF = "16", CBR_BitMode = "-b:v", CBR = "5000K", VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" },
                     new ViewModel.Video.VideoQuality() { Name = "High",      CRF = "20", CBR_BitMode = "-b:v", CBR = "2500K", VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" },
                     new ViewModel.Video.VideoQuality() { Name = "Medium",    CRF = "25", CBR_BitMode = "-b:v", CBR = "1300K", VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" },
                     new ViewModel.Video.VideoQuality() { Name = "Low",       CRF = "35", CBR_BitMode = "-b:v", CBR = "600K",  VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" },
                     new ViewModel.Video.VideoQuality() { Name = "Sub",       CRF = "45", CBR_BitMode = "-b:v", CBR = "250K",  VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" },
                     new ViewModel.Video.VideoQuality() { Name = "Custom",    CRF = "",   CBR_BitMode = "-b:v", CBR = "",      VBR_BitMode = "", VBR = "", MinRate = "", MaxRate = "", BufSize ="" }
                };

                // -------------------------
                // Pass
                // -------------------------
                public static void EncodingPass()
                {
                    // -------------------------
                    // Quality
                    // -------------------------
                    switch (VM.VideoView.Video_Quality_SelectedItem)
                    {
                        // Auto
                        case "Auto":
                            VM.VideoView.Video_Pass_Items = new List<string>()
                            {
                                "2 Pass"
                            };

                            VM.VideoView.Video_Pass_SelectedItem = "2 Pass";
                            VM.VideoView.Video_Pass_IsEnabled = false;
                            Controls.passUserSelected = false;

                            VM.VideoView.Video_CRF_IsEnabled = false;
                            break;

                        // Custom
                        case "Custom":
                            VM.VideoView.Video_Pass_Items = new List<string>()
                            {
                                "CRF",
                                "1 Pass",
                                "2 Pass"
                            };

                            VM.VideoView.Video_Pass_IsEnabled = true;
                            VM.VideoView.Video_CRF_IsEnabled = true;
                            break;

                        // None
                        case "None":
                            VM.VideoView.Video_Pass_Items = new List<string>()
                            {
                                "auto"
                            };

                            VM.VideoView.Video_Pass_IsEnabled = false;
                            VM.VideoView.Video_CRF_IsEnabled = false;
                            break;

                        // Presets: Ultra, High, Medium, Low, Sub
                        default:
                            VM.VideoView.Video_Pass_Items = new List<string>()
                            {
                                "CRF",
                                "1 Pass",
                                "2 Pass"
                            };

                            VM.VideoView.Video_Pass_IsEnabled = true;
                            VM.VideoView.Video_CRF_IsEnabled = false;

                            // Default to CRF
                            if (Controls.passUserSelected == false)
                            {
                                VM.VideoView.Video_Pass_SelectedItem = "CRF";
                                Controls.passUserSelected = true;
                            }
                            break;
                    }

                    // Clear TextBoxes
                    if (VM.VideoView.Video_Quality_SelectedItem == "Auto" ||
                        VM.VideoView.Video_Quality_SelectedItem == "Lossless" ||
                        VM.VideoView.Video_Quality_SelectedItem == "Custom" ||
                        VM.VideoView.Video_Quality_SelectedItem == "None"
                        )
                    {
                        VM.VideoView.Video_CRF_Text = string.Empty;
                        VM.VideoView.Video_BitRate_Text = string.Empty;
                        VM.VideoView.Video_MinRate_Text = string.Empty;
                        VM.VideoView.Video_MaxRate_Text = string.Empty;
                        VM.VideoView.Video_BufSize_Text = string.Empty;
                    }

                }

                // -------------------------
                // Optimize
                // -------------------------
                public static List<ViewModel.Video.VideoOptimize> optimize = new List<ViewModel.Video.VideoOptimize>()
                {
                    new ViewModel.Video.VideoOptimize() { Name = "None", Tune = "none", Profile = "none", Level = "none", Command = "" },
                };

                // -------------------------
                // Tune
                // -------------------------
                public static List<string> tune = new List<string>()
                {
                    "none"
                };

                // -------------------------
                // Profile
                // -------------------------
                public static List<string> profile = new List<string>()
                {
                    "none"
                };

                // -------------------------
                // Level
                // -------------------------
                public static List<string> level = new List<string>()
                {
                    "none"
                };



                // ---------------------------------------------------------------------------
                // Controls Behavior
                // ---------------------------------------------------------------------------

                // -------------------------
                // Items Source
                // -------------------------
                public static void Controls_ItemsSource()
                {
                    // Encode Speed
                    VM.VideoView.Video_EncodeSpeed_Items = encodeSpeed;

                    // Pixel Format
                    VM.VideoView.Video_PixelFormat_Items = pixelFormat;

                    // Pass
                    //VM.VideoView.Video_Pass_Items = pass;
                    EncodingPass();

                    // Video Quality
                    VM.VideoView.Video_Quality_Items = quality;

                    // Optimize
                    VM.VideoView.Video_Optimize_Items = optimize;
                    // Tune
                    VM.VideoView.Video_Optimize_Tune_Items = tune;
                    // Profile
                    VM.VideoView.Video_Optimize_Profile_Items = profile;
                    // Level
                    VM.VideoView.Video_Optimize_Level_Items = level;
                }

                // -------------------------
                // Selected Items
                // -------------------------
                public static void Controls_Selected()
                {
                    // Pixel Format
                    VM.VideoView.Video_PixelFormat_SelectedItem = "yuv420p";

                    // Framerate
                    VM.VideoView.Video_FPS_SelectedItem = "auto";
                }


                // -------------------------
                // Expanded
                // -------------------------
                public static void Controls_Expanded()
                {
                    // None
                }

                // -------------------------
                // Collapsed
                // -------------------------
                public static void Controls_Collapsed()
                {
                    VM.VideoView.Video_Optimize_IsExpanded = false;
                }


                // -------------------------
                // Checked
                // -------------------------
                public static void Controls_Checked()
                {
                    // None
                }

                // -------------------------
                // Unchecked
                // -------------------------
                public static void Controls_Unhecked()
                {
                    // BitRate Mode
                    VM.VideoView.Video_VBR_IsChecked = false;
                }


                // -------------------------
                // Enabled
                // -------------------------
                public static void Controls_Enable()
                {
                    // Video Encode Speed
                    VM.VideoView.Video_EncodeSpeed_IsEnabled = true;

                    // HW Accel
                    VM.VideoView.Video_HWAccel_IsEnabled = true;

                    // Video Codec
                    VM.VideoView.Video_Codec_IsEnabled = true;

                    // Video Quality
                    VM.VideoView.Video_Quality_IsEnabled = true;

                    // Pixel Format
                    VM.VideoView.Video_PixelFormat_IsEnabled = true;

                    // FPS ComboBox
                    VM.VideoView.Video_FPS_IsEnabled = true;

                    // Speed
                    VM.VideoView.Video_Speed_IsEnabled = true;

                    // Size
                    VM.VideoView.Video_Scale_IsEnabled = true;

                    // Scaling ComboBox
                    VM.VideoView.Video_ScalingAlgorithm_IsEnabled = true;

                    // Crop
                    VM.VideoView.Video_Crop_IsEnabled = true;


                    // Color Range
                    VM.VideoView.Video_Color_Range_IsEnabled = true;

                    // Color Space
                    VM.VideoView.Video_Color_Space_IsEnabled = true;

                    // Color Primaries
                    VM.VideoView.Video_Color_Primaries_IsEnabled = true;

                    // Color Transfer Characteristics
                    VM.VideoView.Video_Color_TransferCharacteristics_IsEnabled = true;

                    // Color Matrix
                    VM.VideoView.Video_Color_Matrix_IsEnabled = true;


                    // Subtitle Codec
                    VM.SubtitleView.Subtitle_Codec_IsEnabled = true;

                    // Subtitle Stream
                    VM.SubtitleView.Subtitle_Stream_IsEnabled = true;


                    // Filters
                    Filters.Video.VideoFilters_EnableAll();
                }

                // -------------------------
                // Disabled
                // -------------------------
                public static void Controls_Disable()
                {
                    // Video VBR
                    VM.VideoView.Video_VBR_IsEnabled = false;

                    // Optimize ComboBox
                    VM.VideoView.Video_Optimize_IsEnabled = false;
                }
            }
        }
    }
}
