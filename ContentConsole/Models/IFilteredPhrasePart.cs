namespace ContentConsole.Models
{
    public interface IFilteredPhrasePart: IPhrasePart
    {
        bool IsFilteredWord { get; set; }
        string OriginalPart { get; }
    }
}