using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace getProcessFilePath
{
    class myProcess
    {
        #region Flags
        // 常見標示符
        [Flags]
        private enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }
        #endregion

        #region Process結構
        // 屬性 LayoutKind.Sequential ，強制依出現的順序來排列成員
        //  CharSet.Auto 轉換會與平臺相依 (ANSI on windows 98 和 Windows Me，而在較新版本) 上為 Unicode。
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PROCESSENTRY32
        {
            const int MAX_PATH = 260;
            internal UInt32 dwSize;
            internal UInt32 cntUsage;
            internal UInt32 th32ProcessID;
            internal IntPtr th32DefaultHeapID;
            internal UInt32 th32ModuleID;
            internal UInt32 cntThreads;
            internal UInt32 th32ParentProcessID;
            internal Int32 pcPriClassBase;
            internal UInt32 dwFlags;
            // 表示如何在 Managed 和 Unmanaged 程式碼之間封送處理資料。
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string szExeFile;
        }
        #endregion

        #region Win32 API
        // 拍攝指定進程的快照，以及這些進程使用的堆，模塊和線程。
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In] UInt32 dwFlags, [In] UInt32 th32ProcessID);

        // 檢索有關係統快照中遇到的第一個進程的信息。
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32First([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        // 檢索有關記錄在系統快照中的下一個進程的信息。
        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32Next([In] IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        // 關閉打開的對象句柄
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject); 
        #endregion

        public List<PROCESSENTRY32> GetProcessList(out string error)
        {
            
            List<PROCESSENTRY32> processList = null;
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                PROCESSENTRY32 procEntry = new PROCESSENTRY32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
                // 獲取進程快照
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);

                if (Process32First(handleToSnapshot, ref procEntry))
                {
                    processList = new List<PROCESSENTRY32>();
                    do
                    {
                        processList.Add(procEntry);
                        //procEntry = new PROCESSENTRY32();
                    } while (Process32Next(handleToSnapshot, ref procEntry));
                }
                else
                {
                    error = string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error());
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't get the process.", ex);
            }
            finally
            {
                // 關閉快照
                CloseHandle(handleToSnapshot);
                error = null;
            }

            return processList;
        }
    }
}
