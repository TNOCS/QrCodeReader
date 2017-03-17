# QrCodeReader

QR code reader for the Hololens.

STILL NOT WORKING!!!

# DISCLAIMER

This is based on the blog written bij [Mike Taulty](https://mtaulty.com/2016/12/28/windows-10-uwp-qr-code-scanning-with-zxing-and-hololens), in which he describes in detail the steps that need to be taken in order to develop a standalone QR reader for the Microsoft Hololens. Although he put the most important part of his [code in Github](https://github.com/mtaulty/QrCodes), i.e. the part that uses the [ZXing.net](http://zxingnet.codeplex.com/downloads/get/1643769) library to scan the QR code (which you can find in the INSTALL_DIR/Plugins folder), the Unity project had to be setup manually again.

Using the latest version of Unity required me to make some small changes to his instructions, a.o. I had to:
- Include the MediaFrameQrProcessing.dll file in the Assets/Plugins/WSA folder.
- Download the latest version of the ZXing.net release (zxing.dll), extract the dll and add it to this folder too.
- In the Placeholder.cs file, preserve the 'using System' reference (needed when building).


# WARNING

Although the application compiles and runs in the Hololens, when I start to scan, the program crashes with a file load exception.

```console
Exception thrown: 'System.IO.FileLoadException' in mscorlib.ni.dll
The program '[4920] QRCodeReader.exe' has exited with code -1073741189 (0xc000027b).
```

I've tried it with several versions of ZXing (the winmd and UAP version), but that doesn't seem to help.

Currently, I don't have time to investigate this further...

