/*********************************************************************************
 Copyright (C) 2021-present John García
 
 This file is part of ChakramFF.

 ChakramFF is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
 
 ChakramFF is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.
 
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see https://www.gnu.org/licenses/.

 For more details, see README.md.
 *********************************************************************************/

using Byakkoder.ChakramFF.Interfaces.FFmpegWrapperCore.DotNetWrappers;
using System;
using System.Diagnostics;
using System.IO;

namespace Byakkoder.ChakramFF.FFmpegWrapperCore.DotNetWrappers
{
    /// <summary>
    /// This class is a DotNet wrapper to help testing application code without DotNet Framework
    /// dependencies because Microsoft Fakes (shim) is not available in Visual Studio Community.
    /// For more information visit https://docs.microsoft.com/en-us/visualstudio/test/isolating-code-under-test-with-microsoft-fakes?view=vs-2019
    /// </summary>
    public class ProcessWrapper : IProcessWrapper
    {
        #region Fields
        
        private Process _process;

        #endregion

        #region Events
        
        public event DataReceivedEventHandler ErrorDataReceived;
        public event DataReceivedEventHandler OutputDataReceived;

        #endregion

        #region Properties
        
        public ProcessStartInfo StartInfo
        {
            get
            {
                return _process.StartInfo;
            }
            set
            {
                _process.StartInfo = value;
            }
        }

        public StreamWriter StandardInput
        {
            get
            {
                return _process.StandardInput;
            }
        }

        public StreamReader StandardOutput
        {
            get
            {
                return _process.StandardOutput;
            }
        }

        public StreamReader StandardError
        {
            get
            {
                return _process.StandardError;
            }
        }

        public bool HasExited
        {
            get
            {
                try
                {
                    if (_process == null)
                    {
                        return true;
                    }

                    return _process.HasExited;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

        #endregion

        #region Constructor

        public ProcessWrapper()
        {
            InitializeProcess();
        }

        #endregion

        #region Events Wrapper
        
        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            ErrorDataReceived?.Invoke(sender, e);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OutputDataReceived?.Invoke(sender, e);
        }

        #endregion

        #region Public Methods
        
        public void InitializeProcess()
        {
            _process = new Process();
            _process.OutputDataReceived += Process_OutputDataReceived;
            _process.ErrorDataReceived += Process_ErrorDataReceived;
        }

        public bool Start()
        {
            return _process.Start();
        }

        public void BeginOutputReadLine()
        {
            _process.BeginOutputReadLine();
        }

        public void BeginErrorReadLine()
        {
            _process.BeginErrorReadLine();
        }

        public void WaitForExit()
        {
            _process.WaitForExit();
        }

        public void Kill()
        {
            try
            {
                _process.Kill();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error ocurred killing the process: {ex.Message}");
            }
        }

        #endregion
    }
}
