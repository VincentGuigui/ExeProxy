ExeProxy
--
ExeProxy allows you to capture usage of an executable, especially its command line arguments.

Instructions
--
1. Rename the application executable you want to capture:
   TheApp.exe => TheApp.proxy.exe
2. Rename ExeProxy to match the original name of the application:
   ExeProxy.exe => TheApp.exe

Output
--
A log file will be created in the application directory: c:\PathToApp\TheApp.proxy.log
If the directory is not writeable, the log will be in c:\temp\TheApp.proxy.log