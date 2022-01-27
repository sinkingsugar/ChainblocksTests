/* SPDX-License-Identifier: BSD-3-Clause */
/* Copyright © 2022 Fragcolor Pte. Ltd. */

using System;
using System.Runtime.InteropServices;

namespace Fragcolor.Chainblocks
{
  public static class CBCoreExtensions
  {
    public static IntPtr Alloc(this ref CBCore core, uint size)
    {
      var allocDelegate = Marshal.GetDelegateForFunctionPointer<AllocDelegate>(core._alloc);
      return allocDelegate(size);
    }

    public static void Free(this ref CBCore core, IntPtr ptr)
    {
      var freeDelegate = Marshal.GetDelegateForFunctionPointer<FreeDelegate>(core._free);
      freeDelegate(ptr);
    }

    public static byte Suspend(this ref CBCore core, IntPtr context, double duration)
    {
      var suspendDelegate = Marshal.GetDelegateForFunctionPointer<SuspendDelegate>(core._suspend);
      return suspendDelegate(context, duration);
    }

    public static IntPtr AllocExternalVariable(this ref CBCore core, Chain chain, string name)
    {
      var allocExternalVariableDelegate = Marshal.GetDelegateForFunctionPointer<AllocExternalVariableDelegate>(core._allocExternalVariable);
      return allocExternalVariableDelegate(chain._ref, name);
    }

    public static void FreeExternalVariable(this ref CBCore core, Chain chain, string name)
    {
      var freeExternalVariableDelegate = Marshal.GetDelegateForFunctionPointer<FreeExternalVariableDelegate>(core._freeExternalVariable);
      freeExternalVariableDelegate(chain._ref, name);
    }

    public static Node CreateNode(this ref CBCore core)
    {
      var createNodeDelegate = Marshal.GetDelegateForFunctionPointer<CreateNodeDelegate>(core._createNode);
      return new Node { _ref = createNodeDelegate() };
    }

    public static byte Tick(this ref CBCore core, Node node)
    {
      var tickDelegate = Marshal.GetDelegateForFunctionPointer<TickDelegate>(core._tick);
      return tickDelegate(node._ref);
    }

    public static void Schedule(this ref CBCore core, Node node, Chain chain)
    {
      var scheduleDelegate = Marshal.GetDelegateForFunctionPointer<ScheduleDelegate>(core._schedule);
      scheduleDelegate(node._ref, chain._ref);
    }

    public static void Unschedule(this ref CBCore core, Node node, Chain chain)
    {
      var scheduleDelegate = Marshal.GetDelegateForFunctionPointer<ScheduleDelegate>(core._unschedule);
      scheduleDelegate(node._ref, chain._ref);
    }

    public static void DestroyVar(this ref CBCore core, IntPtr varRef)
    {
      var destroyVarDelegate = Marshal.GetDelegateForFunctionPointer<DestroyVarDelegate>(core._destroyVar);
      destroyVarDelegate(varRef);
    }
  }
}