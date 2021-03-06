// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using SharpGen.Runtime;

namespace Vortice.Dxc
{
    public partial class IDxcCompiler2
    {
        public IDxcOperationResult CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            DxcDefine[] defines,
            IDxcIncludeHandler includeHandler,
            out string debugBlobName, out IDxcBlob debugBlob)
        {
            return CompileWithDebug(
                source,
                sourceName,
                entryPoint,
                targetProfile,
                arguments,
                arguments != null ? arguments.Length : 0,
                defines,
                defines != null ? defines.Length : 0,
                includeHandler,
                out debugBlobName, out debugBlob);
        }

        public IDxcOperationResult CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            int argumentsCount,
            DxcDefine[] defines,
            IDxcIncludeHandler includeHandler,
            out string debugBlobName, out IDxcBlob debugBlob)
        {
            return CompileWithDebug(
                source,
                sourceName,
                entryPoint,
                targetProfile,
                arguments,
                argumentsCount,
                defines,
                defines != null ? defines.Length : 0,
                includeHandler,
                out debugBlobName, out debugBlob);
        }

        public unsafe IDxcOperationResult CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            int argumentsCount,
            DxcDefine[] defines,
            int defineCount,
            IDxcIncludeHandler includeHandler,
            out string debugBlobName, out IDxcBlob debugBlob)
        {

            IntPtr* argumentsPtr = (IntPtr*)0;

            try
            {
                if (arguments != null && argumentsCount > 0)
                {
                    argumentsPtr = Interop.AllocToPointers(arguments, argumentsCount);
                }

                IntPtr debugBlobNameOut = IntPtr.Zero;
                Result hr = CompileWithDebug(source,
                    sourceName,
                    entryPoint, targetProfile,
                    (IntPtr)argumentsPtr, argumentsCount,
                    defines, defineCount,
                    includeHandler,
                    out IDxcOperationResult result,
                    new IntPtr(&debugBlobNameOut),
                    out debugBlob);

                if (debugBlobNameOut != IntPtr.Zero)
                {
                    debugBlobName = Marshal.PtrToStringUni(debugBlobNameOut);
                }
                else
                {
                    debugBlobName = string.Empty;
                }

                if (hr.Failure)
                {
                    result = default;
                    return default;
                }

                return result;
            }
            finally
            {
                if (argumentsPtr != null)
                {
                    Interop.Free(argumentsPtr);
                }
            }
        }

        public Result CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            DxcDefine[] defines,
            IDxcIncludeHandler includeHandler,
            out IDxcOperationResult result, out string debugBlobName, out IDxcBlob debugBlob)
        {
            return CompileWithDebug(
                source,
                sourceName,
                entryPoint,
                targetProfile,
                arguments,
                arguments != null ? arguments.Length : 0,
                defines,
                defines != null ? defines.Length : 0,
                includeHandler,
                out result, out debugBlobName, out debugBlob);
        }

        public Result CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            int argumentsCount,
            DxcDefine[] defines,
            IDxcIncludeHandler includeHandler,
            out IDxcOperationResult result, out string debugBlobName, out IDxcBlob debugBlob)
        {
            return CompileWithDebug(
                source,
                sourceName,
                entryPoint,
                targetProfile,
                arguments,
                argumentsCount,
                defines,
                defines != null ? defines.Length : 0,
                includeHandler,
                out result, out debugBlobName, out debugBlob);
        }

        public unsafe Result CompileWithDebug(IDxcBlob source,
            string sourceName,
            string entryPoint,
            string targetProfile,
            string[] arguments,
            int argumentsCount,
            DxcDefine[] defines,
            int defineCount,
            IDxcIncludeHandler includeHandler,
            out IDxcOperationResult result,
            out string debugBlobName, out IDxcBlob debugBlob)
        {

            IntPtr* argumentsPtr = (IntPtr*)0;

            try
            {
                if (arguments != null && argumentsCount > 0)
                {
                    argumentsPtr = Interop.AllocToPointers(arguments, argumentsCount);
                }

                IntPtr debugBlobNameOut = IntPtr.Zero;

                Result hr = CompileWithDebug(source, sourceName,
                    entryPoint, targetProfile,
                    (IntPtr)argumentsPtr, argumentsCount,
                    defines, defineCount,
                    includeHandler,
                    out result,
                    new IntPtr(&debugBlobNameOut),
                    out debugBlob);

                if (debugBlobNameOut != IntPtr.Zero)
                {
                    debugBlobName = Marshal.PtrToStringUni(debugBlobNameOut);
                }
                else
                {
                    debugBlobName = string.Empty;
                }

                if (hr.Failure)
                {
                    result = default;
                    return hr;
                }

                return hr;
            }
            finally
            {
                if (argumentsPtr != null)
                {
                    Interop.Free(argumentsPtr);
                }
            }
        }
    }
}
