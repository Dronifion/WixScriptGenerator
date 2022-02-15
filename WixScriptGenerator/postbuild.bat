echo off
set argReleasePath=%1 >> argBatch.txt
set argObfuscatedExeFile=%2 >> argBatch.txt
set argObfuscarConsoleExeFile=%3 >> argBatch.txt
set argObfuscarConsoleXmlFile=%4 >> argBatch.txt
rem Obfuscar.Console.exe -s obfuscar.xml
%argObfuscarConsoleExeFile% -s %argObfuscarConsoleXmlFile% >> argBatch.txt
xcopy /Y %argObfuscatedExeFile% %argReleasePath% >> argBatch.txt
rem "C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe" sign /n "Securemi Sdn Bhd" /tr http://timestamp.entrust.net/rfc3161ts2 /fd SHA256 "$(TargetDir)\$(TargetFileName)"
CD %argReleasePath% >> argBatch.txt