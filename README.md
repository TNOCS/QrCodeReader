# QrCodeReader

QR code reader for the Hololens.

# DISCLAIMER

This is based on the blog written bij [Mike Taulty](https://mtaulty.com/2016/12/28/windows-10-uwp-qr-code-scanning-with-zxing-and-hololens), in which he describes in detail the steps that need to be taken in order to develop a standalone QR reader for the Microsoft Hololens. Although he put the most important part of his [code in Github](https://github.com/mtaulty/QrCodes), i.e. the part that uses the [ZXing.net](http://zxingnet.codeplex.com/downloads/get/1643769) library to scan the QR code (which you can find in the INSTALL_DIR/Plugins folder), the Unity project had to be setup manually again.

Using the latest version of Unity required me to make some small changes to his instructions, a.o. I had to:
- Include the MediaFrameQrProcessing.dll file in the Assets/Plugins/WSA folder.
- Download the latest version of the ZXing.net release (zxing.dll), extract the dll and add it to this folder too.
- In the Placeholder.cs file, preserve the 'using System' reference (needed when building).

