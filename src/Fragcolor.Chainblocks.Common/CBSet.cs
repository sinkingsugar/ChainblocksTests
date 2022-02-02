﻿/* SPDX-License-Identifier: BSD-3-Clause */
/* Copyright © 2022 Fragcolor Pte. Ltd. */

using System;
using System.Runtime.InteropServices;

namespace Fragcolor.Chainblocks
{
  [StructLayout(LayoutKind.Sequential)]
  public struct CBSet
  {
    //! Native struct, don't edit
    internal IntPtr _opaque;
    internal IntPtr _api;

    public static CBSet New()
    {
      var setNewDelegate = Marshal.GetDelegateForFunctionPointer<SetNewDelegate>(Native.Core._setNew);
      return setNewDelegate();
    }
  }

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  internal delegate CBSet SetNewDelegate();
}
