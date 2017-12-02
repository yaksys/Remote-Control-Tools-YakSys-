using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.DirectX.DirectSound;
using System.IO;
using System.Threading;
using Remote_Control_Tools_ProcWindow;

public class DXSoundCapture
{     
    /*

    Device device_SelectedDevice;
    BufferDescription bufferDescription_obj;
    WaveFormat waveFormat_CurrentFormat;
    Capture capture_obj;
    CaptureBufferDescription captureBufferDescription_obj;
    CaptureBuffer captureBuffer_obj;
    MemoryStream memoryStreams_Record = new MemoryStream();
          
    int int_CaptureBufferReadPosition = 0;      
    int int_CaptureBufferWritePosition = 0;

    public void InitDxEnvironment(int int_Buffer_LengthInSeconds)
    {
        // Create Device
        device_SelectedDevice = new Device();
        device_SelectedDevice.SetCooperativeLevel(LocalObjCopy.formMain_obj, CooperativeLevel.Normal);

        // Init Wave Format
        waveFormat_CurrentFormat = new WaveFormat();

        waveFormat_CurrentFormat.BitsPerSample = 8;
        waveFormat_CurrentFormat.Channels = 1;
        waveFormat_CurrentFormat.BlockAlign = 1;

        waveFormat_CurrentFormat.FormatTag = WaveFormatTag.Pcm;
        waveFormat_CurrentFormat.SamplesPerSecond = 8000; //sampling frequency of your data;   
        waveFormat_CurrentFormat.AverageBytesPerSecond = waveFormat_CurrentFormat.SamplesPerSecond * waveFormat_CurrentFormat.BlockAlign;

        // buffer description         
        bufferDescription_obj = new BufferDescription(waveFormat_CurrentFormat);

        bufferDescription_obj.DeferLocation = true;
        bufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;
        /////////////////////
        
        captureBufferDescription_obj = new CaptureBufferDescription();

        capture_obj = new Capture();

        captureBufferDescription_obj.Format = waveFormat_CurrentFormat;
        captureBufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;
        captureBufferDescription_obj.BufferBytes = int_Buffer_LengthInSeconds * waveFormat_CurrentFormat.AverageBytesPerSecond;

        captureBuffer_obj = new CaptureBuffer(captureBufferDescription_obj, capture_obj);

        captureBufferDescription_obj.Format = waveFormat_CurrentFormat;

        memoryStreams_Record = new MemoryStream(bufferDescription_obj.BufferBytes);
    }




    bool bool_NeedToStopRecordThread = false;
    
    public void Record()
    {
        if (bool_NeedToStopRecordThread == true) return;

        Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
        
        try
        {
            lock (this)
            {
                new Thread(new ThreadStart(Record)).Start();
          
                memoryStreams_Record.SetLength(bufferDescription_obj.BufferBytes);
                         
                memoryStreams_Record.Position = 0;
              
                captureBuffer_obj.Start(false); // false == No looping!

                while (int_CaptureBufferReadPosition == 0) // waiting until buffer going away ftom start/0 position
                {
                    captureBuffer_obj.GetCurrentPosition(out int_CaptureBufferWritePosition, out int_CaptureBufferReadPosition);

                    Thread.Sleep(10);
                }

                while (true)
                {
                    Thread.Sleep(100);

                    captureBuffer_obj.GetCurrentPosition(out int_CaptureBufferWritePosition, out int_CaptureBufferReadPosition);

                    if (int_CaptureBufferReadPosition == 0) // buffer was be full and back to 0 position
                    {
                        try
                        {
                            captureBuffer_obj.Read((int)0, memoryStreams_Record, bufferDescription_obj.BufferBytes, LockFlag.None);

                            break;
                        }
                        catch (Exception exception_obj)
                        {
                            break;
                        }
                    }
                }

                captureBuffer_obj.Stop();

                memoryStreams_Record.SetLength(memoryStreams_Record.Position);

                LocalObjCopy.obj_MicrophoneRecordWrapper.SendSoundDataBlockToSubscribedClients(memoryStreams_Record.GetBuffer());
            }
            /////////////////////////////////////////////////////////////

            //memoryStreams_Record.Close();

            Thread.Sleep(1);
        }
        catch
        {
            Thread.Sleep(10);

            bool_NeedToStopRecordThread = true;

            Thread.CurrentThread.Interrupt();
        }
    }

    public void PlaySoundBuffer(byte[] byteArray_SoundBuffer)
    {
        SecondaryBuffer secondaryBuffer_obj = new SecondaryBuffer(bufferDescription_obj, device_SelectedDevice);

        secondaryBuffer_obj.SetCurrentPosition(0);

        secondaryBuffer_obj.Write(0, byteArray_SoundBuffer, LockFlag.None);

        secondaryBuffer_obj.Play(0, BufferPlayFlags.Default);

        while (secondaryBuffer_obj.Status.Playing == true) Thread.Sleep(100);

        secondaryBuffer_obj.Stop();
    }

    */

}
