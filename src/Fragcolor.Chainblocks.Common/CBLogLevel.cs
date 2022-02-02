﻿/* SPDX-License-Identifier: BSD-3-Clause */
/* Copyright © 2022 Fragcolor Pte. Ltd. */

namespace Fragcolor.Chainblocks
{
  public enum CBLogLevel
  {
    //! Must match log level in chainblocks (currently from spdlog)
    Trace = 0,
    Debug = 1,
    Info = 2,
    Warn = 3,
    Error = 4,
    Fatal = 5,
  }
}