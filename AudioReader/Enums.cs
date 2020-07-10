using System;
using System.Collections.Generic;
using System.Text;

namespace AudioReader
{
    /// <summary>
    /// Summary description for WaveFormatEncoding.
    /// </summary>
    public enum WaveFormatEncoding : ushort
    {
        /// <summary>WAVE_FORMAT_UNKNOWN,	Microsoft Corporation</summary>
        Unknown = 0x0000,

        /// <summary>WAVE_FORMAT_PCM		Microsoft Corporation</summary>
        Pcm = 0x0001,

        /// <summary>WAVE_FORMAT_ADPCM		Microsoft Corporation</summary>
        Adpcm = 0x0002,

        /// <summary>WAVE_FORMAT_IEEE_FLOAT Microsoft Corporation</summary>
        IeeeFloat = 0x0003,

        /// <summary>WAVE_FORMAT_VSELP		Compaq Computer Corp.</summary>
        Vselp = 0x0004,

        /// <summary>WAVE_FORMAT_IBM_CVSD	IBM Corporation</summary>
        IbmCvsd = 0x0005,

        /// <summary>WAVE_FORMAT_ALAW		Microsoft Corporation</summary>
        ALaw = 0x0006,

        /// <summary>WAVE_FORMAT_MULAW		Microsoft Corporation</summary>
        MuLaw = 0x0007,

        /// <summary>WAVE_FORMAT_DTS		Microsoft Corporation</summary>
        Dts = 0x0008,

        /// <summary>WAVE_FORMAT_DRM		Microsoft Corporation</summary>
        Drm = 0x0009,

        /// <summary>WAVE_FORMAT_WMAVOICE9 </summary>
        WmaVoice9 = 0x000A,

        /// <summary>WAVE_FORMAT_OKI_ADPCM	OKI</summary>
        OkiAdpcm = 0x0010,

        /// <summary>WAVE_FORMAT_DVI_ADPCM	Intel Corporation</summary>
        DviAdpcm = 0x0011,

        /// <summary>WAVE_FORMAT_IMA_ADPCM  Intel Corporation</summary>
        ImaAdpcm = DviAdpcm,

        /// <summary>WAVE_FORMAT_MEDIASPACE_ADPCM Videologic</summary>
        MediaspaceAdpcm = 0x0012,

        /// <summary>WAVE_FORMAT_SIERRA_ADPCM Sierra Semiconductor Corp </summary>
        SierraAdpcm = 0x0013,

        /// <summary>WAVE_FORMAT_G723_ADPCM Antex Electronics Corporation </summary>
        G723Adpcm = 0x0014,

        /// <summary>WAVE_FORMAT_DIGISTD DSP Solutions, Inc.</summary>
        DigiStd = 0x0015,

        /// <summary>WAVE_FORMAT_DIGIFIX DSP Solutions, Inc.</summary>
        DigiFix = 0x0016,

        /// <summary>WAVE_FORMAT_DIALOGIC_OKI_ADPCM Dialogic Corporation</summary>
        DialogicOkiAdpcm = 0x0017,

        /// <summary>WAVE_FORMAT_MEDIAVISION_ADPCM Media Vision, Inc.</summary>
        MediaVisionAdpcm = 0x0018,

        /// <summary>WAVE_FORMAT_CU_CODEC Hewlett-Packard Company </summary>
        CUCodec = 0x0019,

        /// <summary>WAVE_FORMAT_YAMAHA_ADPCM Yamaha Corporation of America</summary>
        YamahaAdpcm = 0x0020,

        /// <summary>WAVE_FORMAT_SONARC Speech Compression</summary>
        SonarC = 0x0021,

        /// <summary>WAVE_FORMAT_DSPGROUP_TRUESPEECH DSP Group, Inc </summary>
        DspGroupTrueSpeech = 0x0022,

        /// <summary>WAVE_FORMAT_ECHOSC1 Echo Speech Corporation</summary>
        EchoSpeechCorporation1 = 0x0023,

        /// <summary>WAVE_FORMAT_AUDIOFILE_AF36, Virtual Music, Inc.</summary>
        AudioFileAf36 = 0x0024,

        /// <summary>WAVE_FORMAT_APTX Audio Processing Technology</summary>
        Aptx = 0x0025,

        /// <summary>WAVE_FORMAT_AUDIOFILE_AF10, Virtual Music, Inc.</summary>
        AudioFileAf10 = 0x0026,

        /// <summary>WAVE_FORMAT_PROSODY_1612, Aculab plc</summary>
        Prosody1612 = 0x0027,

        /// <summary>WAVE_FORMAT_LRC, Merging Technologies S.A. </summary>
        Lrc = 0x0028,

        /// <summary>WAVE_FORMAT_DOLBY_AC2, Dolby Laboratories</summary>
        DolbyAc2 = 0x0030,

        /// <summary>WAVE_FORMAT_GSM610, Microsoft Corporation</summary>
        Gsm610 = 0x0031,

        /// <summary>WAVE_FORMAT_MSNAUDIO, Microsoft Corporation</summary>
        MsnAudio = 0x0032,

        /// <summary>WAVE_FORMAT_ANTEX_ADPCME, Antex Electronics Corporation</summary>
        AntexAdpcme = 0x0033,

        /// <summary>WAVE_FORMAT_CONTROL_RES_VQLPC, Control Resources Limited </summary>
        ControlResVqlpc = 0x0034,

        /// <summary>WAVE_FORMAT_DIGIREAL, DSP Solutions, Inc. </summary>
        DigiReal = 0x0035,

        /// <summary>WAVE_FORMAT_DIGIADPCM, DSP Solutions, Inc.</summary>
        DigiAdpcm = 0x0036,

        /// <summary>WAVE_FORMAT_CONTROL_RES_CR10, Control Resources Limited</summary>
        ControlResCr10 = 0x0037,

        /// <summary></summary>
        WAVE_FORMAT_NMS_VBXADPCM = 0x0038, // Natural MicroSystems 
        /// <summary></summary>
        WAVE_FORMAT_CS_IMAADPCM = 0x0039, // Crystal Semiconductor IMA ADPCM 
        /// <summary></summary>
        WAVE_FORMAT_ECHOSC3 = 0x003A, // Echo Speech Corporation 
        /// <summary></summary>
        WAVE_FORMAT_ROCKWELL_ADPCM = 0x003B, // Rockwell International 
        /// <summary></summary>
        WAVE_FORMAT_ROCKWELL_DIGITALK = 0x003C, // Rockwell International 
        /// <summary></summary>
        WAVE_FORMAT_XEBEC = 0x003D, // Xebec Multimedia Solutions Limited 
        /// <summary></summary>
        WAVE_FORMAT_G721_ADPCM = 0x0040, // Antex Electronics Corporation 
        /// <summary></summary>
        WAVE_FORMAT_G728_CELP = 0x0041, // Antex Electronics Corporation 
        /// <summary></summary>
        WAVE_FORMAT_MSG723 = 0x0042, // Microsoft Corporation 
        /// <summary>WAVE_FORMAT_MPEG, Microsoft Corporation </summary>
        Mpeg = 0x0050,

        /// <summary></summary>
        WAVE_FORMAT_RT24 = 0x0052, // InSoft, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_PAC = 0x0053, // InSoft, Inc. 
        /// <summary>WAVE_FORMAT_MPEGLAYER3, ISO/MPEG Layer3 Format Tag </summary>
        MpegLayer3 = 0x0055,

        /// <summary></summary>
        WAVE_FORMAT_LUCENT_G723 = 0x0059, // Lucent Technologies 
        /// <summary></summary>
        WAVE_FORMAT_CIRRUS = 0x0060, // Cirrus Logic 
        /// <summary></summary>
        WAVE_FORMAT_ESPCM = 0x0061, // ESS Technology 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE = 0x0062, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_CANOPUS_ATRAC = 0x0063, // Canopus, co., Ltd. 
        /// <summary></summary>
        WAVE_FORMAT_G726_ADPCM = 0x0064, // APICOM 
        /// <summary></summary>
        WAVE_FORMAT_G722_ADPCM = 0x0065, // APICOM 
        /// <summary></summary>
        WAVE_FORMAT_DSAT_DISPLAY = 0x0067, // Microsoft Corporation 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = 0x0069, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_AC8 = 0x0070, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_AC10 = 0x0071, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_AC16 = 0x0072, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_AC20 = 0x0073, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_RT24 = 0x0074, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_RT29 = 0x0075, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_RT29HW = 0x0076, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_VR12 = 0x0077, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_VR18 = 0x0078, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_TQ40 = 0x0079, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_SOFTSOUND = 0x0080, // Softsound, Ltd. 
        /// <summary></summary>
        WAVE_FORMAT_VOXWARE_TQ60 = 0x0081, // Voxware Inc 
        /// <summary></summary>
        WAVE_FORMAT_MSRT24 = 0x0082, // Microsoft Corporation 
        /// <summary></summary>
        WAVE_FORMAT_G729A = 0x0083, // AT&T Labs, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_MVI_MVI2 = 0x0084, // Motion Pixels 
        /// <summary></summary>
        WAVE_FORMAT_DF_G726 = 0x0085, // DataFusion Systems (Pty) (Ltd) 
        /// <summary></summary>
        WAVE_FORMAT_DF_GSM610 = 0x0086, // DataFusion Systems (Pty) (Ltd) 
        /// <summary></summary>
        WAVE_FORMAT_ISIAUDIO = 0x0088, // Iterated Systems, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_ONLIVE = 0x0089, // OnLive! Technologies, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SBC24 = 0x0091, // Siemens Business Communications Sys 
        /// <summary></summary>
        WAVE_FORMAT_DOLBY_AC3_SPDIF = 0x0092, // Sonic Foundry 
        /// <summary></summary>
        WAVE_FORMAT_MEDIASONIC_G723 = 0x0093, // MediaSonic 
        /// <summary></summary>
        WAVE_FORMAT_PROSODY_8KBPS = 0x0094, // Aculab plc 
        /// <summary></summary>
        WAVE_FORMAT_ZYXEL_ADPCM = 0x0097, // ZyXEL Communications, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_PHILIPS_LPCBB = 0x0098, // Philips Speech Processing 
        /// <summary></summary>
        WAVE_FORMAT_PACKED = 0x0099, // Studer Professional Audio AG 
        /// <summary></summary>
        WAVE_FORMAT_MALDEN_PHONYTALK = 0x00A0, // Malden Electronics Ltd. 
        /// <summary>WAVE_FORMAT_GSM</summary>
        Gsm = 0x00A1,

        /// <summary>WAVE_FORMAT_G729</summary>
        G729 = 0x00A2,

        /// <summary>WAVE_FORMAT_G723</summary>
        G723 = 0x00A3,

        /// <summary>WAVE_FORMAT_ACELP</summary>
        Acelp = 0x00A4,

        /// <summary>
        /// WAVE_FORMAT_RAW_AAC1
        /// </summary>
        RawAac = 0x00FF,
        /// <summary></summary>
        WAVE_FORMAT_RHETOREX_ADPCM = 0x0100, // Rhetorex Inc. 
        /// <summary></summary>
        WAVE_FORMAT_IRAT = 0x0101, // BeCubed Software Inc. 
        /// <summary></summary>
        WAVE_FORMAT_VIVO_G723 = 0x0111, // Vivo Software 
        /// <summary></summary>
        WAVE_FORMAT_VIVO_SIREN = 0x0112, // Vivo Software 
        /// <summary></summary>
        WAVE_FORMAT_DIGITAL_G723 = 0x0123, // Digital Equipment Corporation 
        /// <summary></summary>
        WAVE_FORMAT_SANYO_LD_ADPCM = 0x0125, // Sanyo Electric Co., Ltd. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_ACEPLNET = 0x0130, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_ACELP4800 = 0x0131, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_ACELP8V3 = 0x0132, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_G729 = 0x0133, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_G729A = 0x0134, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SIPROLAB_KELVIN = 0x0135, // Sipro Lab Telecom Inc. 
        /// <summary></summary>
        WAVE_FORMAT_G726ADPCM = 0x0140, // Dictaphone Corporation 
        /// <summary></summary>
        WAVE_FORMAT_QUALCOMM_PUREVOICE = 0x0150, // Qualcomm, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_QUALCOMM_HALFRATE = 0x0151, // Qualcomm, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_TUBGSM = 0x0155, // Ring Zero Systems, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_MSAUDIO1 = 0x0160, // Microsoft Corporation
        /// <summary>
        /// Windows Media Audio, WAVE_FORMAT_WMAUDIO2, Microsoft Corporation
        /// </summary>
        WindowsMediaAudio = 0x0161,

        /// <summary>
        /// Windows Media Audio Professional WAVE_FORMAT_WMAUDIO3, Microsoft Corporation
        /// </summary>
        WindowsMediaAudioProfessional = 0x0162,

        /// <summary>
        /// Windows Media Audio Lossless, WAVE_FORMAT_WMAUDIO_LOSSLESS
        /// </summary>
        WindowsMediaAudioLosseless = 0x0163,

        /// <summary>
        /// Windows Media Audio Professional over SPDIF WAVE_FORMAT_WMASPDIF (0x0164)
        /// </summary>
        WindowsMediaAudioSpdif = 0x0164,

        /// <summary></summary>
        WAVE_FORMAT_UNISYS_NAP_ADPCM = 0x0170, // Unisys Corp. 
        /// <summary></summary>
        WAVE_FORMAT_UNISYS_NAP_ULAW = 0x0171, // Unisys Corp. 
        /// <summary></summary>
        WAVE_FORMAT_UNISYS_NAP_ALAW = 0x0172, // Unisys Corp. 
        /// <summary></summary>
        WAVE_FORMAT_UNISYS_NAP_16K = 0x0173, // Unisys Corp. 
        /// <summary></summary>
        WAVE_FORMAT_CREATIVE_ADPCM = 0x0200, // Creative Labs, Inc 
        /// <summary></summary>
        WAVE_FORMAT_CREATIVE_FASTSPEECH8 = 0x0202, // Creative Labs, Inc 
        /// <summary></summary>
        WAVE_FORMAT_CREATIVE_FASTSPEECH10 = 0x0203, // Creative Labs, Inc 
        /// <summary></summary>
        WAVE_FORMAT_UHER_ADPCM = 0x0210, // UHER informatic GmbH 
        /// <summary></summary>
        WAVE_FORMAT_QUARTERDECK = 0x0220, // Quarterdeck Corporation 
        /// <summary></summary>
        WAVE_FORMAT_ILINK_VC = 0x0230, // I-link Worldwide 
        /// <summary></summary>
        WAVE_FORMAT_RAW_SPORT = 0x0240, // Aureal Semiconductor 
        /// <summary></summary>
        WAVE_FORMAT_ESST_AC3 = 0x0241, // ESS Technology, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_IPI_HSX = 0x0250, // Interactive Products, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_IPI_RPELP = 0x0251, // Interactive Products, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_CS2 = 0x0260, // Consistent Software 
        /// <summary></summary>
        WAVE_FORMAT_SONY_SCX = 0x0270, // Sony Corp. 
        /// <summary></summary>
        WAVE_FORMAT_FM_TOWNS_SND = 0x0300, // Fujitsu Corp. 
        /// <summary></summary>
        WAVE_FORMAT_BTV_DIGITAL = 0x0400, // Brooktree Corporation 
        /// <summary></summary>
        WAVE_FORMAT_QDESIGN_MUSIC = 0x0450, // QDesign Corporation 
        /// <summary></summary>
        WAVE_FORMAT_VME_VMPCM = 0x0680, // AT&T Labs, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_TPC = 0x0681, // AT&T Labs, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_OLIGSM = 0x1000, // Ing C. Olivetti & C., S.p.A. 
        /// <summary></summary>
        WAVE_FORMAT_OLIADPCM = 0x1001, // Ing C. Olivetti & C., S.p.A. 
        /// <summary></summary>
        WAVE_FORMAT_OLICELP = 0x1002, // Ing C. Olivetti & C., S.p.A. 
        /// <summary></summary>
        WAVE_FORMAT_OLISBC = 0x1003, // Ing C. Olivetti & C., S.p.A. 
        /// <summary></summary>
        WAVE_FORMAT_OLIOPR = 0x1004, // Ing C. Olivetti & C., S.p.A. 
        /// <summary></summary>
        WAVE_FORMAT_LH_CODEC = 0x1100, // Lernout & Hauspie 
        /// <summary></summary>
        WAVE_FORMAT_NORRIS = 0x1400, // Norris Communications, Inc. 
        /// <summary></summary>
        WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 0x1500, // AT&T Labs, Inc. 

        /// <summary>
        /// Advanced Audio Coding (AAC) audio in Audio Data Transport Stream (ADTS) format.
        /// The format block is a WAVEFORMATEX structure with wFormatTag equal to WAVE_FORMAT_MPEG_ADTS_AAC.
        /// </summary>
        /// <remarks>
        /// The WAVEFORMATEX structure specifies the core AAC-LC sample rate and number of channels, 
        /// prior to applying spectral band replication (SBR) or parametric stereo (PS) tools, if present.
        /// No additional data is required after the WAVEFORMATEX structure.
        /// </remarks>
        /// <see>http://msdn.microsoft.com/en-us/library/dd317599%28VS.85%29.aspx</see>
        MPEG_ADTS_AAC = 0x1600,

        /// <summary></summary>
        /// <remarks>Source wmCodec.h</remarks>
        MPEG_RAW_AAC = 0x1601,

        /// <summary>
        /// MPEG-4 audio transport stream with a synchronization layer (LOAS) and a multiplex layer (LATM).
        /// The format block is a WAVEFORMATEX structure with wFormatTag equal to WAVE_FORMAT_MPEG_LOAS.
        /// </summary>
        /// <remarks>
        /// The WAVEFORMATEX structure specifies the core AAC-LC sample rate and number of channels, 
        /// prior to applying spectral SBR or PS tools, if present.
        /// No additional data is required after the WAVEFORMATEX structure.
        /// </remarks>
        /// <see>http://msdn.microsoft.com/en-us/library/dd317599%28VS.85%29.aspx</see>
        MPEG_LOAS = 0x1602,

        /// <summary>NOKIA_MPEG_ADTS_AAC</summary>
        /// <remarks>Source wmCodec.h</remarks>
        NOKIA_MPEG_ADTS_AAC = 0x1608,

        /// <summary>NOKIA_MPEG_RAW_AAC</summary>
        /// <remarks>Source wmCodec.h</remarks>
        NOKIA_MPEG_RAW_AAC = 0x1609,

        /// <summary>VODAFONE_MPEG_ADTS_AAC</summary>
        /// <remarks>Source wmCodec.h</remarks>
        VODAFONE_MPEG_ADTS_AAC = 0x160A,

        /// <summary>VODAFONE_MPEG_RAW_AAC</summary>
        /// <remarks>Source wmCodec.h</remarks>
        VODAFONE_MPEG_RAW_AAC = 0x160B,

        /// <summary>
        /// High-Efficiency Advanced Audio Coding (HE-AAC) stream.
        /// The format block is an HEAACWAVEFORMAT structure.
        /// </summary>
        /// <see>http://msdn.microsoft.com/en-us/library/dd317599%28VS.85%29.aspx</see>
        MPEG_HEAAC = 0x1610,

        /// <summary>WAVE_FORMAT_DVM</summary>
        WAVE_FORMAT_DVM = 0x2000, // FAST Multimedia AG 

        // others - not from MS headers
        /// <summary>WAVE_FORMAT_VORBIS1 "Og" Original stream compatible</summary>
        Vorbis1 = 0x674f,

        /// <summary>WAVE_FORMAT_VORBIS2 "Pg" Have independent header</summary>
        Vorbis2 = 0x6750,

        /// <summary>WAVE_FORMAT_VORBIS3 "Qg" Have no codebook header</summary>
        Vorbis3 = 0x6751,

        /// <summary>WAVE_FORMAT_VORBIS1P "og" Original stream compatible</summary>
        Vorbis1P = 0x676f,

        /// <summary>WAVE_FORMAT_VORBIS2P "pg" Have independent headere</summary>
        Vorbis2P = 0x6770,

        /// <summary>WAVE_FORMAT_VORBIS3P "qg" Have no codebook header</summary>
        Vorbis3P = 0x6771,

        /// <summary>WAVE_FORMAT_EXTENSIBLE</summary>
        Extensible = 0xFFFE, // Microsoft 
        /// <summary></summary>
        WAVE_FORMAT_DEVELOPMENT = 0xFFFF,
    }

    /// <summary>
    /// MPEG Version Flags
    /// </summary>
    public enum MpegVersion
    {
        /// <summary>
        /// Version 2.5
        /// </summary>
        Version25,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved,
        /// <summary>
        /// Version 2
        /// </summary>
        Version2,
        /// <summary>
        /// Version 1
        /// </summary>
        Version1
    }

    /// <summary>
    /// MPEG Layer flags
    /// </summary>
    public enum MpegLayer
    {
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved,
        /// <summary>
        /// Layer 3
        /// </summary>
        Layer3,
        /// <summary>
        /// Layer 2
        /// </summary>
        Layer2,
        /// <summary>
        /// Layer 1
        /// </summary>
        Layer1
    }

    /// <summary>
    /// Wave Format Padding Flags
    /// </summary>
    [Flags]
    public enum Mp3WaveFormatFlags
    {
        /// <summary>
        /// MPEGLAYER3_FLAG_PADDING_ISO
        /// </summary>
        PaddingIso = 0,
        /// <summary>
        /// MPEGLAYER3_FLAG_PADDING_ON
        /// </summary>
        PaddingOn = 1,
        /// <summary>
        /// MPEGLAYER3_FLAG_PADDING_OFF
        /// </summary>
        PaddingOff = 2,
    }

    /// <summary>
    /// Wave Format ID
    /// </summary>
    public enum Mp3WaveFormatId : ushort
    {
        /// <summary>MPEGLAYER3_ID_UNKNOWN</summary>
        Unknown = 0,
        /// <summary>MPEGLAYER3_ID_MPEG</summary>
        Mpeg = 1,
        /// <summary>MPEGLAYER3_ID_CONSTANTFRAMESIZE</summary>
        ConstantFrameSize = 2
    }

    /// <summary>
    /// Channel Mode
    /// </summary>
    public enum ChannelMode
    {
        /// <summary>
        /// Stereo
        /// </summary>
        Stereo,
        /// <summary>
        /// Joint Stereo
        /// </summary>
        JointStereo,
        /// <summary>
        /// Dual Channel
        /// </summary>
        DualChannel,
        /// <summary>
        /// Mono
        /// </summary>
        Mono
    }

    /// <summary>
    /// Windows multimedia error codes from mmsystem.h.
    /// </summary>
    public enum MmResult
    {
        /// <summary>no error, MMSYSERR_NOERROR</summary>
        NoError = 0,
        /// <summary>unspecified error, MMSYSERR_ERROR</summary>
        UnspecifiedError = 1,
        /// <summary>device ID out of range, MMSYSERR_BADDEVICEID</summary>
        BadDeviceId = 2,
        /// <summary>driver failed enable, MMSYSERR_NOTENABLED</summary>
        NotEnabled = 3,
        /// <summary>device already allocated, MMSYSERR_ALLOCATED</summary>
        AlreadyAllocated = 4,
        /// <summary>device handle is invalid, MMSYSERR_INVALHANDLE</summary>
        InvalidHandle = 5,
        /// <summary>no device driver present, MMSYSERR_NODRIVER</summary>
        NoDriver = 6,
        /// <summary>memory allocation error, MMSYSERR_NOMEM</summary>
        MemoryAllocationError = 7,
        /// <summary>function isn't supported, MMSYSERR_NOTSUPPORTED</summary>
        NotSupported = 8,
        /// <summary>error value out of range, MMSYSERR_BADERRNUM</summary>
        BadErrorNumber = 9,
        /// <summary>invalid flag passed, MMSYSERR_INVALFLAG</summary>
        InvalidFlag = 10,
        /// <summary>invalid parameter passed, MMSYSERR_INVALPARAM</summary>
        InvalidParameter = 11,
        /// <summary>handle being used simultaneously on another thread (eg callback),MMSYSERR_HANDLEBUSY</summary>
        HandleBusy = 12,
        /// <summary>specified alias not found, MMSYSERR_INVALIDALIAS</summary>
        InvalidAlias = 13,
        /// <summary>bad registry database, MMSYSERR_BADDB</summary>
        BadRegistryDatabase = 14,
        /// <summary>registry key not found, MMSYSERR_KEYNOTFOUND</summary>
        RegistryKeyNotFound = 15,
        /// <summary>registry read error, MMSYSERR_READERROR</summary>
        RegistryReadError = 16,
        /// <summary>registry write error, MMSYSERR_WRITEERROR</summary>
        RegistryWriteError = 17,
        /// <summary>registry delete error, MMSYSERR_DELETEERROR</summary>
        RegistryDeleteError = 18,
        /// <summary>registry value not found, MMSYSERR_VALNOTFOUND</summary>
        RegistryValueNotFound = 19,
        /// <summary>driver does not call DriverCallback, MMSYSERR_NODRIVERCB</summary>
        NoDriverCallback = 20,
        /// <summary>more data to be returned, MMSYSERR_MOREDATA</summary>
        MoreData = 21,

        /// <summary>unsupported wave format, WAVERR_BADFORMAT</summary>
        WaveBadFormat = 32,
        /// <summary>still something playing, WAVERR_STILLPLAYING</summary>
        WaveStillPlaying = 33,
        /// <summary>header not prepared, WAVERR_UNPREPARED</summary>
        WaveHeaderUnprepared = 34,
        /// <summary>device is synchronous, WAVERR_SYNC</summary>
        WaveSync = 35,

        // ACM error codes, found in msacm.h

        /// <summary>Conversion not possible (ACMERR_NOTPOSSIBLE)</summary>
        AcmNotPossible = 512,
        /// <summary>Busy (ACMERR_BUSY)</summary>
        AcmBusy = 513,
        /// <summary>Header Unprepared (ACMERR_UNPREPARED)</summary>
        AcmHeaderUnprepared = 514,
        /// <summary>Cancelled (ACMERR_CANCELED)</summary>
        AcmCancelled = 515,

        // Mixer error codes, found in mmresult.h

        /// <summary>invalid line (MIXERR_INVALLINE)</summary>
        MixerInvalidLine = 1024,
        /// <summary>invalid control (MIXERR_INVALCONTROL)</summary>
        MixerInvalidControl = 1025,
        /// <summary>invalid value (MIXERR_INVALVALUE)</summary>
        MixerInvalidValue = 1026,
    }

    /// <summary>
    /// Flags for use with acmDriverAdd
    /// </summary>
    public enum AcmDriverAddFlags
    {
        // also ACM_DRIVERADDF_TYPEMASK   = 0x00000007;

        /// <summary>
        /// ACM_DRIVERADDF_LOCAL
        /// </summary>
        Local = 0,
        /// <summary>
        /// ACM_DRIVERADDF_GLOBAL
        /// </summary>
        Global = 8,
        /// <summary>
        /// ACM_DRIVERADDF_FUNCTION
        /// </summary>
        Function = 3,
        /// <summary>
        /// ACM_DRIVERADDF_NOTIFYHWND
        /// </summary>
        NotifyWindowHandle = 4,
    }

    [Flags]
    enum AcmFormatSuggestFlags
    {
        /// <summary>
        /// ACM_FORMATSUGGESTF_WFORMATTAG
        /// </summary>
        FormatTag = 0x00010000,
        /// <summary>
        /// ACM_FORMATSUGGESTF_NCHANNELS
        /// </summary>
        Channels = 0x00020000,
        /// <summary>
        /// ACM_FORMATSUGGESTF_NSAMPLESPERSEC
        /// </summary>
        SamplesPerSecond = 0x00040000,
        /// <summary>
        /// ACM_FORMATSUGGESTF_WBITSPERSAMPLE
        /// </summary>
        BitsPerSample = 0x00080000,
        /// <summary>
        /// ACM_FORMATSUGGESTF_TYPEMASK
        /// </summary>
        TypeMask = 0x00FF0000,
    }

    [Flags]
    enum AcmStreamOpenFlags
    {
        /// <summary>
        /// ACM_STREAMOPENF_QUERY, ACM will be queried to determine whether it supports the given conversion. A conversion stream will not be opened, and no handle will be returned in the phas parameter. 
        /// </summary>
        Query = 0x00000001,
        /// <summary>
        /// ACM_STREAMOPENF_ASYNC, Stream conversion should be performed asynchronously. If this flag is specified, the application can use a callback function to be notified when the conversion stream is opened and closed and after each buffer is converted. In addition to using a callback function, an application can examine the fdwStatus member of the ACMSTREAMHEADER structure for the ACMSTREAMHEADER_STATUSF_DONE flag. 
        /// </summary>
        Async = 0x00000002,
        /// <summary>
        /// ACM_STREAMOPENF_NONREALTIME, ACM will not consider time constraints when converting the data. By default, the driver will attempt to convert the data in real time. For some formats, specifying this flag might improve the audio quality or other characteristics.
        /// </summary>
        NonRealTime = 0x00000004,
        /// <summary>
        /// CALLBACK_TYPEMASK, callback type mask
        /// </summary>
        CallbackTypeMask = 0x00070000,
        /// <summary>
        /// CALLBACK_NULL, no callback
        /// </summary>
        CallbackNull = 0x00000000,
        /// <summary>
        /// CALLBACK_WINDOW, dwCallback is a HWND
        /// </summary>
        CallbackWindow = 0x00010000,
        /// <summary>
        /// CALLBACK_TASK, dwCallback is a HTASK
        /// </summary>
        CallbackTask = 0x00020000,
        /// <summary>
        /// CALLBACK_FUNCTION, dwCallback is a FARPROC
        /// </summary>
        CallbackFunction = 0x00030000,
        /// <summary>
        /// CALLBACK_THREAD, thread ID replaces 16 bit task
        /// </summary>
        CallbackThread = CallbackTask,
        /// <summary>
        /// CALLBACK_EVENT, dwCallback is an EVENT Handle
        /// </summary>
        CallbackEvent = 0x00050000,
    }

    /// <summary>
    /// Flags indicating what support a particular ACM driver has
    /// </summary>
    [Flags]
    public enum AcmDriverDetailsSupportFlags
    {
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_CODEC - Codec</summary>
        Codec = 0x00000001,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_CONVERTER - Converter</summary>
        Converter = 0x00000002,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_FILTER - Filter</summary>
        Filter = 0x00000004,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_HARDWARE - Hardware</summary>
        Hardware = 0x00000008,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_ASYNC - Async</summary>
        Async = 0x00000010,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_LOCAL - Local</summary>
        Local = 0x40000000,
        /// <summary>ACMDRIVERDETAILS_SUPPORTF_DISABLED - Disabled</summary>
        Disabled = unchecked((int)0x80000000),
    }

    enum AcmMetrics
    {
        /// <summary>ACM_METRIC_COUNT_DRIVERS</summary>
        CountDrivers = 1,
        /// <summary>ACM_METRIC_COUNT_CODECS</summary>
        CountCodecs = 2,
        /// <summary>ACM_METRIC_COUNT_CONVERTERS</summary>
        CountConverters = 3,
        /// <summary>ACM_METRIC_COUNT_FILTERS</summary>
        CountFilters = 4,
        /// <summary>ACM_METRIC_COUNT_DISABLED</summary>
        CountDisabled = 5,
        /// <summary>ACM_METRIC_COUNT_HARDWARE</summary>
        CountHardware = 6,
        /// <summary>ACM_METRIC_COUNT_LOCAL_DRIVERS</summary>
        CountLocalDrivers = 20,
        /// <summary>ACM_METRIC_COUNT_LOCAL_CODECS</summary>
        CountLocalCodecs = 21,
        /// <summary>ACM_METRIC_COUNT_LOCAL_CONVERTERS</summary>
        CountLocalConverters = 22,
        /// <summary>ACM_METRIC_COUNT_LOCAL_FILTERS</summary>
        CountLocalFilters = 23,
        /// <summary>ACM_METRIC_COUNT_LOCAL_DISABLED</summary>
        CountLocalDisabled = 24,
        /// <summary>ACM_METRIC_HARDWARE_WAVE_INPUT</summary>
        HardwareWaveInput = 30,
        /// <summary>ACM_METRIC_HARDWARE_WAVE_OUTPUT</summary>
        HardwareWaveOutput = 31,
        /// <summary>ACM_METRIC_MAX_SIZE_FORMAT</summary>
        MaxSizeFormat = 50,
        /// <summary>ACM_METRIC_MAX_SIZE_FILTER</summary>
        MaxSizeFilter = 51,
        /// <summary>ACM_METRIC_DRIVER_SUPPORT</summary>
        DriverSupport = 100,
        /// <summary>ACM_METRIC_DRIVER_PRIORITY</summary>
        DriverPriority = 101,
    }

    enum AcmStreamSizeFlags
    {
        /// <summary>
        /// ACM_STREAMSIZEF_SOURCE
        /// </summary>
        Source = 0x00000000,
        /// <summary>
        /// ACM_STREAMSIZEF_DESTINATION
        /// </summary>
        Destination = 0x00000001
    }

    [Flags]
    enum AcmStreamConvertFlags
    {
        /// <summary>
        /// ACM_STREAMCONVERTF_BLOCKALIGN
        /// </summary>
        BlockAlign = 0x00000004,
        /// <summary>
        /// ACM_STREAMCONVERTF_START
        /// </summary>
        Start = 0x00000010,
        /// <summary>
        /// ACM_STREAMCONVERTF_END
        /// </summary>
        End = 0x00000020,
    }

    [Flags]
    enum AcmDriverEnumFlags
    {
        /// <summary>
        /// ACM_DRIVERENUMF_NOLOCAL, Only global drivers should be included in the enumeration
        /// </summary>
        NoLocal = 0x40000000,
        /// <summary>
        /// ACM_DRIVERENUMF_DISABLED, Disabled ACM drivers should be included in the enumeration
        /// </summary>
        Disabled = unchecked((int)0x80000000),
    }

    [Flags]
    enum AcmFormatChooseStyleFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_SHOWHELP
        /// </summary>
        ShowHelp = 0x00000004,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_ENABLEHOOK
        /// </summary>
        EnableHook = 0x00000008,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATE
        /// </summary>
        EnableTemplate = 0x00000010,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATEHANDLE
        /// </summary>
        EnableTemplateHandle = 0x00000020,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_INITTOWFXSTRUCT
        /// </summary>
        InitToWfxStruct = 0x00000040,
        /// <summary>
        /// ACMFORMATCHOOSE_STYLEF_CONTEXTHELP
        /// </summary>
        ContextHelp = 0x00000080
    }

    /// <summary>
    /// Format Enumeration Flags
    /// </summary>
    [Flags]
    public enum AcmFormatEnumFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// ACM_FORMATENUMF_CONVERT
        /// The WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will only enumerate destination formats that can be converted from the given pwfx format. 
        /// </summary>
        Convert = 0x00100000,
        /// <summary>
        /// ACM_FORMATENUMF_HARDWARE
        /// The enumerator should only enumerate formats that are supported as native input or output formats on one or more of the installed waveform-audio devices. This flag provides a way for an application to choose only formats native to an installed waveform-audio device. This flag must be used with one or both of the ACM_FORMATENUMF_INPUT and ACM_FORMATENUMF_OUTPUT flags. Specifying both ACM_FORMATENUMF_INPUT and ACM_FORMATENUMF_OUTPUT will enumerate only formats that can be opened for input or output. This is true regardless of whether this flag is specified. 
        /// </summary>
        Hardware = 0x00400000,
        /// <summary>
        /// ACM_FORMATENUMF_INPUT
        /// Enumerator should enumerate only formats that are supported for input (recording). 
        /// </summary>
        Input = 0x00800000,
        /// <summary>
        /// ACM_FORMATENUMF_NCHANNELS 
        /// The nChannels member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will enumerate only a format that conforms to this attribute. 
        /// </summary>
        Channels = 0x00020000,
        /// <summary>
        /// ACM_FORMATENUMF_NSAMPLESPERSEC
        /// The nSamplesPerSec member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will enumerate only a format that conforms to this attribute. 
        /// </summary>
        SamplesPerSecond = 0x00040000,
        /// <summary>
        /// ACM_FORMATENUMF_OUTPUT 
        /// Enumerator should enumerate only formats that are supported for output (playback). 
        /// </summary>
        Output = 0x01000000,
        /// <summary>
        /// ACM_FORMATENUMF_SUGGEST
        /// The WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will enumerate all suggested destination formats for the given pwfx format. This mechanism can be used instead of the acmFormatSuggest function to allow an application to choose the best suggested format for conversion. The dwFormatIndex member will always be set to zero on return. 
        /// </summary>
        Suggest = 0x00200000,
        /// <summary>
        /// ACM_FORMATENUMF_WBITSPERSAMPLE
        /// The wBitsPerSample member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will enumerate only a format that conforms to this attribute. 
        /// </summary>
        BitsPerSample = 0x00080000,
        /// <summary>
        /// ACM_FORMATENUMF_WFORMATTAG
        /// The wFormatTag member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid. The enumerator will enumerate only a format that conforms to this attribute. The dwFormatTag member of the ACMFORMATDETAILS structure must be equal to the wFormatTag member. 
        /// </summary>
        FormatTag = 0x00010000,
    }

    [Flags]
    enum AcmStreamHeaderStatusFlags
    {
        /// <summary>
        /// ACMSTREAMHEADER_STATUSF_DONE
        /// </summary>
        Done = 0x00010000,
        /// <summary>
        /// ACMSTREAMHEADER_STATUSF_PREPARED
        /// </summary>
        Prepared = 0x00020000,
        /// <summary>
        /// ACMSTREAMHEADER_STATUSF_INQUEUE
        /// </summary>
        InQueue = 0x00100000,
    }


}
