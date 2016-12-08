using System;

namespace Scutum.Library.Enumerator
{
    [Flags]
    public enum EHttpVerbs
    {
        Get = 1,
        Post = 2,
        Put = 4,
        Delete = 8,
        Head = 16,
        Patch = 32,
        Options = 64,
    }
}