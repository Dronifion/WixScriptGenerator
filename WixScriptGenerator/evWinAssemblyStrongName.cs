using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Application Used Library
using System.Runtime.InteropServices;

namespace EvaultWin.Common.evWinAssemblyStrongName
{
    /// <summary>
    /// Assembly Strong Name Utility Class
    /// </summary>
    public class AssemblyStrongName64Bits
    {
        /// <summary>
        /// P/Invoke to check various security settings
        /// Using byte for arguments rather than bool, 
        /// because bool won't work on 64-bit Windows!
        /// </summary>
        /// <param name="wszFilePath"></param>
        /// <param name="fForceVerification"></param>
        /// <param name="pfWasVerified"></param>
        /// <returns></returns>
        [DllImport("mscoree.dll", CharSet = CharSet.Unicode)]
        private static extern bool StrongNameSignatureVerificationEx(string wszFilePath, byte fForceVerification, ref byte pfWasVerified);

        #region Public Functions
        /// <summary>
        /// Check that this assembly has a strong name
        /// </summary>
        /// <returns></returns>
        public static bool IsStrongNameValid_Check()
        {
            byte wasVerified = Convert.ToByte(false);
            byte forceVerification = Convert.ToByte(true);
            string assemblyName = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
            return CheckSignature(assemblyName, forceVerification, ref wasVerified);
        }

        /// <summary>
        /// Check that public key token matches what's expected.
        /// </summary>
        /// <param name="tokenExpected"></param>
        /// <returns></returns>
        public static bool IsPublicTokenOkay_Check(byte[] tokenExpected)
        {
            // Retrieve token from current assembly
            byte[] tokenCurrent = System.Reflection.Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();

            // Check that lengths match
            if (tokenExpected.Length == tokenCurrent.Length)
            {
                // Check that token contents match
                for (int i = 0; i < tokenCurrent.Length; i++)
                    if (tokenExpected[i] != tokenCurrent[i])
                        return false;
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Private Functions
        /// <summary>
        /// Check strong name signature
        /// </summary>
        /// <param name="assembyName"></param>
        /// <param name="forceVerification"></param>
        /// <param name="wasVerified"></param>
        /// <returns></returns>
        private static bool CheckSignature(string assembyName, byte forceVerification, ref byte wasVerified)
        {
            return StrongNameSignatureVerificationEx(assembyName, forceVerification, ref wasVerified);
        }
        #endregion
    }

}
