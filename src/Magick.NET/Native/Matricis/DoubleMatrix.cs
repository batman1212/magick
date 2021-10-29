// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    public partial class DoubleMatrix
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr DoubleMatrix_Create(double* values, UIntPtr order);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void DoubleMatrix_Dispose(IntPtr instance);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr DoubleMatrix_Create(double* values, UIntPtr order);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void DoubleMatrix_Dispose(IntPtr instance);
            }
            #endif
        }
        private unsafe sealed class NativeDoubleMatrix : NativeInstance
        {
            static NativeDoubleMatrix() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.DoubleMatrix_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.DoubleMatrix_Dispose(instance);
                #endif
            }
            public NativeDoubleMatrix(double[] values, int order)
            {
                fixed (double* valuesFixed = values)
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    Instance = NativeMethods.X64.DoubleMatrix_Create(valuesFixed, (UIntPtr)order);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    Instance = NativeMethods.X86.DoubleMatrix_Create(valuesFixed, (UIntPtr)order);
                    #endif
                    if (Instance == IntPtr.Zero)
                        throw new InvalidOperationException();
                }
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(DoubleMatrix);
                }
            }
        }
        internal static INativeInstance CreateInstance(IDoubleMatrix? instance)
        {
            if (instance == null)
                return NativeInstance.Zero;
            return DoubleMatrix.CreateNativeInstance(instance);
        }
    }
}