﻿/*==============================================================================
Copyright (c) 2013-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Qualcomm Confidential and Proprietary
==============================================================================*/

using System.IO;
using UnityEditor;

/// <summary>
/// class wrapping a JS functionality to unzip a file, registers itself at the Unzipper Singleton to provide the functionality.
/// </summary>
[InitializeOnLoad]
public class SharpZipLibUnzipper : IUnzipper
{
    /// <summary>
    /// register an instance of this class at the singleton immediately
    /// </summary>
    static SharpZipLibUnzipper()
    {
        Unzipper.Instance = new SharpZipLibUnzipper();
    }

    public Stream UnzipFile(string path, string fileNameinZip)
    {
#if !EXCLUDE_JAVASCRIPT
        return Unzip.Unzip(path, fileNameinZip);
#else
        return null;
#endif
    }
}