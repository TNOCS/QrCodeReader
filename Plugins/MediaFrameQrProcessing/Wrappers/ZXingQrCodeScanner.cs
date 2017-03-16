﻿namespace MediaFrameQrProcessing.Wrappers
{
  using global::ZXing;
  using MediaFrameQrProcessing.Processors;
  using MediaFrameQrProcessing.VideoDeviceFinders;
  using System;
  using Windows.Media.MediaProperties;

  public static class ZXingQrCodeScanner
  {
    public static async void ScanFirstCameraForQrCode(
      Action<Result> resultCallback, 
      TimeSpan timeout)
    {
      Result result = null;

      var mediaFrameSourceFinder = new MediaFrameSourceFinder();      

      // We want a source of media frame groups which contains a color video
      // preview (and we'll take the first one).
      var populated = await mediaFrameSourceFinder.PopulateAsync(
        MediaFrameSourceFinder.ColorVideoPreviewFilter,
        MediaFrameSourceFinder.FirstOrDefault);

      if (populated)
      {
        // We'll take the first video capture device.
        var videoCaptureDevice = await VideoCaptureDeviceFinder.FindFirstOrDefaultAsync();

        if (videoCaptureDevice != null)
        {
          // Make a processor which will pull frames from the camera and run
          // ZXing over them to look for QR codes.
          var frameProcessor = new QrCaptureFrameProcessor(
            mediaFrameSourceFinder,
            videoCaptureDevice,
            MediaEncodingSubtypes.Bgra8);

          // Remember to ask for auto-focus on the video capture device.
          frameProcessor.SetVideoDeviceControllerInitialiser(
            vd => vd.Focus.TrySetAuto(true));

          // Process frames for up to 30 seconds to see if we get any QR codes...
          await frameProcessor.ProcessFramesAsync(timeout);

          // See what result we got.
          result = frameProcessor.QrZxingResult;
        }
      }
      // Call back with whatever result we got.
      resultCallback(result);
    }
  }
}