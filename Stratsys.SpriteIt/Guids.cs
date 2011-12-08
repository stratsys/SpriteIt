// Guids.cs
// MUST match guids.h
using System;

namespace Stratsys.Stratsys_SpriteIt
{
    static class GuidList
    {
        public const string guidSpriteItPkgString = "7095D91A-8792-41b1-91B4-50A5C10D0C61";
        public static readonly Guid guidSpriteItPkg = new Guid(guidSpriteItPkgString);
        public static readonly Guid guidSpriteItCmdSet = new Guid("A1917F1E-A86B-429f-87F7-1541443EC6C2");
        public static readonly Guid guidSpriteItGrp = new Guid("F4FB405E-FE63-4702-95F9-41847639BEF9");
    };
}