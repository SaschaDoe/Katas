namespace SoundAtmosphere
{
    public abstract record Entry
    {
        public string Name { get; init; }
        public string Path { get; init; }
    }
}