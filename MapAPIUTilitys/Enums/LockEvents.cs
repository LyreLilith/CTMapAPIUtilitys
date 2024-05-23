/**************************************************************************
 * Copyright (C) 2024 Lilith Sutton, Ashely LastName
 *
 * This file is part of the AdvancedMapEditorAPI
 * 
 * This file incorporates work covered by the following copyright and 
 * permission notice:
 * 
 * -----------------------------------------------------------------------
 * <copyright file="MapEditorReborn.cs" company="MapEditorReborn">
 * Copyright (c) MapEditorReborn. All rights reserved.
 * Licensed under the CC BY-SA 3.0 license.
 * </copyright>
 * -----------------------------------------------------------------------
 * 
 * This file may be used under the terms of the MIT License.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a 
 * copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the 
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included 
 * in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 * Attribution: This software includes contributions from Lilith Sutton Ashely LastName, available
 * under the MIT License.
 **************************************************************************/
using System;

namespace CTmapAPI.Enums;

[Flags]
public enum LockEvents
{
    None =0,
    Time = 1,
    Detonation = 2,
    Decontamination = 4,
    LockDown =   8,
    Contain939 = 16,
    Contain3115 = 32,
    Contain096 = 64,
    Contain049 = 128,
    Contain106 = 256,
    Contain079 = 512,
    OnChaosSpawn = 1024,
    OnMtfSpawn = 2048,
    ExcapedPlayer = 4096,
    Contain173 = 8192
}
