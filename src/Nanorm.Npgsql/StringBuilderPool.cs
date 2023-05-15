// Copyright (c) .NET Foundation. All rights reserved. 
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

// Sourced from https://github.com/aspnet/Benchmarks/blob/7058cf6424321ecf5cc1442f8e1a0a06fdd5a19f/src/Benchmarks/Data/StringBuilderCache.cs

using System.Text;

namespace Nanorm.Npgsql;

internal class StringBuilderPool
{
    private const int DefaultCapacity = 1386;
    private const int MaxBuilderSize = DefaultCapacity * 3;

    [ThreadStatic]
    private static StringBuilder? _sb;

    public static StringBuilder Acquire(int capacity = DefaultCapacity)
    {
        if (capacity <= MaxBuilderSize)
        {
            StringBuilder? sb = _sb;
            if (capacity < DefaultCapacity)
            {
                capacity = DefaultCapacity;
            }

            if (sb != null)
            {
                // Avoid stringbuilder block fragmentation by getting a new StringBuilder
                // when the requested size is larger than the current capacity
                if (capacity <= sb.Capacity)
                {
                    _sb = null;
                    sb.Clear();
                    return sb;
                }
            }
        }

        return new(capacity);
    }

    public static void Release(StringBuilder sb)
    {
        if (sb.Capacity <= MaxBuilderSize)
        {
            _sb = sb;
        }
    }

    public static string GetStringAndRelease(StringBuilder sb)
    {
        string result = sb.ToString();
        Release(sb);
        return result;
    }
}
