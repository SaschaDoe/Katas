using System;

namespace SoundAtmosphere
{
    public record Sound : Entry
    {
        public int Length { get; init; }
        public int CurrentPosition { get; init; }
    }
}