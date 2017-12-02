using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
//using SlimDX;
using System.Threading;
using Remote_Control_Tools_ProcWindow;
//using SlimDX.Multimedia;
//using SlimDX.DirectSound;
/*
public class SoundCapture
{
    public SoundCapture()
    {
        InitDxEnvironment(1);
    }

    DirectSound device_SelectedDevice;
    SoundBufferDescription bufferDescription_obj;
    WaveFormat waveFormat_CurrentFormat;
    DirectSoundCapture capture_obj;
    CaptureBufferDescription captureBufferDescription_obj;
    CaptureBuffer captureBuffer_obj;
    SecondarySoundBuffer secondaryBuffer_obj;

    int int_CaptureBufferReadPosition = 0;
    int int_CaptureBufferWritePosition = 0;

    public void InitDxEnvironment(int int_Buffer_LengthInSeconds)
    {
        // Create Device
        device_SelectedDevice = new DirectSound();
        device_SelectedDevice.SetCooperativeLevel(LocalObjCopy.formMain_obj.Handle, CooperativeLevel.Normal);

        // Init Wave Format
        waveFormat_CurrentFormat = new WaveFormat();

        waveFormat_CurrentFormat.BitsPerSample = 8;
        waveFormat_CurrentFormat.Channels = 1;
        waveFormat_CurrentFormat.BlockAlignment = 1;

        waveFormat_CurrentFormat.FormatTag = WaveFormatTag.Pcm;
        waveFormat_CurrentFormat.SamplesPerSecond = 8000; //sampling frequency of your data;   
        waveFormat_CurrentFormat.AverageBytesPerSecond = waveFormat_CurrentFormat.SamplesPerSecond * waveFormat_CurrentFormat.BlockAlignment;
        bufferDescription_obj.Flags = SlimDX.DirectSound.BufferFlags.GlobalFocus | SlimDX.DirectSound.BufferFlags.ControlVolume;

        ///////////////////// fill buffer description         
        bufferDescription_obj = new SoundBufferDescription();
        
        bufferDescription_obj.Format = waveFormat_CurrentFormat;
        bufferDescription_obj.SizeInBytes = (int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond)/2;
        /////////////////////

        captureBufferDescription_obj = new CaptureBufferDescription();

        capture_obj = new DirectSoundCapture();

        secondaryBuffer_obj = new SecondarySoundBuffer(device_SelectedDevice, bufferDescription_obj);

        captureBufferDescription_obj.Format = waveFormat_CurrentFormat;
        captureBufferDescription_obj.BufferBytes = (int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond) / 2;
        captureBufferDescription_obj.BufferBytes = (int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond) / 2;

        captureBuffer_obj = new CaptureBuffer(capture_obj, captureBufferDescription_obj);

        captureBufferDescription_obj.Format = waveFormat_CurrentFormat;
    }

    bool bool_NeedToStopRecordThread = false;

    byte[] byteArray_BufferData;

    public void Record()//!!!! при вызове из под сервиса не работает ! отдельно запускаемая winproc.exe - все работает .. связано с учеткой LocalSystem которая не дает создать directx девайс ... хз  что делать .. другие как то решали ...
    {
        if (bool_NeedToStopRecordThread == true) return;

        Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

        try
        {
            lock (this)
            {
                new Thread(new ThreadStart(Record)).Start();

                captureBuffer_obj.Start(false); // false == No looping!

                while (int_CaptureBufferReadPosition == 0) // waiting until buffer going away ftom start/0 position
                {
                    int_CaptureBufferReadPosition = captureBuffer_obj.CurrentReadPosition;
                    int_CaptureBufferWritePosition = captureBuffer_obj.CurrentCapturePosition;

                    Thread.Sleep(10);
                }

                while (true)
                {
                    Thread.Sleep(100);

                    int_CaptureBufferReadPosition = captureBuffer_obj.CurrentReadPosition;
                    int_CaptureBufferWritePosition = captureBuffer_obj.CurrentCapturePosition;

                    if (int_CaptureBufferReadPosition == 0 || int_CaptureBufferWritePosition == 0) // buffer was be full and back to 0 position
                    {
                        try
                        {
                            if (byteArray_BufferData == null)
                            {
                                byteArray_BufferData = new byte[bufferDescription_obj.SizeInBytes];
                            }

                            captureBuffer_obj.Read(byteArray_BufferData, 0, false);

                            break;
                        }
                        catch (Exception exception_obj)
                        {
                            break;
                        }
                    }
                }

                captureBuffer_obj.Stop();

                //PlaySoundBuffer(byteArray_BufferData);

                LocalObjCopy.obj_MicrophoneRecordWrapper.SendSoundDataBlockToSubscribedClients(byteArray_BufferData);
            }
            /////////////////////////////////////////////////////////////

            Thread.Sleep(1);
        }
        catch
        {
            Thread.Sleep(100);

           //!! bool_NeedToStopRecordThread = true;

           //!! Thread.CurrentThread.Interrupt();
        }
    }

    public void PlaySoundBuffer(byte[] byteArray_SoundBuffer)
    {
        try
        {
            secondaryBuffer_obj.CurrentPlayPosition = 0;

            secondaryBuffer_obj.Write(byteArray_SoundBuffer, 0, LockFlags.None);

            secondaryBuffer_obj.Play(0, SlimDX.DirectSound.PlayFlags.None);

            while (secondaryBuffer_obj.Status == BufferStatus.Playing) Thread.Sleep(100);

            secondaryBuffer_obj.Stop();
        }
        catch(Exception ex)
        {
            
        }
    }
}
*/